using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using ClassLibrary1.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Flower
{
    public class IndexModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private IFlowerRepository flowerRepository;

        //public IndexModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}
        public IndexModel()
        {
            flowerRepository = new FlowerRepository();
        }

        public IList<FlowerBouquet> FlowerBouquet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //if (_context.FlowerBouquets != null)
            //{
            //    FlowerBouquet = await _context.FlowerBouquets
            //    .Include(f => f.Category)
            //    .Include(f => f.Supplier).ToListAsync();
            //}
            FlowerBouquet = flowerRepository.GetFlowerBouquetsByStatus();
        }
    }
}
