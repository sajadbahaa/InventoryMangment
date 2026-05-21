using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.IRepository
{
    public interface IAdd<T> where T:class
    {
        Task AddAsync(T entity);
    }
}
