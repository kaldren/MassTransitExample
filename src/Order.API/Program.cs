var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// Create new order
app.MapPost("/orders", (Order order) =>
{
    Console.WriteLine(order);
});

app.Run();

public record Product(string ProductId, int Quantity);
public record Order(string OrderId, List<Product> Products);