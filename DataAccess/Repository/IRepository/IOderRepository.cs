
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface IOderRepository
    {
        IEnumerable<Order> GetIenumOrders();

        List<Order> GetOrders();
        List<Order> GetOrdersByCustomerID(int customerID);

        List<Order> GetOrdersAfterFill(DateTime? startDate, DateTime? endDate); 
        void InsertOrder(Order order);
        void Update(Order order);

        void UpdateTotalPrice(int orderId, decimal total);
        void DeleOrder(Order order);

        Order GetObjectByOrId(Order order);
        Order GetObjectByOrId(int? orderId);


        ////void Update(Customer customer);
        //bool DeleteFlower(FlowerBouquet flowerBouquet);
    }
}
