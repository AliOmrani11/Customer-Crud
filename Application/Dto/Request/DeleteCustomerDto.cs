using CrudTest.Shared.Dto.Response.Public;
using MediatR;

namespace CrudTest.Shared.Dto.Request;

public class DeleteCustomerDto : IRequest<ServiceResult<int>>
{
    public Guid Id { get; set; }
}
