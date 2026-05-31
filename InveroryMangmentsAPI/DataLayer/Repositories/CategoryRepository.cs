using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces.IRepository;
using DataLayer.Repositories.Crud;
using DataLayer.Repositories;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository : AddUpdateReadAny<Category>, ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) :base(context)        
        {
            _context = context;
        }
        public async Task<bool> DeleteAsync<T>(short id)
        {
            return await _context.Categories.Where(x => x.Id == id).ExecuteDeleteAsync() > 0;
        }
    }


}
