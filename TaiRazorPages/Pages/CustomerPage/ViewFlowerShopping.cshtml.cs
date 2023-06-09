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

namespace TaiRazorPages.Pages.Admin.Ad_Flower
{
    public class ViewFlowerShopping : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IFlowerRepository flowerRepository;
        private ICategoryRepository categoryRepository;

            [BindProperty]
            public int SelectedCategory { get; set; }

        [BindProperty]
        public List<Category> CategoryList { get; set; }


        public ViewFlowerShopping()
        {
            
            flowerRepository = new FlowerRepository(); 
            categoryRepository = new CategoryRepository();  
        }

        public void OnPost()
        {
            // Access the selected category value
            CategoryList = categoryRepository.GetCategories();
            Console.WriteLine(SelectedCategory);
            if (SelectedCategory == 0)
            {
                FlowerBouquetObject = flowerRepository.GetFlowerBouquetsByStatus();

            }
            else
            {
                FlowerBouquetObject = flowerRepository.GetFlowerByCateIdAndStatus(SelectedCategory);
            }
            // Do something with the selected category value
            // For example, you can use it to perform further actions or save it to the database
        }
        public IList<FlowerBouquet> FlowerBouquetObject { get; set; } = default!;

        //public void  OnGet()
        //{
           
        //    CategoryList = categoryRepository.GetCategories();

        //    FlowerBouquetObject = flowerRepository.GetFlowerBouquetsByStatus();

          
        //    //if(SelectedCategory == 0)
        //    //{
        //    //FlowerBouquetObject = flowerRepository.GetFlowerBouquetsByStatus();

        //    //}
        //    //else
        //    //{
        //    //    FlowerBouquetObject = flowerRepository.GetFlowerByCateId(SelectedCategory);
        //    //}




        //}

        public IActionResult OnGet()
        {

            if (HttpContext.Session.GetInt32("CustomerId") == null)
            {
                HttpContext.Session.SetString("ReturnUrl", "/CustomerPage/ViewFlowerShopping");
                return RedirectToPage("/Login");
            }
            CategoryList = categoryRepository.GetCategories();

            FlowerBouquetObject = flowerRepository.GetFlowerBouquetsByStatus();

            return Page();  

            //if(SelectedCategory == 0)
            //{
            //FlowerBouquetObject = flowerRepository.GetFlowerBouquetsByStatus();

            //}
            //else
            //{
            //    FlowerBouquetObject = flowerRepository.GetFlowerByCateId(SelectedCategory);
            //}




        }
    }
}
