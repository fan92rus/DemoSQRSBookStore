using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Models;
using FluentValidation;
using MediatR;

namespace App.WebApi.Pipelines
{
    public class OperationValidationPipe<TRequest, TResponse> where TResponse : class, IPipelineBehavior<TRequest, Operation<TResponse>>
    {
        public IEnumerable<IValidator<TRequest>> Validators { get; }

        public OperationValidationPipe(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }


        public async Task<Operation<TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Operation<TResponse>> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = Validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).Select(x=>x.ErrorMessage).ToList();

            if (errors.Any())
                return new Operation<TResponse>(false, errors, null);

            return await next();
        }
    }
}