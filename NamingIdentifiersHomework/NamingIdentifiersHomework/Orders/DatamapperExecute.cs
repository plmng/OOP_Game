namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Collections.Generic;
    
    using Models;

    class DataMapperExecute
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var data = new DataMapper();

            WriteMostExpensiveProducts(data.Products, 5);
            WriteNumberOfProductsByCategory(data.Products,data.Categories);
            WriteTopProductsByQuantity(data.Orders, data.Products, 5);
            WriteMostProfitableCategory(data.Orders, data.Products, data.Categories);
        }
        
        private static void WriteMostProfitableCategory(IEnumerable<Order> orders, IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            Console.WriteLine("\nMost profitable category :");
            Console.WriteLine(new string('-', 10));

            var category = orders
                .GroupBy(order => order.ProductId)
                .Select( group => new
                        {
                            catId = products.First(p => p.Id == group.Key).CategoryId,
                            price = products.First(p => p.Id == group.Key).UnitPrice,
                            quantity = group.Sum(p => p.Quantity)
                        })
                .GroupBy(gg => gg.catId)
                .Select(
                    grp =>
                        new
                        {
                            category_name = categories.First(c => c.Id == grp.Key).Name,
                            total_quantity = grp.Sum(g => g.quantity*g.price)
                        })
                .OrderByDescending(g => g.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", category.category_name, category.total_quantity);
        }
       
        private static void WriteTopProductsByQuantity(IEnumerable<Order> orders, IEnumerable<Product> products, int n)
        {
            Console.WriteLine("\nTop {0} products by quantity ", n);
            Console.WriteLine(new string('-', 10));

            var result = orders
                .GroupBy(o => o.ProductId)
                .Select(
                    grp =>
                        new
                        {
                            Product = products.First(p => p.Id == grp.Key).Name,
                            Quantities = grp.Sum(grpgrp => grpgrp.Quantity)
                        })
                .OrderByDescending(q => q.Quantities)
                .Take(n);
            
            foreach (var item in result)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }
        }
       
        private static void WriteNumberOfProductsByCategory(IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            Console.WriteLine("\nProduct's count by categories:");
            Console.WriteLine(new string('-', 10));

            var result = products
                .GroupBy(p => p.CategoryId)
                .Select(grp => new {Category = categories.First(c => c.Id == grp.Key).Name, Count = grp.Count()})
                .ToList();
            
            foreach (var group in result)
            {
                Console.WriteLine("{0}: {1}", group.Category, group.Count);
            }
        }

       
        private static void WriteMostExpensiveProducts(IEnumerable<Product> products, int n)
        {
            Console.WriteLine("\nTop {0} most expensive products ", n);
            Console.WriteLine(new string('-', 10));

            var result = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(n)
                .Select(p => p.Name);
            
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
