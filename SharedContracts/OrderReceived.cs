namespace Messaging;

public record OrderReceived(string OrderId, int ProductId, int Quantity);