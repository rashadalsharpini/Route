using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstraction;

namespace Presentation.Attributes;

public class CacheAttribute(int DurationInSec = 90):ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        string CacheKey = CreateCacheKey(context.HttpContext.Request);
        ICacheService cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
        var cacheValue = await cacheService.GetAsync(CacheKey);
        if (cacheValue is not null)
        {
            context.Result = new ContentResult()
            {
                Content = cacheValue,
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };
            return;
        }
        var executedContext = await next.Invoke();
        if (executedContext.Result is OkObjectResult result)
        {
            await cacheService.SetAsync(CacheKey, result.Value, TimeSpan.FromSeconds(DurationInSec));
        }
    }

    private string CreateCacheKey(HttpRequest request)
    {
        StringBuilder key = new StringBuilder();
        key.Append(request.Path+'?');
        foreach (var item in request.Query.OrderBy(q=>q.Key))
            key.Append($"{item.Key}={item.Value}&");
        return key.ToString();
    }

}