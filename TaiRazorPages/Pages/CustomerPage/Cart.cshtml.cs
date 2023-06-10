using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ultility;
using Ultility;
namespace TaiRazorPages.Pages.CustomerPage
{
    public class CartModel : PageModel
    {
        public List<Item_manually>? cart { get; set; }

        private IFlowerRepository flowerRepository = new FlowerRepository();
        public double? Total { get; set; }

        public IActionResult OnGet()
        {
            //cart = SessionHelper.GetObjectFromJson<List<Item_manually>>(HttpContext.Session, "cart");

            //Total = (double)cart.Sum(i => i.FlowerBouquet.UnitPrice * i.Quantity);

            if (HttpContext.Session.GetInt32("CustomerId") == null)
            {
                HttpContext.Session.SetString("ReturnUrl", "/CustomerPage/Cart");
                return RedirectToPage("/Login");
            }
            else
            {

                cart = SessionHelper.GetObjectFromJson<List<Item_manually>>(HttpContext.Session, "cart");

                if (cart != null)
                {
                    Total = (double)cart.Sum(i => i.FlowerBouquet.UnitPrice * i.Quantity);
                }
                else
                {
                    Total = 0; // Or any default value you prefer
                }
                return Page();
            }


        }

        public IActionResult OnGetBuyNow(int? id)
        {
            //var productModel = new ProductList();
            var productModel = flowerRepository.GetFlowerBouquetsByStatus();
            cart = SessionHelper.GetObjectFromJson<List<Item_manually>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item_manually>();
                cart.Add(new Item_manually
                {
                    FlowerBouquet = flowerRepository.GetFlowerBouquetById(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item_manually
                    {
                        FlowerBouquet = flowerRepository.GetFlowerBouquetById(id),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }
        private int Exists(List<Item_manually> cart, int? id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].FlowerBouquet.FlowerBouquetId == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult OnGetDelete(int? id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item_manually>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item_manually>>(HttpContext.Session, "cart");
            for (var i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }



    }
}
