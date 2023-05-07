using Domain.AutoMapper;
using Domain.Validators;
using FluentValidation.AspNetCore;
using Hackaton.Api.Configurations;
using Hackaton.Api.Filters;
using Hackaton.Api.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using QRCheck.Api.Configurations;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddControllersWithViews();
builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(GlobalExceptionFilter));
    config.Filters.Add(typeof(AuthorizationFilter));
});

builder.Services.AddControllers(c =>
{
    c.Filters.Add(typeof(GlobalExceptionFilter));
}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SmsRequestModelValidator>());

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAutoMapperSetup();

builder.Services.AddIoC(Configuration);
builder.Services.AddDataProtection();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureResultErros();
var app = builder.Build();
var basePath = Environment.GetEnvironmentVariable("Base_Path") ?? "";
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
    c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
    {
        var scheme = Debugger.IsAttached ? httpReq.Scheme : "https";
        swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{scheme}://{httpReq.Host.Value}{basePath}" } };
    });
});
app.UseSwaggerUI();
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
