using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaiRazorPages.Pages.Admin
{
    public class Ad_LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            Console.WriteLine(HttpContext.Session.GetString("AdminEmail"));
            HttpContext.Session.Remove("AdminEmail");
            Console.WriteLine(HttpContext.Session.GetString("AdminEmail"));
            return  RedirectToPage("/Login");
        }
    }
}
