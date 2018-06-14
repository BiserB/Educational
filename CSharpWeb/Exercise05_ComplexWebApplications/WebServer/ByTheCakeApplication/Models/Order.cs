using System;
using System.Collections.Generic;

namespace HTTPServer.ByTheCakeApplication.Models
{
    public class Order
    {
        public Order(int userId)
        {
            this.UserId = userId;
            this.OrderDate = DateTime.Now;
            this.ProductList = new List<ProductOrder>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<ProductOrder> ProductList { get; set; }
    }
}