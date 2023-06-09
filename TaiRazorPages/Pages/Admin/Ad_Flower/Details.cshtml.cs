using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Flower
{
    public class DetailsModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IFlowerRepository flowerRepository;

        //public DetailsModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public DetailsModel()
        {
            flowerRepository = new FlowerRepository();
        }

      public FlowerBouquet FlowerBouquet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var flowerbouquet = await _context.FlowerBouquets.FirstOrDefaultAsync(m => m.FlowerBouquetId == id);
            var flowerbouquet = flowerRepository.GetFlowerBouquetById(id);  
            if (flowerbouquet == null)
            {
                return NotFound();
            }
            else 
            {
                FlowerBouquet = flowerbouquet;
            }
            return Page();
        }
    }
}
