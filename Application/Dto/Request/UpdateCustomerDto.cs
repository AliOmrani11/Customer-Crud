using CrudTest.Shared.Dto.Response.Public;
using MediatR;

namespace CrudTest.Shared.Dto.Request;

public class UpdateCustomerDto : IRequest<ServiceResult<int>>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get;  set; }
    public DateTime DateOfBirth { get;  set; }
    public string PhoneNumber { get;  set; }
    public string Email { get;  set; }
    public string BankAccountNumber { get;  set; }
}
