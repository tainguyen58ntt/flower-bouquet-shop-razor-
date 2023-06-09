using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Customer
{
    public class CreateModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private ICustomerRepository customerRepository;

        //public CreateModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public CreateModel()
        {
            customerRepository = new CustomerRepository();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (ModelState.IsValid )
            {
                Customer.CustomerId = Ultility.Class1.GenerateUniqueId();
                customerRepository.InsertCustomer(Customer);
            }
          
            return RedirectToPage("./Index");
        }
    }
}
