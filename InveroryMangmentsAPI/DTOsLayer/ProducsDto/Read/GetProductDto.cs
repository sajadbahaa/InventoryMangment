using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Products.Read
{
    public class GetProductDto
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; } = null!;
        public decimal PurchasePrice { get; init; }
        public decimal SalePrice { get; init; }
    }
}
