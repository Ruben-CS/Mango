using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) : base(
            httpClientFactory)
        {
            // Print in terminal
            // System.Diagnostics.Debug.Write($"********* SD.ProductAPIBase: {SD.ProductAPIBase}");
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type        = SD.ApiType.GET,
                Url         = $"{SD.ProductAPIBase}/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type        = SD.ApiType.GET,
                Url         = $"{SD.ProductAPIBase}/api/products/{productId}",
                AccessToken = ""
            });
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type        = SD.ApiType.POST,
                Data        = productDto,
                Url         = $"{SD.ProductAPIBase}/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type        = SD.ApiType.PUT,
                Data        = productDto,
                Url         = $"{SD.ProductAPIBase}/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                Type        = SD.ApiType.DELETE,
                Url         = SD.ProductAPIBase + "/api/products/" + productId,
                AccessToken = ""
            });
        }
    }
}