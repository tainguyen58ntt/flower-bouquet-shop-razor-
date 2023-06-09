
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess
{
    public class CustomerManagement
    {
        private static CustomerManagement instance = null;
        private static readonly object instanceLock = new object();
        private CustomerManagement() { }
        public static CustomerManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerManagement();
                    }
                    return instance;
                }
            }
        }
        public List<Customer> GetCustomerByEmail(string email)
        {
            List<Customer> customers;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                customers = myStockDB.Customers.Where(c => c.Email == email).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }
        //using singleton pattern
        ///
        public List<Customer> GetCustomers()
        {
            List<Customer> customers;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                customers = myStockDB.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }
        public IEnumerable<Customer> GetIeumCustomers()
        {
            List<Customer> customers;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                customers = myStockDB.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customers;
        }

        public Customer GetByEmailAndPass(string email, string password)
        {
            Customer customer = null;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                customer = myStockDB.Customers.SingleOrDefault(cus => cus.Email == email && cus.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        ///
        public Customer GetByID(int? cusId)
        {
            Customer customer = null;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                customer = myStockDB.Customers.SingleOrDefault(cus => cus.CustomerId == cusId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }
        //

        public void AddNew(Customer customer)
        {
            try
            {
                Customer _cus = GetByID(customer.CustomerId);
                if (_cus == null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.Customers.Add(customer);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Customer customer)
        {
            try
            {
                Customer c = GetByID(customer.CustomerId);
                if (c != null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //}
        public void Remmove(Customer customer)
        {
            try
            {
                Customer cus = GetByID(customer.CustomerId);
                if (cus != null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.Customers.Remove(cus);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The customer does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}


