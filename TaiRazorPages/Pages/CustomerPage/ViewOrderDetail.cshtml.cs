using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;

namespace TaiRazorPages.Pages.CustomerPage
{
    public class ViewOrderDetailModel : PageModel
    {

        private IOrderDetailRepository _orderDetailRepository;
        public List<OrderDetail> OrderDetails { get; set; }

        public ViewOrderDetailModel()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }
        public void OnGet(int id)
        {
            OrderDetails = _orderDetailRepository.GetOrderDetailsByOrderId(id);
            Console.WriteLine(OrderDetails);
        }
    }
}
