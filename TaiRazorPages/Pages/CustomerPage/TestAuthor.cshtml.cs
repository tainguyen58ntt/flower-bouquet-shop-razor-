using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TaiRazorPages.Pages.CustomerPage
{
    [Authorize]
    public class TestAuthorModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
