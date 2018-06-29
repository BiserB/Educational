using System;
using System.IO;
using FastFood.Data;
using FastFood.Models.Enums;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            var type = Enum.Parse<OrderType>(orderType);

            var orders = context.Orders
                                .Where(o => o.Employee.Name == employeeName && o.Type == type)
                                .ToArray();

            var selection = orders.Select(o => new
            {
                Customer = o.Customer,
                OrderedItems = o.OrderItems.Select(oi => new
                {
                    Name = oi.Item.Name,
                    Price = oi.Item.Price,
                    Quantity = oi.Quantity,
                    Subtotal = oi.Item.Price * oi.Quantity
                })
            })
             .ToArray()
             .Select(s => new
             {
                 s.Customer,
                 Items = s.OrderedItems.Select(i => new
                 {
                     i.Name,
                     i.Price,
                     i.Quantity
                 }).ToArray(),
                 TotalPrice = s.OrderedItems.Sum(o => o.Subtotal)
             });

            var output = new
            {
                Name = employeeName,
                Orders = selection,
                TotalMade = selection.Select(s => s.TotalPrice).Sum()
            };           


            string result = JsonConvert.SerializeObject(output, Formatting.Indented);

            return result;
        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var sb = new StringBuilder();

            var categories = context.Categories
                                    .Include(i => i.Items)
                                    .Select(c => c.Items)
                                    .ToArray();


            var result = sb.ToString();
            return result;
        }
	}
}