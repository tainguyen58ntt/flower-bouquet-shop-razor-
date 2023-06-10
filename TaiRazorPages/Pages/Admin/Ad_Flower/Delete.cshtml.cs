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
    public class DeleteModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IFlowerRepository flowerRepository;
        private IOrderDetailRepository orderDetailRepository;   

        //public DeleteModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public DeleteModel()
        {
            flowerRepository = new FlowerRepository();
            orderDetailRepository= new OrderDetailRepository(); 
        }

        [BindProperty]
      public FlowerBouquet FlowerBouquet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (HttpContext.Session.GetString("AdminEmail") == null)
            {

                HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Flower/Delete?id={id}");
                return RedirectToPage("/Login");
            }
            else
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var flowerbouquet = await _context.FlowerBouquets.FindAsync(id);
            var flowerbouquet = flowerRepository.GetFlowerBouquetById(id);

            if (flowerbouquet != null)
            {
                FlowerBouquet = flowerbouquet;
           

                flowerRepository.DeleteFlower(FlowerBouquet);
                
                // check in orderdetail or not

            }

            return RedirectToPage("./Index");
        }
    }
}
