using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Repository;

public interface IProuctRepository
{
    public Task<IEnumerable<ProductDto>> GetProducts();
    public Task<ProductDto>              GetProduct(int productId);

    public Task<ProductDto> CreateUpdateDto(ProductDto productDto);
    public Task<bool>       DeleteProduct(int productId);
}