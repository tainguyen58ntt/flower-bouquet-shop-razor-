using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Customer
{
    public class DeleteModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private ICustomerRepository customerRepository;

        //public DeleteModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //} 
        public DeleteModel()
        {
            customerRepository = new CustomerRepository();
        }

        [BindProperty]
      public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            var customer = customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var customer = await _context.Customers.FindAsync(id);
            var customer = customerRepository.GetCustomerById(id);
            if (customer != null)
            {
                Customer = customer;
                //_context.Customers.Remove(Customer);
                //await _context.SaveChangesAsync();
                customerRepository.DeleteCustomer(Customer);
            }

            return RedirectToPage("./Index");
        }
    }
}
