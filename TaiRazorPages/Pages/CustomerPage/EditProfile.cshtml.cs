	using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.CustomerPage
{
    public class EditProfileModel : PageModel
    {
        private ICustomerRepository CustomerRepository;

        [BindProperty]
        public Customer CustomerObject { get; set; }
        private int cusiD;

        public EditProfileModel()
        {
            CustomerRepository = new CustomerRepository();
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("CustomerId") == null)
            {
                HttpContext.Session.SetString("ReturnUrl", "/CustomerPage/EditProfile");
                return RedirectToPage("/Login");
            }
            Console.WriteLine(cusiD);
            cusiD = (int)HttpContext.Session.GetInt32("CustomerId");

			CustomerObject = CustomerRepository.GetCustomerById(cusiD);
			return Page();	

		}

     


        public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				cusiD = (int)HttpContext.Session.GetInt32("CustomerId");
				CustomerObject.CustomerId = cusiD;
				//CustomerObject.CustomerId = Ultility.Class1.GenerateUniqueId();
				CustomerRepository.Update(CustomerObject);

				TempData["UpdateSuccess"] = "Update Success";

				return Page();


			}
			else
			{
				TempData["Updatefail"] = "Updatefail";
				return Page();
			}
		}
	}
}
