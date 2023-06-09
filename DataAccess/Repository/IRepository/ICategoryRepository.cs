
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        IEnumerable<Category> GetIenumCategories();   
        Category GetCategoryById(int id);
    }
}
