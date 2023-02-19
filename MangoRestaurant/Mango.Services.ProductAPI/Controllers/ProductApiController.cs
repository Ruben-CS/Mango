using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductApiController : ControllerBase
{
    protected ResponseDto _response;

    private IProuctRepository _productRepository;

    public ProductApiController(IProuctRepository productRepository)
    {
        _productRepository = productRepository;
        _response          = new ResponseDto();
    }

    // GET
    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var productDtos = await _productRepository.GetProducts();
            _response.Result = productDtos;
        }
        catch (Exception exception)
        {
            _response.IsSucces = false;
            _response.ErrorMessages = new List<string>()
                { exception.ToString() };
        }

        return _response;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            var productDto = await _productRepository.GetProduct(id);
            _response.Result = productDto;
        }
        catch (Exception exception)
        {
            _response.IsSucces = false;
            _response.ErrorMessages = new List<string>()
                { exception.ToString() };
        }

        return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            var model = await _productRepository.CreateUpdateDto(productDto);
            _response.Result = model;
        }
        catch (Exception exception)
        {
            _response.IsSucces = false;
            _response.ErrorMessages = new List<string>()
                { exception.ToString() };
        }

        return _response;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            var model = await _productRepository.CreateUpdateDto(productDto);
            _response.Result = model;
        }
        catch (Exception exception)
        {
            _response.IsSucces = false;
            _response.ErrorMessages = new List<string>()
                { exception.ToString() };
        }

        return _response;
    }

    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _productRepository.DeleteProduct(id);
            _response.Result = isSuccess;
        }
        catch (Exception exception)
        {
            _response.IsSucces = false;
            _response.ErrorMessages = new List<string>()
                { exception.ToString() };
        }

        return _response;
    }
}