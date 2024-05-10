public record Order(int ProductId, int Quantity)
{
    public string OrderId { get; } = Guid.NewGuid().ToString();

    public string Status { get; set; } = "Pending";
}