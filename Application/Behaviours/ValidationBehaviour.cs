using FluentValidation;
using MediatR;

namespace Application.Behaviours;

public class ValidationBehaviour<TRequest, Tresponse> : IPipelineBehavior<TRequest, Tresponse>
    where TRequest : IRequest<Tresponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var errorsDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors);

            if (errorsDictionary.Any())
            {
                throw new ValidationException(errorsDictionary);
            }
        }
        return await next();

    }
}
