﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace WNBA.Core.Api.Configuration;

/// <summary>
/// Provides extension methods for the <see cref="IServiceCollection"/> interface.
/// </summary>
internal static class IServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Connector services to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current <see cref="IServiceCollection"/>.</param>
    /// <param name="configureOptions">The options configuration for the Connector Core.</param>
    /// <returns>The configured <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddWNBAServices(this IServiceCollection services)
    {
        return services
            .AddDbContext();
        //.Configure(configureOptions);
        //.AddServices();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:Default"))
            .AddSqlServer<ApplicationDbContext>("name=ConnectionStrings:Default");

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        return services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v0", new OpenApiInfo { Title = "WNBA", Version = "v0" });
        });
    }

    //private static IServiceCollection AddConnectors(this IServiceCollection services)
    //{
    //    services.TryAddSingleton<IHuaweiConnector, HuaweiConnector>();

    //    return services;
    //}

    //private static IServiceCollection AddServices(this IServiceCollection services)
    //{
    //    services.TryAddSingleton<IHuaweiAuthenticationService, HuaweiAuthenticationService>();
    //    services.TryAddSingleton<IHuaweiPlantService, HuaweiPlantService>();
    //    return services;
    //}
}
