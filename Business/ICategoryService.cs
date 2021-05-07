using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskurNortwindApi.Models;

namespace IskurNortwindApi.Business
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetById(int id);
        Category Insert(Category category);
        Category Update(Category category);
        int DeleteCategory(int id);
        Category UpdateCategoryName(int id, string name);
    }
}
