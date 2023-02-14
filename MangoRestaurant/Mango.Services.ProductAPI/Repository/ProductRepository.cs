using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository;

public class ProductRepository : IProuctRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    private IMapper _mapper;

    public ProductRepository(ApplicationDbContext applicationDbContext,
                             IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper               = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var productList = await _applicationDbContext.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }

    public async Task<ProductDto> GetProduct(int productId)
    {
        var product = await _applicationDbContext.Products.Where(x => x.Id ==
            productId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateUpdateDto(ProductDto productDto)
    {
        var product = _mapper.Map<ProductDto, Product>(productDto);
        if (product.Id > 0)
        {
            _applicationDbContext.Update(product);
        }
        else
        {
            _applicationDbContext.Products.Add(product);
        }

        await _applicationDbContext.SaveChangesAsync();
        return _mapper.Map<Product, ProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            var product = await _applicationDbContext.Products
                .FirstOrDefaultAsync(u => u.Id == productId);
            if (product is null)
            {
                return false;
            }
            _applicationDbContext.Products.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}