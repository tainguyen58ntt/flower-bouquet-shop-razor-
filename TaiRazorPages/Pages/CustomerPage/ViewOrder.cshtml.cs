using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;
using System;

namespace TaiRazorPages.Pages.CustomerPage
{
    public class ViewOrderModel : PageModel
    {
        private IOderRepository OderRepository;
        private int cusiD;

        [BindProperty]
        public IList<Order> Order { get; set; } = default!;

        public ViewOrderModel()
        {
            OderRepository = new OrderRepository(); 
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("CustomerId") == null)
            {
                HttpContext.Session.SetString("ReturnUrl", "/CustomerPage/ViewOrder");
                return RedirectToPage("/Login");
            }
            cusiD = (int)HttpContext.Session.GetInt32("CustomerId");
            Order =  OderRepository.GetOrdersByCustomerID(cusiD);
            return Page();
        }

        //public void OnGet()
        //{

        //    cusiD = (int)HttpContext.Session.GetInt32("CustomerId");
        //    Order = OderRepository.GetOrdersByCustomerID(cusiD);
        //}
    }
}
