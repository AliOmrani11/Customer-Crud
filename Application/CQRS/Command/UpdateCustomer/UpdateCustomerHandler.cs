using Application.Repositries;
using Application.Services;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Public;
using MediatR;

namespace Application.CQRS.Command.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerDto, ServiceResult<int>>
{

    private readonly ICustomerRepository _repository;
    private readonly IPhoneNumberValidator _numberValidator;

    public UpdateCustomerHandler(ICustomerRepository repository, IPhoneNumberValidator numberValidator)
    {
        _repository = repository;
        _numberValidator = numberValidator;
    }


    public async Task<ServiceResult<int>> Handle(UpdateCustomerDto request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer==null)
        {
            return new ServiceResult<int>
            {
                Success = false,
                Error = "Customer not exists"
            };
        }

        var checkemail = await _repository.CheckEmail(request.Email);
        if (checkemail != null && checkemail.Id!=request.Id)
        {
            return new ServiceResult<int>
            {
                Success = false,
                Error = "Email is exists for another customers."
            };
        }

        var checkinfo = await _repository.CheckInfo(request.FirstName, request.LastName, request.DateOfBirth);
        if (checkinfo != null && checkinfo.Id != request.Id)
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
        customer.UpdateDetails(request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);

        await _repository.UpdateAsync(customer);


        return new ServiceResult<int>
        {
            Success = true
        };
    }
}
