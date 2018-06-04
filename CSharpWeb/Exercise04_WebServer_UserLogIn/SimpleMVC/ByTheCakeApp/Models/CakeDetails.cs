

namespace SimpleMVC.ByTheCakeApp.Models
{
    public class CakeDetails
    {
        public CakeDetails(double price)
        {
            this.Price = price;
            this.Qty = 1;
        }
        public double Price { get; }
        public int Qty { get; private set; }

        public void AddPiece()
        {
            this.Qty += 1;
        }
    }
}
