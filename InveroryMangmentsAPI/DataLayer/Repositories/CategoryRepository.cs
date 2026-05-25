using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces.IRepository;
using DataLayer.Interfaces.UnitOfWork;
using DataLayer.Repositories.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository : Query<Category>, ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) :base(context)        
        {
            _context = context;
        }
        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public async Task<bool> DeleteAsync<T>(short id)
        {
            return await _context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync() > 0;
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }


    }


}
