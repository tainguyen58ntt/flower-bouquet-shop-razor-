using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;

namespace TaiRazorPages.Pages.CustomerPage
{
    public class IndexModel : PageModel
    {

        
        private ICustomerRepository customerRepository;
        public Customer CustomerObject { get; set; }
        int cusiD;

        public IndexModel()
        {
            
			customerRepository = new CustomerRepository();

			//CustomerObject = (Customer?)_context.Customers.Where(c => c.CustomerId == cusiD);
		}
        //public void OnGet()
        //{
        //    cusiD = (int)HttpContext.Session.GetInt32("CustomerId");
        //    CustomerObject = customerRepository.GetCustomerById(cusiD);


        //}
            public IActionResult OnGet()
            {
                if(HttpContext.Session.GetInt32("CustomerId") == null)
                {

                    HttpContext.Session.SetString("ReturnUrl", "/CustomerPage/Index");
                    return RedirectToPage("/Login");
                }
                cusiD = (int)HttpContext.Session.GetInt32("CustomerId");    
                CustomerObject = customerRepository.GetCustomerById(cusiD);
                return Page();

            }
    }
}
