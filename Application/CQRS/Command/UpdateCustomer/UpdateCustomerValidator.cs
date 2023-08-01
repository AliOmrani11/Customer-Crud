using CrudTest.Shared.Dto.Request;
using FluentValidation;

namespace Application.CQRS.Command.UpdateCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDto>
{
    public UpdateCustomerValidator()
    {
        RuleFor(s => s.Id)
            .NotNull()
            .WithMessage("Id is required");

        RuleFor(s => s.FirstName)
           .NotEmpty()
           .WithMessage("FirstName is required.")
           .MaximumLength(250)
           .WithMessage("FirstName maximum character is 250.");

        RuleFor(s => s.LastName)
           .NotEmpty()
           .WithMessage("LastName is required.")
           .MaximumLength(250)
           .WithMessage("LastName maximum character is 250.");

        RuleFor(s => s.DateOfBirth)
           .NotNull()
           .WithMessage("DateOfBirth is required.");

        RuleFor(x => x.Email)
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Email format invalid ");

        RuleFor(s => s.BankAccountNumber)
            .Matches(@"^\d{10}$")
            .WithMessage("Bank Account Number is invalid.");
    }
}
