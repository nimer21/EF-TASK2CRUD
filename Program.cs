using efcrud.Data;
using efcrud.Models;
using Microsoft.EntityFrameworkCore;

namespace efcrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // *********Seeding Data**********add data to product table*********add data to order table************
            /*
            var product = new Product[]
        {
            new Product{ Name = "Printer", Price = "500" },
            new Product{ Name = "Laptop", Price = "1200" },
            new Product{ Name = "USB", Price = "60" },
            new Product{ Name = "Headphone", Price = "150" },
            new Product{ Name = "CD", Price = "10" },
            //add other users
        };
            foreach (var p in product) { 
                context.Products.Add(p);
            context.SaveChanges();
        }
            var order = new Order[]
        {
            new Order{ Address = "Beit Jala", CreatedAt = DateTime.Now },
            new Order{ Address = "Bethlehem", CreatedAt = DateTime.Now },
            new Order{ Address = "Sabastia", CreatedAt = DateTime.Now },
            new Order{ Address = "Hebron", CreatedAt = DateTime.Now },
            new Order{ Address = "Jerusalem", CreatedAt = DateTime.Now },
            //add other users
        };
            foreach (var o in order)
            {
                context.Orders.Add(o);
                context.SaveChanges();
            }
            */

            // *********GET Data**********get all products *********get all orders************
            var product = context.Products.ToList();
            var order = context.Orders.ToList();
            foreach (var p in product)
            {
                Console.WriteLine(p.Name);
            }
            foreach (var o in order)
            {
                Console.WriteLine(o.Address);
            }
            // *********UPDATE Data**********update product name *********update order created at************
            var productUpdate = context.Products.First(p => p.Id==2);
            productUpdate.Name = "Laptop";
            productUpdate.Price = "1200";
            var orderUpdate = context.Orders.First(o => o.Id == 4);
            orderUpdate.CreatedAt= DateTime.Now;
            context.SaveChanges();

            // *********DELETE Data**********remove product with id 2 *********remove order with id 3************
            var productDelete = context.Products.First(p => p.Id == 2);
            context.Products.Remove(productDelete);
            var orderDelete = context.Orders.First(o => o.Id == 3);
            context.Orders.Remove(orderDelete);

            Console.WriteLine("Commited");
        }
    }
}
