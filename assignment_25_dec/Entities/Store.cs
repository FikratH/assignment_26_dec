using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_25_dec.Entities
{
    internal class Store
    {
        public static Product[] products;

        static Store()
        {
            products = new Product[0];
        }

        public void AddProduct(Product product)
        {
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = product;
        }
        public void RemoveProductByNo(int productNo)
        {
            Product? prod = products.Where(x => x.No == productNo).FirstOrDefault();
            if (prod == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no product with this ID");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            } else
            {
                int index = Array.IndexOf(products, prod);
                products = products.Where(x=> Array.IndexOf(products,x)!=index).ToArray();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Product with ID {productNo} was removed successfully!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public Product[]? FilterProductsByType(Category type)
        {
            Product[] result = new Product[0];
            result = products.Where(x => x.Type == type).ToArray();
            if (result.Length == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
        public Product[]? FilterProductsByName(string name)
        {
            Product[] result = new Product[0];
            result = products.Where(x => x.Name == name).ToArray();
            if (result.Length == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
    }
}
