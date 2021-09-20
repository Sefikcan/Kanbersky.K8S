using ECommerce.Application.Mappings.AutoMapper;
using ECommerce.Common.Mappings.Abstract;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Application.Extensions
{
    public static class ApplicationLayerExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddSingleton<IKanberskyMapping, AutoMapping>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
