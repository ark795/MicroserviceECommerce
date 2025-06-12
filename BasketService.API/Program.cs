using BasketService.API.Application.Interfaces;
using BasketService.API.Application.Services;
using BasketService.API.Infrastructure.Data;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Redis
builder.Services.AddSingleton<RedisContext>();

// MassTransit (optional, for consuming ProductCreated)
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

// App services
builder.Services.AddScoped<IBasketService, BaskService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
