using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.UnitOfWork
{
    public interface IRead<T> where T:class
    {
        public IQueryable<T> QueryCustom(Expression<Func<T, bool>> predicate,bool AsNoTracking = false);

    }
}
