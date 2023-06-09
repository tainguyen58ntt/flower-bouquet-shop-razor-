using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;
using static TaiRazorPages.Pages.LoginModel;

namespace TaiRazorPages.Pages
{
    public class RegisterModel : PageModel
    {

        private ICustomerRepository CustomerRepository;

        [BindProperty]
		public Customer CustomerObject { get; set; }
        public RegisterModel()
        {
            CustomerRepository = new CustomerRepository();  
        }
		public void OnGet()
        {
        }
       

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                CustomerObject.CustomerId = Ultility.Class1.GenerateUniqueId(); 
				CustomerRepository.InsertCustomer(CustomerObject);
                
                TempData["RegisterNoti"] = "Register Success";

                return RedirectToPage("/Login");


			}
            else
            {
                return Page();
            }
        }
    }
}
