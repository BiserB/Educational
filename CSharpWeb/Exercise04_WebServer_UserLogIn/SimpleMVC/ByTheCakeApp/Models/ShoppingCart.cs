using System.Collections.Generic;

namespace SimpleMVC.ByTheCakeApp.Models
{
    public class ShoppingCart     {
        public ShoppingCart(string sessionId)
        {
            this.SessionId = sessionId;            
            this.Items = new Dictionary<string, CakeDetails>();
        }
        public string SessionId { get; private set; }
        public IDictionary<string, CakeDetails> Items { get; set; }
    }
}
