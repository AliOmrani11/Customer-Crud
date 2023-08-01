using CrudTest.Shared.Dto.Request;
using FluentValidation;

namespace Application.CQRS.Command.DeleteCustomer;

public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerDto>
{
    public DeleteCustomerValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("Id is required");
    }
}
