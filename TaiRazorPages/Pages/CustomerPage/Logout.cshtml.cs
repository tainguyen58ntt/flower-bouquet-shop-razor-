using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaiRazorPages.Pages.CustomerPage
{
    public class LogoutModel : PageModel
    {
        //public void OnGet()
        //{
        //}
        public IActionResult OnGet()
        {
            Console.WriteLine(HttpContext.Session.GetString("CustomerId"));
            HttpContext.Session.Remove("CustomerId");
            Console.WriteLine(HttpContext.Session.GetString("CustomerId"));
            return RedirectToPage("/Login");
        }
    }
}
