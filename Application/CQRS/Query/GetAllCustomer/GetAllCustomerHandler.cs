using Application.Repositries;
using AutoMapper;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Customer;
using MediatR;

namespace Application.CQRS.Query.GetAllCustomer;

public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerRequest, List<CustomerResponse>>
{

    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCustomerHandler(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CustomerResponse>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetAllAsync();
        return _mapper.Map<List<CustomerResponse>>(customers);
    }
}
