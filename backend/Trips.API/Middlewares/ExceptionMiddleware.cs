
using System.Net;
using Trips.API.Contracts;

namespace Trips.API.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ExceptionResponse(
                statusCode, 
                ex.Message);

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
