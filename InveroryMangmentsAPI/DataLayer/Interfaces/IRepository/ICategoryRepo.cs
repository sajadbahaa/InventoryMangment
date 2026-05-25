using DataLayer.Entities;
using DataLayer.Interfaces.UnitOfWork;
using DataLayer.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.IRepository
{
    public  interface ICategoryRepo  : IAdd<Category>, IUpdate<Category>, IRead<Category>,IDeleteExtension<short>
    {
    }
}
