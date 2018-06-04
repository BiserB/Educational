
using SimpleMVC.ByTheCakeApp.Utilities;
using System.IO;
using System.Linq;

namespace SimpleMVC.ByTheCakeApp.Models
{
    public class Cake
    {
        public Cake(string name, double price)
        {            
            this.Name = name;
            this.Price = price;
        }
        
        public string Name { get; private set; }
        public double Price { get; private set; }        
    }
}
