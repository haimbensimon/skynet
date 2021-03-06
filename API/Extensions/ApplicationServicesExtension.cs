using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Core.Interfaces;
using Infrasturture.Data;
using Infrasturture.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService , TokenService>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped<IBasketRepository , BasketRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.Configure<ApiBehaviorOptions>(options => {
                  options.InvalidModelStateResponseFactory = actionContext =>   
                  {
                        var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                        var errorResponse = new ApiValidationResponse
                        {
                            Errors =errors
                        };

                        return new BadRequestObjectResult(errorResponse);
                  };
            });
            return services;
        }
    }
}