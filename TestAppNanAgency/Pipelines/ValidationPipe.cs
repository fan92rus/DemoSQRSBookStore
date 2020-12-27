﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using FluentValidation;
using MediatR;

namespace App.WebApi.Pipelines
{
    public class ValidationPipe<TRequest, TResponse> where TResponse : class, IPipelineBehavior<TRequest, TResponse>
    {
        public IEnumerable<IValidator<TRequest>> Validators { get; }

        public ValidationPipe(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }


        public async Task<Operation<TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Operation<TResponse>> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = Validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();

            if(errors.Any())
                throw  new ValidationException(errors);

            return await next();
        }
    }
}
