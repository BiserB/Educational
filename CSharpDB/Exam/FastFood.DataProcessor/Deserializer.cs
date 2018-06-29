using System;
using FastFood.Data;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using System.Linq;
using System.Xml.Linq;
using System.Globalization;
using FastFood.Models.Enums;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();

            EmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);            

            var positions = new List<Position>();

            var validatedEmployees = new List<Employee>();

            foreach (var e in employeeDtos)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                if (validatedEmployees.Any(ve => ve.Name == e.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                var position = positions.FirstOrDefault(p => p.Name == e.Position);
                if (position == null)
                {
                    var newPosition = new Position { Name = e.Position };
                    positions.Add(newPosition);
                    position = newPosition;
                }
                var newEmployee = new Employee
                {
                    Name = e.Name,
                    Age = e.Age,
                    Position = position
                };
                validatedEmployees.Add(newEmployee);
                sb.AppendLine(String.Format(SuccessMessage, e.Name));
            }
            context.Positions.AddRange(positions);
            context.SaveChanges();
            context.Employees.AddRange(validatedEmployees);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            StringBuilder sb = new StringBuilder();

            var itemDtos = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

            var categories = new List<Category>();

            var validatedItems = new List<Item>();

            foreach (var item in itemDtos)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                if (validatedItems.Any(vi => vi.Name == item.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                var category = categories.FirstOrDefault(c => c.Name == item.Category);
                if (category == null)
                {
                    var newCategory = new Category { Name = item.Category };
                    categories.Add(newCategory);
                    category = newCategory;
                }
                var newItem = new Item
                {
                    Name = item.Name,
                    Category = category,
                    Price = item.Price
                };                
                validatedItems.Add(newItem);
                sb.AppendLine(String.Format(SuccessMessage, item.Name));
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
            context.Items.AddRange(validatedItems);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            StringBuilder sb = new StringBuilder();

            var xmlDoc = XDocument.Parse(xmlString);

            var orders = xmlDoc.Root.Elements();

            var validatedOrders = new List<Order>();

            var existingItems = context.Items.ToArray();

            foreach (var order in orders)
            {
                var totalPrice = 0.0m;
                var items = order.Element("Items").Elements();
                var orderItems = new List<OrderItem>();
                foreach (var item in items)     //-------------------------check for every Item in Items Xml
                {
                    var itemName = item.Element("Name")?.Value;
                    var quantity = item.Element("Quantity")?.Value;
                    if (itemName == null || quantity == null)
                    {                        
                        orderItems.Clear();
                        break;
                    }
                    var itemExists = existingItems.SingleOrDefault(ei => ei.Name == itemName);
                    var qty = int.Parse(quantity);
                    if (itemExists == null || qty < 1)
                    {                        
                        orderItems.Clear();
                        break;
                    }                   
                    var price = itemExists.Price;
                    totalPrice = totalPrice + (price * qty);
                    var newOrderItem = new OrderItem { Item = itemExists, Quantity = qty };
                    orderItems.Add(newOrderItem);
                }
                if (orderItems.Count == 0)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                var customerName = order.Element("Customer")?.Value;
                var employeeName = order.Element("Employee")?.Value;
                var dateTime = order.Element("DateTime")?.Value;
                var typeOfOrder = order.Element("Type")?.Value;
                if (dateTime == null || customerName == null || employeeName == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                var employee = context.Employees.FirstOrDefault(e => e.Name == employeeName);
                var date = DateTime.ParseExact(dateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                if (typeOfOrder == null)
                {
                    typeOfOrder = "ForHere";
                }
                var type = Enum.Parse<OrderType>(typeOfOrder);
                var newOrder = new Order
                {
                    Customer = customerName,
                    DateTime = date,
                    Type = type,
                    Employee = employee,
                    TotalPrice = totalPrice,
                    OrderItems = orderItems
                };
                validatedOrders.Add(newOrder);
                sb.AppendLine($"Order for {customerName} on {dateTime} added");
            }
            context.Orders.AddRange(validatedOrders);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}