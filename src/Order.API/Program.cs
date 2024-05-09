using MassTransit;
using Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h => {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.

// In-memory storage for orders
List<Order> orders = new();

app.UseHttpsRedirection();

// Create new order
app.MapPost("/orders", async (Order order, IBus bus) =>
{
    // Add to in-memory storage
    orders.Add(order);
    Console.WriteLine("Order added to db.");

    // Publish to message broker
    // NOTE: In a real app we might have to use outbox pattern
    await bus.Publish(new OrderReceived(order.OrderId, order.Products));
    Console.WriteLine("Order published to message broker.");
});

// Get all orders
app.MapGet("/orders", () =>
{
    return orders;
});

app.Run();