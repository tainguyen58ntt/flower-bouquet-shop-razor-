
using ClassLibrary1.DataAccess;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface IOrderDetailRepository
    {

        List<OrderDetail> GetOrderDetails();

        //List<OrderDetail> GetOrdersByCustomerID(int customerID);
       

        List<OrderDetail> GetOrderDetailsByOrderId(int? orderId);
        OrderDetail GetOrderDetailByOderIdAndFlId(OrderDetail orderDetail); 
        void DeleteOrderDetail(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void InsertOrderDetail(OrderDetail orderDetail);
        decimal GetTotalSumOrderDetail(int _orderId);
    }
}
