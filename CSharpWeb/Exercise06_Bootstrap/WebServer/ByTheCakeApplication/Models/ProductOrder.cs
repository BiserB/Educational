namespace HTTPServer.ByTheCakeApplication.Models
{
    public class ProductOrder
    {
        public ProductOrder(int productId, int orderId, int productQty)
        {
            this.ProductId = productId;
            this.OrderId = orderId;
            this.ProductQty = productQty;
        }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductQty { get; set; }
    }
}