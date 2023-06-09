
using ClassLibrary1.DataAccess;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class OrderRepository : IOderRepository
    {
        public void DeleOrder(Order order)
        {
            OrderManagement.Instance.Remmove(order);    
        }

        public Order GetObjectByOrId(Order order)
        {
            return OrderManagement.Instance.GetOrderByOrId(order);
        }
        public Order GetObjectByOrId(int? orderId)
        {
            return OrderManagement.Instance.GetByID(orderId);
        }
        public List<Order> GetOrders()
        {
            return OrderManagement.Instance.GetOrders();    
        }
        public IEnumerable<Order> GetIenumOrders()
        {
            return OrderManagement.Instance.GetOrders();
        }

        public List<Order> GetOrdersAfterFill(DateTime? startDate, DateTime? endDate)
        {
            return OrderManagement.Instance.GetOrdersByFill(startDate, endDate);
        }

        public List<Order> GetOrdersByCustomerID(int customerID)
        {
            return OrderManagement.Instance.GetOrdersByCustomerID(customerID);
        }

        public void InsertOrder(Order order)
        {
            OrderManagement.Instance.AddNew(order);
        }

        public void Update(Order order)
        {
            OrderManagement.Instance.Update(order); 
        }

        public void UpdateTotalPrice(int orderId, decimal total)
        {
            Order order = OrderManagement.Instance.GetByID(orderId);
            order.Total = total; 
            


        }
    }
}
