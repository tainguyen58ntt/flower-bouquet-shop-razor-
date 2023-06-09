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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    var error = ModelState.Values.SelectMany(v => v.Errors).FirstOrDefault();
            //    var errorMessage = error.ErrorMessage;
            //    return Page();
            //}

            //_context.Attach(FlowerBouquet).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FlowerBouquetExists(FlowerBouquet.FlowerBouquetId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
            FlowerBouquet.FlowerBouquetId = id;
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
            //FlowerBouquet.FlowerBouquetId = Ultility.Class1.GenerateUniqueId();
            
            flowerRepository.Update(FlowerBouquet);


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

        //private bool FlowerBouquetExists(int id)
        //{
        //  return (_context.FlowerBouquets?.Any(e => e.FlowerBouquetId == id)).GetValueOrDefault();
        //}
    }
}
