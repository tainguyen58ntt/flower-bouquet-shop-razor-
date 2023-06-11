using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Customer
{
    public class EditModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private ICustomerRepository customerRepository;
        
        public EditModel()
        {
            customerRepository = new CustomerRepository();
        
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        [BindProperty]
        public string currentEmail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (HttpContext.Session.GetString("AdminEmail") == null)
            {

                HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Customer/Edit?id={id}");
                return RedirectToPage("/Login");
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }

                //var customer =  await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
                var customer = customerRepository.GetCustomerById(id);
                currentEmail = customer.Email;  

                if (customer == null)
                {
                    return NotFound();
                }
                Customer = customer;
                return Page();
            }

        }


    

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Customer).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CustomerExists(Customer.CustomerId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            string test = currentEmail;
            await Console.Out.WriteLineAsync(test);
            if (currentEmail != Customer.Email)
            {
               

				//check duplicate email
				bool checkEmailExists = customerRepository.CheckDuplicateEmail(Customer.Email);  // false: exists
				if (checkEmailExists == false)
				{

					// Duplicate email exists
					ViewData["ErrorEmail"] = "Email already exists. Please choose a different email.";
					return Page();


				}
				else
				{


					customerRepository.Update(Customer);
				}
			}
            else
            {
            customerRepository.Update(Customer);

            }


            return RedirectToPage("./Index");
        }

        //private bool CustomerExists(int id)
        //{
        //  return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        //}
    }
}
