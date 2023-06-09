
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess
{
    public class SupplierManagement
    {
        private static SupplierManagement instance = null;
        private static readonly object instanceLock = new object();
        private SupplierManagement() { }
        public static SupplierManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SupplierManagement();
                    }
                    return instance;
                }
            }
        }

        //using singleton pattern
        ///
        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                suppliers = myStockDB.Suppliers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return suppliers;
        }
        public IEnumerable<Supplier> GetIenumSuppliers()
        {
            List<Supplier> suppliers;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                suppliers = myStockDB.Suppliers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return suppliers;
        }
    }
}
