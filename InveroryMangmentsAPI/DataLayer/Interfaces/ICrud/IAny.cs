using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.ICrud
{
    public interface IAny<T> where T:class
    {
        Task<bool> AnyAsync(Expression<Func<T,bool>> predicate);
    }
}
