using CrudTest.Shared.Dto.Response.Customer;
using MediatR;

namespace CrudTest.Shared.Dto.Request;

public class GetAllCustomerRequest : IRequest<List<CustomerResponse>>
{
}
