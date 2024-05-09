namespace Messaging;

public record OrderReceived(string OrderId, List<Product> Products);