using MassTransit;
using Messaging;
using OrderAPI.Consumers;
using SharedContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<OrderProcessedConsumer>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h => {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("order-processed-queue", e =>
        {
            e.ConfigureConsumer<OrderProcessedConsumer>(context);
        });
    });

});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// In-memory storage for orders

app.UseHttpsRedirection();
app.UseCors();

// Create new order
app.MapPost("/orders", async (Order order, IBus bus) =>
{
    // Add to in-memory storage
    OrdersDatabase.Orders.Add(order);
    Console.WriteLine("Order added to db.");

    // Publish to message broker
    // NOTE: In a real app we might have to use outbox pattern
    await bus.Publish(new OrderReceived(order.OrderId, order.ProductId, order.Quantity));
    Console.WriteLine("Order published to message broker.");
});

// Get all orders
app.MapGet("/orders", () =>
{
    return OrdersDatabase.Orders;
});

app.Run();