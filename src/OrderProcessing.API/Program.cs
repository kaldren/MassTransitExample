using MassTransit;
using OrderProcessing.API.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderReceivedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("order-received-queue", e =>
        {
            e.ConfigureConsumer<OrderReceivedConsumer>(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Create new order
app.MapPost("/orders", (Order order) =>
{
    Console.WriteLine(order);
});

app.Run();