using MassTransit;
using Messaging;
using SharedContracts;

namespace Inventory.API.Consumers;

public class OrderReceivedConsumer : IConsumer<OrderReceived>
{
    private readonly IBus _bus;

    public OrderReceivedConsumer(IBus bus)
    {
        _bus = bus;
    }

    public async Task Consume(ConsumeContext<OrderReceived> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received order ID: {message.OrderId}. Checking availability...");

        // Simulate checking availability
        bool available = ProductsDatabase.Products.Any(p => p.ProductId == message.ProductId && p.Quantity >= message.Quantity);

        if (available)
        {
            Console.WriteLine("Product is available. Processing order...");
            await _bus.Publish(new OrderProcessed(message.OrderId, "To be delivered"));
        }
        else
        {
            Console.WriteLine("Product is not available. Cancelling order...");
            await _bus.Publish(new OrderProcessed(message.OrderId, "Not enough inventory"));
        }
    }
}
