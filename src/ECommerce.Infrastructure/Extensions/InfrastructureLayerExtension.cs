using ECommerce.Common.Settings.Concrete;
using ECommerce.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.Extensions
{
    public static class InfrastructureLayerExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            ProductDbSettings productDbSettings = new ProductDbSettings();
            configuration.GetSection(nameof(ProductDbSettings)).Bind(productDbSettings);
            services.AddSingleton(productDbSettings);

            services.AddDbContext<ECommerceDbContext>(c => c.UseNpgsql(productDbSettings.ConnectionString));

            return services;
        }
    }
}
