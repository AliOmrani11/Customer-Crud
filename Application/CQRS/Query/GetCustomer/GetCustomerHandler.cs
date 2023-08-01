using Application.Repositries;
using AutoMapper;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Customer;
using MediatR;

namespace Application.CQRS.Query.GetCustomer;

public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, CustomerResponse>
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetCustomerHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<CustomerResponse>(customer);
    }
}
