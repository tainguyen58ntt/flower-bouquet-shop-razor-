
using ClassLibrary1.DataAccess;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        public List<Category> GetCategories()
        {
            return CategoryManagement.Instance.GetCategories();
        }

        public Category GetCategoryById(int id)
        {
            return CategoryManagement.Instance.GetByID(id);
        }

        public IEnumerable<Category> GetIenumCategories()
        {
            return CategoryManagement.Instance.GetIenumCategories();
        }
    }
}
