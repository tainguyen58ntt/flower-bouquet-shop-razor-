
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess
{
    public class FlowerManagement
    {

        private static FlowerManagement instance = null;
        private static readonly object instanceLock = new object();
        private FlowerManagement() { }
        public static FlowerManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FlowerManagement();
                    }
                    return instance;
                }
            }
        }
        public void AddNew(FlowerBouquet flowerBouquet)
        {
            try
            {
                //FlowerBouquet flower = GetByID(flowerBouquet.FlowerBouquetId);
                //if (flower == null)
                //{
                var myStockDB = new FUFlowerBouquetManagementContext();
                myStockDB.FlowerBouquets.Add(flowerBouquet);
                myStockDB.SaveChanges();
                //}
                //else
                //{
                //    throw new Exception("The flower is already exist");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(FlowerBouquet flowerBouquet)
        {
            try
            {
                //FlowerBouquet c = GetByID(flowerBouquet.CustomerId);
                //if (c != null)
                //{
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.Entry<FlowerBouquet>(flowerBouquet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    myStockDB.SaveChanges();
                //}
                //else
                //{
                //    throw new Exception("The customer does not already exist");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //    //using singleton pattern
        //    ///
        public List<FlowerBouquet> GetFlowerBouquetsByName(string name)
        {
            List<FlowerBouquet> flowerBouquets;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                flowerBouquets = myStockDB.FlowerBouquets.Where(fl => fl.FlowerBouquetName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flowerBouquets;
        }
        public List<FlowerBouquet> GetFlowerByCateIdAndStatus(int cateid)
        {
            List<FlowerBouquet> flowerBouquets;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                flowerBouquets = myStockDB.FlowerBouquets.Where(fl => fl.CategoryId == cateid && fl.FlowerBouquetStatus == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flowerBouquets;
        }
        public List<FlowerBouquet> GetFlowerBouquetsByStatus()
        {
            List<FlowerBouquet> flowerBouquets;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                flowerBouquets = myStockDB.FlowerBouquets.Where(fl => fl.FlowerBouquetStatus == 1).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flowerBouquets;
        }
        public List<FlowerBouquet> GetFlowerBouquets()
        {
            List<FlowerBouquet> flowerBouquets;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                flowerBouquets = myStockDB.FlowerBouquets.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flowerBouquets;
        }

        public FlowerBouquet GetFlowerByFlID(FlowerBouquet flowerBouquet)
        {
            FlowerBouquet _flowerBouquet;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                _flowerBouquet = myStockDB.FlowerBouquets.SingleOrDefault(fl => fl.FlowerBouquetId == flowerBouquet.FlowerBouquetId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _flowerBouquet;
        }

        public FlowerBouquet GetFlowerByFlID(int? id)
        {
            FlowerBouquet _flowerBouquet;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                _flowerBouquet = myStockDB.FlowerBouquets.SingleOrDefault(fl => fl.FlowerBouquetId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _flowerBouquet;
        }

        // check flower have orderdetail
        public bool checkFlowerInOrderDetail(int flId)
        {
            List<OrderDetail> orderDetailList = null;

            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orderDetailList = myStockDB.OrderDetails.ToList();
                List<OrderDetail> orderDetailCheck = orderDetailList.Where(c => c.FlowerBouquetId == flId).ToList();
                if (orderDetailCheck != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        // check flower have orderdetail

        //    public Customer GetByEmailAndPass(string email, string password)
        //    {
        //        Customer customer = null;
        //        try
        //        {
        //            var myStockDB = new FUFlowerBouquetManagementContext();
        //            customer = myStockDB.Customers.SingleOrDefault(cus => cus.Email == email && cus.Password == password);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return customer;
        //    }
        //    ///
        public FlowerBouquet GetByID(int flId)
        {
            FlowerBouquet flowerBouquet = null;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                flowerBouquet = myStockDB.FlowerBouquets.SingleOrDefault(fl => fl.FlowerBouquetId == flId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flowerBouquet;
        }
        //

      


        //    public void Update(Customer customer)
        //    {
        //        try
        //        {
        //            Customer c = GetByID(customer.CustomerId);
        //            if (c != null)
        //            {
        //                var myStockDB = new FUFlowerBouquetManagementContext();
        //                myStockDB.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //                myStockDB.SaveChanges();
        //            }
        //            else
        //            {
        //                throw new Exception("The customer does not already exist");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //    }

        //    //}
        public bool Remmove(FlowerBouquet flowerBouquet)
        {
            try
            {
                FlowerBouquet flower = GetByID(flowerBouquet.FlowerBouquetId);
                if (flower != null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    if (!checkFlowerInOrderDetail(flowerBouquet.FlowerBouquetId))
                    {
                        myStockDB.FlowerBouquets.Remove(flowerBouquet);
                        myStockDB.SaveChanges();
                        return true;

                    }
                    else
                    {
                        flowerBouquet.FlowerBouquetStatus = 0;
                        myStockDB.FlowerBouquets.Update(flowerBouquet);
                        myStockDB.SaveChanges();
                        return false;
                    }
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
            return false;

        }
        //}
    }
}
