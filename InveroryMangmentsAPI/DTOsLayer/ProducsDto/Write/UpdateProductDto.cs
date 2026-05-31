using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Products.Write
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }  
        public string ProductName { get; set; } = null!;
        public short CategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
