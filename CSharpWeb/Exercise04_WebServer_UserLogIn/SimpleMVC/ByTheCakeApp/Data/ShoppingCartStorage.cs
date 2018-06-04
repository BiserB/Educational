using SimpleMVC.ByTheCakeApp.Models;
using System;
using System.Collections.Concurrent;


namespace SimpleMVC.ByTheCakeApp.Data
{
    public static class ShoppingCartStorage
    {
        private static readonly ConcurrentDictionary<string, ShoppingCart> carts =
            new ConcurrentDictionary<string, ShoppingCart>();

        public static ShoppingCart GetOrAddCart(string id)
        {
            return carts.GetOrAdd(id, _ => new ShoppingCart(id));
        }

        public static bool DeleteCart(string id)
        {
            bool isRemoved = carts.TryRemove(id, out ShoppingCart cart);

            return isRemoved;
        }
    }
}
