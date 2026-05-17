using System.Net.Http.Json;
using InventoryHub.Web.Models;

namespace InventoryHub.Web.Services;

public class ProductApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<PagedResult<Product>?> GetProductsAsync(int pageNumber, int pageSize)
    {
        var requestUrl = $"api/products?pageNumber={pageNumber}&pageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<PagedResult<Product>>(requestUrl);
    }
}
