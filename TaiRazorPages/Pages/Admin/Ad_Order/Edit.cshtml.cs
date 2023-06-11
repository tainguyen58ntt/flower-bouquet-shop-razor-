using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Order
{
    public class EditModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;

        private IOderRepository orderRepository;
        private ICustomerRepository customerRepository;

        //public EditModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public EditModel()
        {
            orderRepository = new OrderRepository();
            customerRepository = new CustomerRepository();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (HttpContext.Session.GetString("AdminEmail") == null)
            {

                HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Order/Edit?id={id}");
                return RedirectToPage("/Login");
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }

                //var order =  await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
                var order = orderRepository.GetObjectByOrId(id);
                if (order == null)
                {
                    return NotFound();
                }
                Order = order;
                ViewData["CustomerId"] = new SelectList(customerRepository.GetIenumCustomers(), "CustomerId", "City");
                return Page();
            }


          
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Order).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrderExists(Order.OrderId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            Order.OrderId = id;
            await Console.Out.WriteLineAsync(Order.ToString());

            orderRepository.Update(Order);
            return RedirectToPage("./Index");
        }

        //private bool OrderExists(int id)
        //{
        //  return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        //}
    }
}
