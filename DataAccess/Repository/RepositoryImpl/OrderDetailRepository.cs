
using ClassLibrary1.DataAccess;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository

    {
        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailManagement.Instance.Remmove(orderDetail);
        }

        public OrderDetail GetOrderDetailByOderIdAndFlId(OrderDetail orderDetail)
        {
            return OrderDetailManagement.Instance.GetOrdersDetailByOrderIdAndFlId(orderDetail.OrderId, orderDetail.FlowerBouquetId);
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailManagement.Instance.GetOrdersDetail();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int? orderId)
        {
            return OrderDetailManagement.Instance.GetOrderDetailByOderId(orderId);
        }

        public decimal GetTotalSumOrderDetail(int _orderId)
        {
            decimal rs = 0;
            //List<OrderDetail> orderDetails = OrderDetailManagement.Instance.GetOrderDetailByOderId(orderDetail.OrderId);
            return rs = OrderDetailManagement.Instance.GetTotalBy(_orderId);
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailManagement.Instance.AddNew(orderDetail);
        }

        //public List<OrderDetail> GetOrdersByCustomerID(int customerID)
        //{
        //    return OrderDetailManagement.Instance.GetOrdersByCustomerID(customerID);
        //}

        public void Update(OrderDetail orderDetail) => OrderDetailManagement.Instance.Update(orderDetail);

    }
}
