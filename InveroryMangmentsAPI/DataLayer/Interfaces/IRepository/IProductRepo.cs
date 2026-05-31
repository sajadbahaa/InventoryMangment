using DataLayer.Entities;
using DataLayer.Interfaces.ICrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.IRepository
{
    public  interface IProductRepo: IAddUpdateReadAny<Products>
    {
    }
}
