using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.Infrastructure.EF.Context;

namespace OrderManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            var connection = (configuration.GetConnectionString("SvcDbContext"));
            services.AddDbContext<OrderManagementDbContext>(options =>
        options.UseNpgsql(connection));

            return services;
        }

    }
}
