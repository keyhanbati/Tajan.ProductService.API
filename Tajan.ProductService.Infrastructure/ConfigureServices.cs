﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tajan.ProductService.API.Contracts;
using Tajan.ProductService.API.Services;
using Tajan.ProductService.Infrastructure.DbContexts;

namespace Tajan.ProductService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastrauctureLayer(this IServiceCollection services,string connecttionString,bool useInMemoryDatabase)
    {
        services.AddTransient<IProductService, ProductBusiness>();

        if (useInMemoryDatabase)
        {
             services.AddDbContext<CoreDbContext>(options =>
             options.UseInMemoryDatabase("CoreDbContext"));
        }
        else
        {
            services.AddDbContext<CoreDbContext>((options) =>
            {
                options.UseSqlServer(connecttionString);
            }).AddHealthChecks();
        }

        return services;
    }
}
