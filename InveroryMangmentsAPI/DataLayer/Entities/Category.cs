using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public  class Category
    {
        public short Id { get; init; }
        public string Name { get; set; } = null!;
    }
}
