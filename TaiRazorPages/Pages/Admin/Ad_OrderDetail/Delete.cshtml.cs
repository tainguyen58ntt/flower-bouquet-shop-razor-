using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_OrderDetail
{
    public class DeleteModel : PageModel
    {
        private readonly Model.Models.FUFlowerBouquetManagementContext _context;

        public DeleteModel(Model.Models.FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public OrderDetail OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(m => m.OrderId == id);

            if (orderdetail == null)
            {
                return NotFound();
            }
            else 
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.OrderDetails == null)
            {
                return NotFound();
            }
            var orderdetail = await _context.OrderDetails.FindAsync(id);

            if (orderdetail != null)
            {
                OrderDetail = orderdetail;
                _context.OrderDetails.Remove(OrderDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
