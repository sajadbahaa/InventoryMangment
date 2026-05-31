using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Products
    {
    public int ProductId { get; init; }
    public string ProductName { get; set; } = null!;
    public short CategoryId { get; init; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public Category Category { get; set; } = null!;
    }
}
