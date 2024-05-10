using SharedContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

// In memory database of products

app.MapGet("/products", () =>
{
    return ProductsDatabase.Products;
});

app.MapGet("/products/{productId}", (int productId) =>
{
    return ProductsDatabase.Products.SingleOrDefault(products => products.ProductId == productId);
});

app.Run();

