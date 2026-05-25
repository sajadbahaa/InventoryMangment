using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.IRepository
{
    public interface IUpdate<T> where T : class
    {
        void Update(T entity);
    }
}
