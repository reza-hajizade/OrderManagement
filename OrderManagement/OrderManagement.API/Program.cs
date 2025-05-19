using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using OrderManagement.Application.Commands.Handlers;
using OrderManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(ConfirmStatusHandler).Assembly);
});


ConfigurationManager configuration = builder.Configuration;

builder.Services.AddApplicationServices(configuration);

builder.Services.AddControllers();



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
