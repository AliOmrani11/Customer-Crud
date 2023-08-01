using BoDi;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Public;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow.Assist;

namespace CrudTest.Test.StepDefinitions;

[Binding]
public class CreateCustomerStepDefinitions
{
    private IMediator _mediator;
    private ServiceResult<int> _response;
    private InsertCustomerDto _createDto;

    public CreateCustomerStepDefinitions(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Given(@"the following customer details:")]
    public void GivenTheFollowingCustomerDetails(Table table)
    {
        try
        {
            _response = new ServiceResult<int>();
            _createDto = table.CreateInstance<InsertCustomerDto>();
        }
        catch (Exception ex)
        {
            _response.Error = ex.Message;
            _response.Success = false;
            ThenTheCustomerCreationShouldFail();

            throw;
        }
    }

    [When(@"I create the customer")]
    public async Task WhenICreateTheCustomer()
    {
        try
        {
            _response = await _mediator.Send(_createDto);
        }
        catch (ValidationException ex)
        {
            _response.Error = ex.Message;
            ThenTheCustomerCreationShouldFail();
        }
    }

    [Then(@"the customer should be created successfully")]
    public void ThenTheCustomerShouldBeCreatedSuccessfully()
    {
        _response.Success.Should().Be(true);
    }

    [Then(@"the customer creation should fail")]
    public void ThenTheCustomerCreationShouldFail()
    {
        _response.Success.Should().Be(false);
    }
}
