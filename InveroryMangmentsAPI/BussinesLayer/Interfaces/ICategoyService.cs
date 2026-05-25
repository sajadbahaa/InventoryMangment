using DTOsLayer.Categories.Read;
using DTOsLayer.Common.Pagination;
using DTOsLayer.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public  interface ICategoyService
    {
     Task<ICollection<GetCategoeyDto>>Pagination(Pagination request);
     Task<GetCategoeyDto> GetCategoryByIdAsync(ApiRequestID request);
     Task<GetCategoeyDto> GetCategoryByNameAsync(ApiRequestString request);
     Task<bool>AddCategoryAsync(DTOsLayer.Categories.Write.AddCategoryDto category);
     Task<bool> UpdateCategoryAsync(DTOsLayer.Categories.Write.UpdateCategoryDto category);
     Task<bool> DeleteCategoryAsync(ApiRequestID request);

    }
}
