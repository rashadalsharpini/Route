using Domain.Execptions;
using Shared.ErrorModels;

namespace E_Commerce.Web.CustomMiddleWares;

public class CustomExceptionHandlerMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;
    public CustomExceptionHandlerMiddleWare(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleWare> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var res = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = $"End Point not found{context.Request.Path}",
                };
                await context.Response.WriteAsJsonAsync(res);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };
            context.Response.ContentType = "application/json";
            var res = new ErrorToReturn()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            };
            await context.Response.WriteAsJsonAsync(res);
        }
    }
}