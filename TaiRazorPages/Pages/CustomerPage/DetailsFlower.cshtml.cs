//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using Model.Models;

//namespace TaiRazorPages.Pages.Admin.Ad_Flower
//{
//    public class DetailsFlower : PageModel
//    {
//        private readonly Model.Models.FUFlowerBouquetManagementContext _context;

//        public DetailsFlower(Model.Models.FUFlowerBouquetManagementContext context)
//        {
//            _context = context;
//        }

//      public FlowerBouquet FlowerBouquet { get; set; } = default!; 

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null || _context.FlowerBouquets == null)
//            {
//                return NotFound();
//            }

//            var flowerbouquet = await _context.FlowerBouquets.FirstOrDefaultAsync(m => m.FlowerBouquetId == id);
//            if (flowerbouquet == null)
//            {
//                return NotFound();
//            }
//            else 
//            {
//                FlowerBouquet = flowerbouquet;
//            }
//            return Page();
//        }
//    }
//}
