var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/products", () =>
{
    return new List<Product>
    {
        new Product(Guid.NewGuid().ToString(), "MacBook Pro", 2999.99M),
        new Product(Guid.NewGuid().ToString(), "Harry Potter and The Order of The Phoenix", 19.99M),
        new Product(Guid.NewGuid().ToString(), "Leather Jacket", 699.99M),
    };
});

app.Run();

internal record Product(string ProductId, string Name, decimal Price);

