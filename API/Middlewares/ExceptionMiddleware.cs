using System.Net;
using System.Text.Json;
using FindMyCar.Core.Exceptions;
namespace API.Middlewares;

public class ExceptionMiddleware
{
    #region Private Members
    private readonly RequestDelegate next;
    #endregion
    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (ex)
            {
                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BadRequestException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = ex?.Message });
            Console.WriteLine(result);
            await response.WriteAsync(result);
        }
    }
}
