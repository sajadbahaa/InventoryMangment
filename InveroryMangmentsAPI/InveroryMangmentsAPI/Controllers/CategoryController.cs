using BussinesLayer.Interfaces;
using DTOsLayer.Categories.Read;
using DTOsLayer.Categories.Write;
using DTOsLayer.Common;
using DTOsLayer.Common.Pagination;
using DTOsLayer.Common.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shared.Common.ApiResponse;

namespace InveroryMangmentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : SuccessApiResponse
    {
        private readonly ICategoyService _categoryService;
        public CategoryController(ICategoyService categoryService) 
        {
            _categoryService = categoryService;
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetCategories([FromQuery]Pagination request)
        {
            var categories = await _categoryService.Pagination(request);
            return OKResponse(categories);
        }
        [HttpGet("query/id")]
         public async Task<IActionResult> GetById([FromQuery] ApiRequestID request) 
        {
            GetCategoeyDto data = await _categoryService.GetCategoryByIdAsync( request);
            return OKResponse(data);
        }
        [HttpGet("query/name")]
        public async Task<IActionResult> GetByName([FromQuery] ApiRequestString request)
        {
            var data = await _categoryService.GetCategoryByNameAsync(request);
            return OKResponse(data);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDto category)
        {
            await _categoryService.AddCategoryAsync(category);
            return NotContentResponse();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto category)
        {
            await _categoryService.UpdateCategoryAsync(category);
            
            return NotContentResponse();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory([FromQuery] ApiRequestID request)
        {
            await _categoryService.DeleteCategoryAsync(request);
            return NotContentResponse();
        }
            
    }
}
