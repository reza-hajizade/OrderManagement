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

            services.AddDbContext<OrderManagementDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));

            return services;
        }

    }
}
