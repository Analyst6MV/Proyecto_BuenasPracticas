


using FluentValidation.Results;

namespace Application.Behaver
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest: IRequest<TResponse> 
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if (_validator == null)
            {
                return await next();

            }

            var ValidatorResult = await _validator.ValidateAsync(request,cancellationToken);

            if (ValidatorResult.IsValid)
            {
                return await next();
            
            }

            var error = ValidatorResult.Errors.ConvertAll(ValidationFailure => Error.Validation( ValidationFailure.PropertyName,ValidationFailure.ErrorMessage));


            return (dynamic)error;
        }
    }
}
