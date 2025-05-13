using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.EF.Context;
using OrderManagement.Infrastructure.Repositories;
using OrderManagement.Infrastructure.UnitOfWork;
using System.Text.Json.Serialization;

namespace OrderManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<OrderManagementDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddScoped<IOrderManagementRepository, OrderManagementRepository>();



            return services;
        }

    }
}
