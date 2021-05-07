using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskurNortwindApi.Contexts;
using IskurNortwindApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IskurNortwindApi.Business
{
    public class CategoryBusiness : ICategoryService
    {
        private readonly NortwindContext _dbContext;

        public CategoryBusiness(NortwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        { 
            return  _dbContext.Set<Category>();
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.AsQueryable().Where(c => c.Id == id).First();
        }

        public Category Insert(Category category)
        {
            _dbContext.Set<Category>().Add(category);
            _dbContext.SaveChanges();
            return category;
        }
        public Category Update(Category category)
        {
            var foundCategory = _dbContext.Set<Category>().AsQueryable().Where(p => p.Id == category.Id).First();
        
            foundCategory.Description = category.Description;
            foundCategory.Name = category.Name;
            

            _dbContext.SaveChanges();
            return foundCategory;
        }

        public Category UpdateCategoryName(int id, string name)
        {
            var foundCategory = _dbContext.Set<Category>().AsQueryable().Where(p => p.Id == id).First();
            foundCategory.Name = name;
            _dbContext.SaveChanges();
            return foundCategory;
        }

        public int DeleteCategory(int id)
        {
            var foundCategory = _dbContext.Set<Category>().AsQueryable().Where(p => p.Id == id).First();
            _dbContext.Categories.Remove(foundCategory);
            var result = _dbContext.SaveChanges();
            return result;
        }

    }
}
