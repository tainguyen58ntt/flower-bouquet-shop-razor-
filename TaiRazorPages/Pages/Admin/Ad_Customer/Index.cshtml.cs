using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace TaiRazorPages.Pages.Admin.Ad_Customer
{
    public class IndexModel : PageModel
    {
        //private readonly Model.Models.FUFlowerBouquetManagementContext _context;
        private ICustomerRepository customerRepository;


        //public IndexModel(Model.Models.FUFlowerBouquetManagementContext context)
        //{
        //    _context = context;
        //}

        public IndexModel()
        {
            customerRepository = new CustomerRepository();
        }
        //public IList<Customer> Customer { get;set; } = default!;
        public List<Customer> Customer { get; set; }

        public void OnGet()
        {

            Customer = customerRepository.GetCustomer();


        }
    }
}
