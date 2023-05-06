using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace QRCheck.Api.Configurations;

public static class FluentValidationConfiguration
{
    public static void ConfigureResultErros(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(opt =>
        {
            opt.InvalidModelStateResponseFactory = (context) =>
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();

                return new BadRequestObjectResult(new BaseResponse(errors));
            };
        });
    }
}
