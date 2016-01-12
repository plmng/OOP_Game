namespace Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    using Models;

    public class DataMapper
    {
        private readonly string _categoriesFileName;
        private readonly string _productsFileName;
        private readonly string _ordersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this._categoriesFileName = categoriesFileName;
            this._productsFileName = productsFileName;
            this._ordersFileName = ordersFileName;
            this.Products = this.GetAllProducts();
            this.Categories = this.GetAllCategories();
            this.Orders = this.GetAllOrders();
        }

        public DataMapper()
            : this("../../Data/categories.txt", "../../Data/products.txt", "../../Data/orders.txt")
        {
        }

        public IEnumerable<Category> Categories { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }

        private IEnumerable<Category> GetAllCategories()
        {
            var categories = ReadFileLines(this._categoriesFileName, true);
            return categories
                .Select(c => c.Split(','))
                .Select(c => new Category
                {
                    Id = int.Parse(c[0]),
                    Name = c[1],
                    Description = c[2]
                });
        }

        private IEnumerable<Product> GetAllProducts()
        {
            var products = ReadFileLines(this._productsFileName, true);
            return products
                .Select(p => p.Split(','))
                .Select(p => new Product
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    CategoryId = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[3]),
                    UnitsInStock = int.Parse(p[4]),
                });
        }

        private IEnumerable<Order> GetAllOrders()
        {
            var orders = ReadFileLines(this._ordersFileName, true);
            return orders
                .Select(p => p.Split(','))
                .Select(p => new Order
                {
                    Id = int.Parse(p[0]),
                    ProductId = int.Parse(p[1]),
                    Quantity = int.Parse(p[2]),
                    Discount = decimal.Parse(p[3]),
                });
        }

        private List<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
