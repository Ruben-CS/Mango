using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services;

public class ProductService : BaseService, IProductService
{
    private readonly IHttpClientFactory _clientFactory;
    
    public ProductService(IHttpClientFactory httpClientFactory) : base(
        httpClientFactory)
    {
        _clientFactory = httpClientFactory;
    }

    public async Task<T> GetAllProductsAsync<T>()
    {
        return await SendAsync<T>(new ApiRequest()
        {
            Type        = SD.ApiType.GET,
            Url         = $"{SD.ProductAPIBase}/api/products",
            AccessToken = ""
        });
    }

    public async Task<T> GetProductById<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            Type        = SD.ApiType.POST,
            Data        = typeof(ProductDto),
            Url         = $"{SD.ProductAPIBase}/api/products/{id}",
            AccessToken = ""
        });
    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            Type        = SD.ApiType.POST,
            Data        = productDto,
            Url         = $"{SD.ProductAPIBase}/api/products",
            AccessToken = ""
        });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            Type        = SD.ApiType.PUT,
            Data        = productDto,
            Url         = $"{SD.ProductAPIBase}/api/products",
            AccessToken = ""
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            Type        = SD.ApiType.DELETE,
            Url         = $"{SD.ProductAPIBase}/api/products",
            AccessToken = ""
        });
    }
}