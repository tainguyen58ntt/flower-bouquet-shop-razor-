using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Total { get; set; }
        public string? OrderStatus { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public static implicit operator Order(List<OrderDetail> v)
        {
            throw new NotImplementedException();
        }
    }
}
