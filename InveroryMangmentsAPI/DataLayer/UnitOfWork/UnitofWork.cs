using DataLayer.Data;
using DataLayer.Exceptions;
using DataLayer.Interfaces.IRepository;
using DataLayer.Interfaces.IUnit;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public class UnitofWork : IUnitOfWork
    {
        readonly AppDbContext _dbContext;
        public ICategoryRepo CategoryRepository { get; }

        public IProductRepo ProductRepository { get; }

        public UnitofWork(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
            CategoryRepository = new CategoryRepository(_dbContext);
            ProductRepository = new ProductRepositiory(_dbContext);
        }
        public async Task<int> SaveChangesAsync()
        {
            try 
            {
                return await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateException ex) 
            {
                throw DbExceptions.Map(ex);
            }
                    }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return await SaveChangesAsync() > 0;
            }
            catch (DbUpdateException ex)
            {
                throw DbExceptions.Map(ex);
            }
        }
    }
}
