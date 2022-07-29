using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WNBA.Core.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
var a = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()));

builder.Services
    .AddWNBAServices()
    .AddApiVersioning(delegate (ApiVersioningOptions options)
    {
        options.DefaultApiVersion = new ApiVersion(0, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    });
builder.Services
    .AddVersionedApiExplorer(delegate (ApiExplorerOptions options)
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();