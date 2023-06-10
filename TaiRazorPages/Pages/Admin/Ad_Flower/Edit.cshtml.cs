using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using ClassLibrary1.Repository;
using DataAccess.Repository.IRepository;
using DataAccess.Repository.RepositoryImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Flower
{
    public class EditModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IFlowerRepository flowerRepository;
        private ICategoryRepository categoryRepository;
        private ISupplierRepository supplierRepository;
        private int Flid;

        public EditModel()
        {
            
            flowerRepository = new FlowerRepository();
            categoryRepository = new CategoryRepository();
            supplierRepository = new SupplierRepository();
        }

        [BindProperty]
        public FlowerBouquet FlowerBouquet { get; set; } = default!;
        //public async Task<IActionResult> OnGetAsync(int? id)
        //{

        //    if (HttpContext.Session.GetString("AdminEmail") == null)
        //    {

        //        HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Customer/Edit?id={id}");
        //        return RedirectToPage("/Login");
        //    }
        //    else
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        //var customer =  await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
        //        var customer = customerRepository.GetCustomerById(id);
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }
        //        Customer = customer;
        //        return Page();
        //    }

        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
          
                if (HttpContext.Session.GetString("AdminEmail") == null)
                {

                    HttpContext.Session.SetString("ReturnUrl", $"/Admin/Ad_Flower/Edit?id={id}");
                    return RedirectToPage("/Login");
                }
                else
                {
                    if (id == null)
                    {
                        return NotFound();
                    }


                    //var flowerbouquet =  await _context.FlowerBouquets.FirstOrDefaultAsync(m => m.FlowerBouquetId == id);
                    var flowerbouquet = flowerRepository.GetFlowerBouquetById(id);
                    if (flowerbouquet == null)
                    {
                        return NotFound();
                    }
                    FlowerBouquet = flowerbouquet;
                    //Flid = FlowerBouquet.FlowerBouquetId;
                    ViewData["CategoryId"] = new SelectList(categoryRepository.GetIenumCategories(), "CategoryId", "CategoryName");
                    ViewData["SupplierId"] = new SelectList(supplierRepository.GetIenumSupplier(), "SupplierId", "SupplierId");
                    return Page();
                }

            



        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
         
            //return RedirectToPage("./Index");
            FlowerBouquet.FlowerBouquetId = id;
            await Console.Out.WriteLineAsync(FlowerBouquet.ToString());

            
            flowerRepository.Update(FlowerBouquet);


            return RedirectToPage("./Index");
        }

    }
}
