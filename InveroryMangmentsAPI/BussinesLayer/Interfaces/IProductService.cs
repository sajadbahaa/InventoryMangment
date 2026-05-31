using DTOsLayer.Common.Request;
using DTOsLayer.Products.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Interfaces
{
    public interface IProductService:IPagination<GetProductDto>
    {
        public Task<GetProductDto> GetProductByIdAsync(ApiRequestID request);
        public Task<GetProductDto> GetProductByNameAsync(ApiRequestString request);
        public Task<bool> AddProductAsync(DTOsLayer.Products.Write.AddProductDto product);
        public Task<bool> UpdateProductAsync(DTOsLayer.Products.Write.UpdateProductDto product);
    }
}
