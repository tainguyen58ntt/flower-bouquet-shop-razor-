using ClassLibrary1.DataAccess;
using DataAccess.Repository.IRepository;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.RepositoryImpl
{
    public class SupplierRepository : ISupplierRepository
    {
        public IEnumerable<Supplier> GetIenumSupplier()
        {
           return SupplierManagement.Instance.GetIenumSuppliers();
        }
    }
}
