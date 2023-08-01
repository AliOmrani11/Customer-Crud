using CrudTest.Shared.Dto.Request;
using FluentValidation;

namespace Application.CQRS.Query.GetCustomer;

public class GetCustomerValidator : AbstractValidator<GetCustomerRequest>
{
    public GetCustomerValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("Id is required");
    }
}
