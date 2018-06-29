using System;
using FastFood.Data;
using System.Linq;
using System.Text;

namespace FastFood.DataProcessor
{
    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
            var result = "";

            var item = context.Items.FirstOrDefault(i => i.Name == itemName);

            if (item == null)
            {
                result = $"Item {itemName} not found!";
            }
            else
            {
                var oldPrice = item.Price;

                item.Price = newPrice;

                context.SaveChanges();

                result = $"{itemName} Price updated from ${oldPrice:F2} to ${newPrice:F2}";
            }

            
            return result;
        }
    }
}
