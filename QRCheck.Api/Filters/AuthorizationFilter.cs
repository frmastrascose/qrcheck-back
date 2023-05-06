using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Hackaton.Api.Filters;

public class AuthorizationFilter : IAsyncAuthorizationFilter
{
    private readonly string _apiKey;

    public AuthorizationFilter(IConfiguration configuration)
    {
        _apiKey = configuration.GetSection("API_KEY").Value;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(e => e.GetType() == typeof(AllowAnonymousAttribute)))
                return;

            if (context.HttpContext.Request.Headers.TryGetValue("API_KEY", out StringValues headerAntiFraudApiKey))
            {
                if (!headerAntiFraudApiKey.Equals(_apiKey))
                {
                    Unauthorize(context, "Acesso Negado.");
                    return;
                }
            }
            else
            {
                Unauthorize(context, "Api Key Incorreta ou Ausente.");
                return;
            }
        }
        catch (Exception ex)
        {
            Unauthorize(context, $"Exception: {ex.Message} | StackTrace: {ex.StackTrace}");
        }
    }

    private void Unauthorize(AuthorizationFilterContext context, string reason)
    {
        context.Result = new JsonResult($"Nao Autorizado: {reason}");
        context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
    }
}
