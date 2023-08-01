using CrudTest.Shared.Dto.Response.Public;
using FluentValidation;
using MediatR;

namespace CrudTest.Shared.Dto.Request;

public class InsertCustomerDto : IRequest<ServiceResult<int>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get;set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}


