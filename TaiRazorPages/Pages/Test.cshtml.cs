using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;

namespace TaiRazorPages.Pages
{
    public class TestModel : PageModel
    {

        private FUFlowerBouquetManagementContext _db;
        public string Name { get; set; }
        public TestModel(FUFlowerBouquetManagementContext db)
        {
            _db = db;   
        }
        public void OnGet()
        {
          

        }
    }
}
