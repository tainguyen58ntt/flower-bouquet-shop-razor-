using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Order
{
    public class IndexModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;

        private IOderRepository oderRepository;

        [BindProperty]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [Compare(nameof(StartDate), ErrorMessage = "End Date cannot be earlier than Start Date.")]
        public DateTime EndDate { get; set; }


        //public IndexModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public IndexModel()
        {
            oderRepository = new OrderRepository();
            Order = oderRepository.GetOrders();
        }

        public List<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            //if (_context.Orders != null)
            //{
            //    Order = await _context.Orders
            //    .Include(o => o.Customer).ToListAsync();
       
            Order = oderRepository.GetOrders();

        }

        public IActionResult OnPostFill()
        {
            //DateTime min = new DateTime(1751, 1, 1);
            //DateTime max = new DateTime(1751, 1, 1);
            //int rsMin = DateTime.Compare(StartDate, min);
            //int rsMax = DateTime.Compare(EndDate, min);

            //if (StartDate > EndDate)
            //{
            //    ModelState.AddModelError(string.Empty, "Start Date cannot be later than End Date.");
            //    //return Page();
            //}
            if (StartDate > EndDate)
            {
                ModelState.AddModelError(string.Empty, "Start Date must be earlier than or equal to End Date.");
                return Page();
            }
          
            Order = oderRepository.GetOrdersAfterFill(StartDate, EndDate);
            
            return Page();
            //return null;
        }
        public void OnPostView(int id)
        {
            Console.WriteLine(id);
        }

    }
}
