using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Order
{
    public class DeleteModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IOderRepository orderRepository;

        //public DeleteModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public DeleteModel()
        {
            orderRepository = new OrderRepository();    
        }

        [BindProperty]
      public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (HttpContext.Session.GetString("AdminEmail") == null)
            {

                HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Order/Delete?id={id}");
                return RedirectToPage("/Login");
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }

                //var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
                var order = orderRepository.GetObjectByOrId(id);

                if (order == null)
                {
                    return NotFound();
                }
                else
                {
                    Order = order;
                }
                return Page();
            }
        
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var order = await _context.Orders.FindAsync(id);
            var order = orderRepository.GetObjectByOrId(id);

            if (order != null)
            {
                Order = order;
                //_context.Orders.Remove(Order);
                orderRepository.DeleOrder(Order);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
