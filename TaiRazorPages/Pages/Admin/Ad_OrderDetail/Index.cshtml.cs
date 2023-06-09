using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_OrderDetail
{
    public class IndexModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IOrderDetailRepository orderDetailRepository;
        private IOderRepository oderRepository;

        [BindProperty]
        public int OrId { get; set; }

        //public IndexModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}

        public IndexModel()
        {
        
            orderDetailRepository = new OrderDetailRepository();
            oderRepository = new OrderRepository(); 
        }

        public IList<OrderDetail> OrderDetail { get; set; } = default!;

        public async Task OnGetAsync()
        {
          
            ViewData["OrderId"] = new SelectList(oderRepository.GetIenumOrders(), "OrderId", "OrderId");
            OrderDetail = orderDetailRepository.GetOrderDetails();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["OrderId"] = new SelectList(oderRepository.GetIenumOrders(), "OrderId", "OrderId");

            OrderDetail = orderDetailRepository.GetOrderDetailsByOrderId(OrId);
            await Console.Out.WriteLineAsync(OrderDetail.ToString());
            return Page();
        }

    }
}
