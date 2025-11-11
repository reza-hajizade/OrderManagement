using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.Application.Commands.Handlers;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Repositories;
using OrderManagement.Infrastructure.EF;
using OrderManagement.Infrastructure.EF.Context;
using OrderManagement.Infrastructure.EF.Repositories;
using OrderManagement.Infrastructure.Messaging;
using OrderManagement.Infrastructure.Messaging.Configuration;
using OrderManagement.Infrastructure.Messaging.Publishers;
using OrderManagement.Infrastructure.UnitOfWork;
using System.Reflection;
using System.Text.Json.Serialization;


namespace OrderManagement.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSQLDB(configuration);

            services.AddScoped<IUnitOfWork, EF.UnitOfWork.UnitOfWork>();

            services.AddScoped<IOrderCreatedEventPublisher, OrderCreatedEventPublisher>();

            services.AddMassTransit(configure =>
            {
                var brokerConfig = configuration.GetSection(BrokerOptions.SectionName)
                                                .Get<BrokerOptions>();
                if (brokerConfig is null)
                {
                    throw new ArgumentNullException(nameof(BrokerOptions));
                }

                configure.AddConsumers(Assembly.GetExecutingAssembly());

                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(brokerConfig.Host, hostConfigure =>
                    {
                        hostConfigure.Username(brokerConfig.Username);
                        hostConfigure.Password(brokerConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });


           
            return services;
        }

    }
}
