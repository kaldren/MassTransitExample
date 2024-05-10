using MassTransit;
using Messaging;
using SharedContracts;

namespace OrderAPI.Consumers;

public class OrderProcessedConsumer : IConsumer<OrderProcessed>
{
    public Task Consume(ConsumeContext<OrderProcessed> context)
    {
        var message = context.Message;
        var order = OrdersDatabase.Orders.SingleOrDefault(o => o.OrderId == message.OrderId);

        if (order != null)
        {
            order.Status = message.Status;
        }

        return Task.CompletedTask;
    }
}
