using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Models;
using Ultility;

namespace TaiRazorPages.Pages.CustomerPage
{
    public class CheckoutOrderModel : PageModel
    {
        private IOderRepository oderRepository = new OrderRepository();

        private IOrderDetailRepository orderDetailRepository = new OrderDetailRepository(); 

        private IFlowerRepository flowerRepository= new FlowerRepository(); 
        public Order OrderObject { get; set; }
        public OrderDetail OrderDetailObject { get; set; }
        public List<Item_manually> Cart { get; set; }
        public IActionResult OnGet(double total)
        {

            // insert order

            OrderObject = new Order();

            OrderObject.OrderId = Ultility.Class1.GenerateUniqueId();

            OrderObject.Total = (decimal?)total;
            OrderObject.OrderDate = DateTime.Now;
            OrderObject.CustomerId = (HttpContext.Session.GetInt32("CustomerId"));
            




            oderRepository.InsertOrder(OrderObject);

            // insert order

            // insert order detail
            //OrderDetailObject.OrderId = OrderObject.OrderId;
            Cart = HttpContext.Session.GetObjectFromJson<List<Item_manually>>("cart");
            foreach(Item_manually item in Cart)
            {
                OrderDetailObject = new OrderDetail();
                Console.WriteLine(item.FlowerBouquet.FlowerBouquetName);

                OrderDetailObject.OrderId = OrderObject.OrderId;
                OrderDetailObject.FlowerBouquetId = item.FlowerBouquet.FlowerBouquetId;
                OrderDetailObject.UnitPrice = item.FlowerBouquet.UnitPrice;
                OrderDetailObject.Quantity = item.Quantity;
                orderDetailRepository.InsertOrderDetail(OrderDetailObject);

                //update unitstock
                FlowerBouquet flowerBouquetUpdateQuantity = flowerRepository.GetFlowerBouquetById(item.FlowerBouquet.FlowerBouquetId);
                flowerBouquetUpdateQuantity.UnitsInStock = flowerBouquetUpdateQuantity.UnitsInStock - item.Quantity;

                flowerRepository.Update(flowerBouquetUpdateQuantity);

                //update unitstock

            }
            Console.WriteLine(Cart);

            // insert order detail
            TempData["Checkout"] = "Checkout success";
            HttpContext.Session.Remove("cart");
            return RedirectToPage("/CustomerPage/Index");

       
        }
    }
}
