using Application.Dto.Response.Public;
using FluentValidation;
using Newtonsoft.Json;

namespace Api.Setting.MiddleWares;

public class ExceptionHandlingMiddleware : IMiddleware
{


    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var statusCode = GetStatusCode(exception);
        var response = new ApiBaseResult { Error = true, Message = GetErrors(exception) };
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(response.ToString());
    }
    private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            //BadRequestException => StatusCodes.Status400BadRequest,
            //NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
    private static List<string> GetErrors(Exception exception)
    {
        Console.WriteLine(JsonConvert.SerializeObject(exception));
        List<string> errors = new List<string>();
        if (exception is ValidationException validationException)
        {
            errors = validationException.Errors.Select(s => s.ErrorMessage).Distinct().ToList();
        }
        else
        {
            errors.Add(exception.Message);
        }
        return errors;
    }
}
