using InventoryHub.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("BlazorClient", policy =>
	{
		policy
			.WithOrigins("https://localhost:7030", "http://localhost:5297")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services.AddOutputCache(options =>
{
	options.AddBasePolicy(policyBuilder => policyBuilder.Expire(TimeSpan.FromSeconds(30)));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("BlazorClient");
app.UseOutputCache();

app.MapGet("/", () => Results.Ok(new { message = "InventoryHub API is running." }));

app.MapGet("/api/products", (int pageNumber = 1, int pageSize = 10) =>
{
	pageNumber = Math.Max(pageNumber, 1);
	pageSize = Math.Clamp(pageSize, 1, 50);

	var products = ProductStore.Products;
	var totalCount = products.Count;
	var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

	var items = products
		.Skip((pageNumber - 1) * pageSize)
		.Take(pageSize)
		.ToList();

	var response = new PagedResult<Product>
	{
		Items = items,
		PageNumber = pageNumber,
		PageSize = pageSize,
		TotalCount = totalCount,
		TotalPages = totalPages
	};

	return Results.Ok(response);
})
.WithName("GetProducts")
.CacheOutput();

app.Run();

internal static class ProductStore
{
	public static readonly List<Product> Products = Enumerable.Range(1, 120)
		.Select(i => new Product
		{
			Id = i,
			Name = $"Product {i}",
			Quantity = 10 + (i % 25),
			Price = Math.Round(50 + (i * 2.35m), 2)
		})
		.ToList();
}
