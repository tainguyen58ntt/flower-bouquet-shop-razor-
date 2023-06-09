using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;
using System.ComponentModel.DataAnnotations;

namespace TaiRazorPages.Pages
{
    public class LoginModel : PageModel
    {
		private ICustomerRepository CustomerRepository;

        private readonly IConfiguration _configuration;

        public class Login {
            [Required]
            public string Email { get; set; }

			[Required]
            
			public string Password { get; set; }
		}

        [BindProperty]
        public Login InputLogin { get; set; }
        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
            CustomerRepository = new CustomerRepository();
        }
		public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            string email = _configuration["Admin:Email"];
            string password = _configuration["Admin:Password"];       
            if (ModelState.IsValid)
            {
                if(InputLogin.Email.Equals(email) && InputLogin.Password.Equals(password))
                {
                    HttpContext.Session.SetString("AdminEmail", email);

                    return RedirectToPage("/Admin/Ad_Customer/Index");
                } 
                Customer checkLogin =  CustomerRepository.CheckLogin(InputLogin.Email, InputLogin.Password);
            
                if(checkLogin != null) {

                    var returnUrl = HttpContext.Session.GetString("ReturnUrl");
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        // Clear the return URL from the session
                        HttpContext.Session.Remove("ReturnUrl");
                        HttpContext.Session.SetInt32("CustomerId", checkLogin.CustomerId);
                        // Redirect to the stored return URL
                        return Redirect(returnUrl);
                    }
                    Console.WriteLine("customer");
                    HttpContext.Session.SetInt32("CustomerId", checkLogin.CustomerId);
                    return RedirectToPage("/CustomerPage/Index");
                }
                ModelState.AddModelError(string.Empty, "Incorrect account form submission");
                

            }
            return Page();
        }


    }
}
