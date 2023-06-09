
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.DataAccess
{
    public class OrderManagement
    {
        private static OrderManagement instance = null;
        private static readonly object instanceLock = new object();
        private OrderManagement() { }
        public static OrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManagement();
                    }
                    return instance;
                }
            }
        }
        public Order GetOrderByOrId(Order order)
        {
            Order _oder;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                _oder = myStockDB.Orders.SingleOrDefault(or => or.OrderId == order.OrderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _oder;
        }
        //    //using singleton pattern
        //    ///
        public List<Order> GetOrdersByCustomerID(int customerID)
        {
            List<Order> orders;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orders = myStockDB.Orders.Where(o => o.CustomerId == customerID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public List<Order> GetOrders()
        {
            List<Order> orders;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orders = myStockDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public List<Order> GetOrdersByFill(DateTime? statDate, DateTime? endDate)
        {
            List<Order> orders;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orders = myStockDB.Orders.Where(o => o.OrderDate <= endDate && o.OrderDate >= statDate).OrderByDescending(o => o.Total).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public void UpdateTotal(Order order)
        {
            try
            {
                //FlowerBouquet c = GetByID(flowerBouquet.CustomerId);
                //if (c != null)
                //{
                var myStockDB = new FUFlowerBouquetManagementContext();
                myStockDB.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public void Update(Order order)
        {
            try
            {
                //FlowerBouquet c = GetByID(flowerBouquet.CustomerId);
                //if (c != null)
                //{
                var myStockDB = new FUFlowerBouquetManagementContext();
                myStockDB.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public void AddNew(Order order)
        {
            try
            {
                Order _cus = GetByID(order.OrderId);
                if (_cus == null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.Orders.Add(order);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Remmove(Order order)
        {
            try
            {
                Order _order = GetByID(order.OrderId);
                if (_order != null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.Orders.Remove(_order);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // check flower have orderdetail


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
        public Order GetByID(int? orderId)
        {
            Order order = null;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                order = myStockDB.Orders.SingleOrDefault(fl => fl.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }


        ////

        //public void AddNew(FlowerBouquet flowerBouquet)
        //{
        //    try
        //    {
        //        FlowerBouquet flower = GetByID(flowerBouquet.FlowerBouquetId);
        //        if (flower == null)
        //        {
        //            var myStockDB = new FUFlowerBouquetManagementContext();
        //            myStockDB.FlowerBouquets.Add(flowerBouquet);
        //            myStockDB.SaveChanges();
        //        }
        //        else
        //        {
        //            throw new Exception("The flower is already exist");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }

}
