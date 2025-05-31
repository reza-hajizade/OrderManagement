using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Application.Repositories;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.EF.Context;
using OrderManagement.Infrastructure.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();

            services.AddDbContext<WriteDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));

            services.AddDbContext<ReadDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("SvcDbContext")));



            return services;
        }
    }
}
