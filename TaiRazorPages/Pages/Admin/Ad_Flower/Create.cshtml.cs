using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Repository;
using DataAccess.Repository.IRepository;
using DataAccess.Repository.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Flower
{
    public class CreateModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;

        private IFlowerRepository flowerRepository;
        private ICategoryRepository categoryRepository;
        private ISupplierRepository supplierRepository;
        //public CreateModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //    flowerRepository = new FlowerRepository();
        //    categoryRepository = new CategoryRepository();
        //}
        public CreateModel()
        {

            flowerRepository = new FlowerRepository();
            categoryRepository = new CategoryRepository();
            supplierRepository = new SupplierRepository();
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("AdminEmail") == null)
            {

                HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Flower/Create");
                return RedirectToPage("/Login");
            }
            else
            {

                ViewData["CategoryId"] = new SelectList(categoryRepository.GetIenumCategories(), "CategoryId", "CategoryName");
                ViewData["SupplierId"] = new SelectList(supplierRepository.GetIenumSupplier(), "SupplierId", "SupplierId");
                return Page();
            }

        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
        
            await Console.Out.WriteLineAsync(FlowerBouquet.ToString());

            //if (!ModelState.IsValid || _context.FlowerBouquets == null || FlowerBouquet == null)
            //{
            //    var error = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
            //    var errorMessage = error.ErrorMessage;
            //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            //    ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            //    return Page();
            //}
            //FlowerBouquet.FlowerBouquetId = Ultility.Class1.GenerateUniqueId();
            //_context.FlowerBouquets.Add(FlowerBouquet);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
            FlowerBouquet.FlowerBouquetId = Ultility.Class1.GenerateUniqueId();
            flowerRepository.InserFlower(FlowerBouquet);


            //if(!ModelState.IsValid)
            //{
            //    var error = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
            //    var errorMessage = error.ErrorMessage;
            //    return Page();
            //}
            //FlowerBouquet.FlowerBouquetId = Ultility.Class1.GenerateUniqueId();
            //flowerRepository.InserFlower(FlowerBouquet);
            return RedirectToPage("./Index");
        }
    }
}
