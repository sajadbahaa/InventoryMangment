using BussinesLayer.Interfaces;
using DTOsLayer.Common.Pagination;
using DTOsLayer.Common.Request;
using DTOsLayer.Products.Read;
using DTOsLayer.Products.Write;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.ApiResponse;

namespace InveroryMangmentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController: SuccessApiResponse
    {
    private readonly IProductService _productService;
    public ProductController(IProductService productService) 
        {
            _productService = productService;
        }
        [HttpGet("query/")]
        public async Task<IActionResult> GetById([FromQuery] ApiRequestID request)
        {
            GetProductDto data = await _productService.GetProductByIdAsync(request);
            return OKResponse(data);
            ;
        }
        [HttpGet("query/name")]
        public async Task<IActionResult> GetByName([FromQuery] ApiRequestString request)
        {
            GetProductDto data = await _productService.GetProductByNameAsync(request);
            return OKResponse(data);
        }
         [HttpPost("Add")]
         public async Task<IActionResult> AddProduct([FromBody] AddProductDto product) 
        {
            await _productService.AddProductAsync(product);
            return NotContentResponse();
        }
         [HttpPut("Update")]
         public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto product)
        {
            await _productService.UpdateProductAsync(product);
            return NotContentResponse();
        }       
            [HttpGet("Pagination")]
            public async Task<IActionResult> GetProducts([FromQuery] Pagination request)
            {
                var products = await _productService.Pagination(request);
                return OKResponse(products);
        }

    }
}
