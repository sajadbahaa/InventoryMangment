using DataLayer.Interfaces.IRepository;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.IUnit
{
    public  interface IUnitOfWork:IDisposable
    {
        ICategoryRepo CategoryRepository { get; }
        IProductRepo ProductRepository { get; }
        Task<int> SaveChangesAsync();
        Task<bool>CommitAsync();
    }
}
