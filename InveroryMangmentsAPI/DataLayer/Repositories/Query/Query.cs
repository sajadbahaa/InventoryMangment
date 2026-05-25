using DataLayer.Data;
using DataLayer.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Query
{
    public class Query<T> : IRead<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public Query(AppDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Pagination(int pageNumber, int pageSize)
        {
        return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public  IQueryable<T> QueryCustom(Expression<Func<T, bool>> predicate,bool AsNoTracking =false)
        {
            if (AsNoTracking)
            {
                return _dbSet.AsNoTracking().Where(predicate);
            }
            else
            {
                return _dbSet.Where(predicate);
            }

        }
    }
}
