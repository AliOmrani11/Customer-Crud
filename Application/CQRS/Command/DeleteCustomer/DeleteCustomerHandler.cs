using Application.Repositries;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Public;
using MediatR;

namespace Application.CQRS.Command.DeleteCustomer;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerDto, ServiceResult<int>>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<int>> Handle(DeleteCustomerDto request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            return new ServiceResult<int>
            {
                Success = false,
                Error = "Customer not exists"
            };
        }

        await _repository.DeleteAsync(customer);
        return new ServiceResult<int> { Success = true };
    }
}
