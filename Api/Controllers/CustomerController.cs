using Application.Dto.Response.Public;
using CrudTest.Shared.Dto.Request;
using CrudTest.Shared.Dto.Response.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Player.Presentation.Setting.UrlHelper;
using System.Net;

namespace Api.Controllers;


[ApiController]
[ApiExplorerSettings(GroupName ="Customer")]
[ApiVersion("1.0")]
public class CustomerController : ControllerBase
{

    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Insert customer 
    /// </summary>
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.BadRequest)]
    [HttpPost(AdminRoute.Customer.Insert)]
    public async Task<IActionResult> InsertCustomer(InsertCustomerDto request)
    {
        var result = await _mediator.Send(request);
        if (!result.Success)
        {
            return BadRequest(result.Error);
        }
        return Ok();
    }


    /// <summary>
    /// Update customer 
    /// </summary>
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.BadRequest)]
    [HttpPost(AdminRoute.Customer.Update)]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto request)
    {
        var result = await _mediator.Send(request); 
        if (!result.Success)
        {
            return BadRequest(result.Error);
        }
        return Ok();
    }


    /// <summary>
    /// Delete customer by id
    /// </summary>
    [ProducesResponseType(typeof(ApiBaseResult),(int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiBaseResult),(int)HttpStatusCode.BadRequest)]
    [HttpDelete(AdminRoute.Customer.Delete)]
    public async Task<IActionResult> DeleteCustomer([FromQuery]DeleteCustomerDto request)
    {
        var result = await _mediator.Send(request);
        if (!result.Success)
        {
            return BadRequest(result.Error);
        }
        return Ok();
    }


    /// <summary>
    /// Getall customer 
    /// </summary>
    [ProducesResponseType(typeof(ApiResult<IEnumerable<CustomerResponse>>), (int)HttpStatusCode.OK)]
    [HttpGet(AdminRoute.Customer.GetAll)]
    public async Task<IActionResult> GetAllCustomer()
    {
        var result = await _mediator.Send(new GetAllCustomerRequest());
        return Ok(result);
    }



    /// <summary>
    /// get customer by id
    /// </summary>
    [ProducesResponseType(typeof(ApiResult<CustomerResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [HttpGet(AdminRoute.Customer.Get)]
    public async Task<IActionResult> GetCustomer([FromQuery]GetCustomerRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
