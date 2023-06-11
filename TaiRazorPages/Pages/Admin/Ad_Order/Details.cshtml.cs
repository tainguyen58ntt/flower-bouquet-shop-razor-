using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Order
{
    public class DetailsModel : PageModel
    {


        private IOrderDetailRepository _orderDetailRepository;
        public List<OrderDetail> OrderDetails { get; set; }

        public DetailsModel()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        public IActionResult OnGet(int id)
        {
            if (HttpContext.Session.GetString("AdminEmail") == null)
            {

                HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Order/Details?id={id}");
                return RedirectToPage("/Login");
            }
            else
            {
                OrderDetails = _orderDetailRepository.GetOrderDetailsByOrderId(id);
                Console.WriteLine(OrderDetails);
                return Page();
            }

        }


        //  //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        //  private IOderRepository oderRepository;
        //  private IOrderDetailRepository orderDetailRepository;

        //  //public DetailsModel(Model.Models.FUFlowerBouquetManagementContext context)
        //  //{
        //  //    _context = context;
        //  //}
        //  public DetailsModel()
        //  {
        //      oderRepository = new OrderRepository();
        //      orderDetailRepository = new OrderDetailRepository();
        //  }

        //public Order Order { get; set; } = default!; 

        //  public async Task<IActionResult> OnGetAsync(int? id)
        //  {
        //      if (id == null)
        //      {
        //          return NotFound();
        //      }

        //      //var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
        //      var order = oderRepository.GetObjectByOrId(id);
        //      if (order == null)
        //      {
        //          return NotFound();
        //      }
        //      else 
        //      {
        //          Order = order;
        //      }
        //      return Page();
        //  }
    }
}
