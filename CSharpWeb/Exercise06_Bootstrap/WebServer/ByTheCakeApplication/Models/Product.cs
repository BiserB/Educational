using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HTTPServer.ByTheCakeApplication.Models
{
    public class Product
    {
        public Product()
        {
            this.ProductOrders = new List<ProductOrder>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}