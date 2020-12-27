using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Storage;
using App.Storage.Repository;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;
using AppContext = App.Storage.AppContext;

namespace TestAppNanAgency
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var asembly = typeof(Startup).Assembly;
            services.AddMediatR(asembly);

            //services.AddValidatorsFromAssembly(asembly);
            services.AddDbContext<AppContext>();//(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppContext>().AddRoles<IdentityRole>();
            services.AddControllers();
            services.AddScoped<GenericRepository<Image>>();
            services.AddScoped<GenericRepository<Book>>();

            var mapperConfig = new MapperConfiguration(expression => { });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
                c.CustomSchemaIds(type =>
                {
                    string ReplaceCommandName(Type type, string Target)
                    {
                        if (!type.FullName.EndsWith($"+{Target}") && !type.FullName.EndsWith($"+{Target}")) return type.Name;
                        var parentTypeName = type.FullName.Substring(type.FullName.LastIndexOf(".", StringComparison.Ordinal) + 1);
                        {
                            return parentTypeName.Replace($"+{Target}", Target).Replace($"+{Target}", Target);
                        }
                    }

                    string GenGenericName(Type type)
                    {
                        var isGeneric = type.IsGenericType;
                        if (isGeneric)
                        {
                            return type.Name + $"<{string.Join(',', type.GenericTypeArguments.Select(GenGenericName))}>";
                        }

                        var change = "Query";
                        if (type.Name.Contains("Command"))
                            change = "Command";

                        return ReplaceCommandName(type, change);
                    }

                    return GenGenericName(type);
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

            await RoleCreating();
        }

        private async Task RoleCreating()
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole, AppContext>(new AppContext()), null, null, null, null);

            await AddRole(rm, "User");
            await AddRole(rm, "Manager");
            await AddRole(rm, "Administrator");
        }
        private async Task AddRole(RoleManager<IdentityRole> rm, string role)
        {
            if (!await rm.RoleExistsAsync(role))
                await rm.CreateAsync(new IdentityRole(role));
        }
    }
}
