
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1.DataAccess
{
    public class OrderDetailManagement
    {
        private static OrderDetailManagement instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailManagement() { }
        public static OrderDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailManagement();
                    }
                    return instance;
                }
            }
        }

        //    //using singleton pattern

        public OrderDetail GetOrdersDetailByOrderIdAndFlId(int orderId, int flId)
        {
            OrderDetail orderDetails;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orderDetails = myStockDB.OrderDetails.SingleOrDefault(o => o.OrderId == orderId && o.FlowerBouquetId == flId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
        public List<OrderDetail> GetOrdersDetail()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orderDetails = myStockDB.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }
        public void Remmove(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail orderDetail1 = GetOrdersDetailByOrderIdAndFlId(orderDetail.OrderId, orderDetail.FlowerBouquetId);
                if (orderDetail1 != null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();

                    myStockDB.OrderDetails.Remove(orderDetail1);


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
        public List<OrderDetail> GetOrderDetailByOderId(int? orderdetailId)
        {
            List<OrderDetail> orderDetail = null;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                orderDetail = myStockDB.OrderDetails.Where(o => o.OrderId == orderdetailId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public decimal GetTotalBy(int orderdetailId)
        {
            decimal total = 0;
            int _quantity = 0;
            try
            {
                var myStockDB = new FUFlowerBouquetManagementContext();
                total = myStockDB.OrderDetails.Where(o => o.OrderId == orderdetailId).Sum(od => od.Quantity * od.UnitPrice);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return total;
        }


        public void Update(OrderDetail orderDetail)
        {
            try
            {
                //OrderDetail c = GetOrdersDetailByOrderIdAndFlId(orderDetail.OrderId, orderDetail.FlowerBouquetId);
                //if (c != null)
                //{
                var myStockDB = new FUFlowerBouquetManagementContext();
                myStockDB.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                myStockDB.SaveChanges();
                
                //}
                //else
                //{
                //    throw new Exception("The customer does already exist");
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //    //}
        ////

        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                //check 
                OrderDetail _orderDetail = GetOrdersDetailByOrderIdAndFlId(orderDetail.OrderId, orderDetail.FlowerBouquetId);
                if (_orderDetail == null)
                {
                    var myStockDB = new FUFlowerBouquetManagementContext();
                    myStockDB.OrderDetails.Add(orderDetail);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The flower is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

// check orderid exist and not have flid