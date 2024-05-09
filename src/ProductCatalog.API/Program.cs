var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

// In memory database of products
List<Product> products = new List<Product>
    {
        new Product(Guid.NewGuid().ToString(), "MacBook Pro", 2999.99M, 5),
        new Product(Guid.NewGuid().ToString(), "Harry Potter and The Order of The Phoenix", 19.99M, 3),
        new Product(Guid.NewGuid().ToString(), "Leather Jacket", 699.99M, 1),
    };

app.MapGet("/products", () =>
{
    return products;
});

app.MapGet("/products/{productId}", (string productId) =>
{
    return products.SingleOrDefault(products => products.ProductId == productId);
});

app.Run();

internal record Product(string ProductId, string Name, decimal Price, int Quantitys);

