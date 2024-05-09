using MassTransit;
using Messaging;

namespace OrderProcessing.API.Consumers;

public class OrderReceivedConsumer : IConsumer<OrderReceived>
{
    public async Task Consume(ConsumeContext<OrderReceived> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received order ID: {message.OrderId}");
    }
}
