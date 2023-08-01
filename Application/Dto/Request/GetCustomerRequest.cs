using CrudTest.Shared.Dto.Response.Customer;
using MediatR;

namespace CrudTest.Shared.Dto.Request;

public class GetCustomerRequest : IRequest<CustomerResponse>
{
    public Guid Id { get; set; }
}
