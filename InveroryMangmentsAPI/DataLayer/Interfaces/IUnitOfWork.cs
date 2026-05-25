using DataLayer.Interfaces.IRepository;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public  interface IUnitOfWork:IDisposable
    {
        ICategoryRepo CategoryRepository { get; }
        Task<int> SaveChangesAsync();
        Task<bool>CommitAsync();
    }
}
