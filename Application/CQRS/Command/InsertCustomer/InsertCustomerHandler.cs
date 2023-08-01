using Application.Repositries;
using Application.Services;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Public;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.Command.InsertCustomer;

public class InsertCustomerHandler : IRequestHandler<InsertCustomerDto, ServiceResult<int>>
{
    private readonly ICustomerRepository _repository;
    private readonly IPhoneNumberValidator _numberValidator;

    public InsertCustomerHandler(ICustomerRepository repository, IPhoneNumberValidator numberValidator)
    {
        _repository = repository;
        _numberValidator = numberValidator;
    }

    public async Task<ServiceResult<int>> Handle(InsertCustomerDto request, CancellationToken cancellationToken)
    {
        var checkemail= await _repository.CheckEmail(request.Email);
        if (checkemail!=null)
        {
            return new ServiceResult<int>
            {
                Success = false,
                Error = "Email is exists for another customers."
            };
        }

        var checkinfo = await _repository.CheckInfo(request.FirstName , request.LastName , request.DateOfBirth);
        if (checkinfo!=null)
        {
            return new ServiceResult<int>
            {
                Success = false,
                Error = "Customer info is duplicate"
            };
        }

        var checkMobile = await _numberValidator.CheckPhoneNumber(request.PhoneNumber);
        if (!checkMobile)
        {
            return new ServiceResult<int>
            {
                Success = false,
                Error = "phone number is invalid"
            };
        }
        var customer = Customer.Create(request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);

        await _repository.AddAsync(customer);

        return new ServiceResult<int>
        {
            Success = true
        };
    }
}
