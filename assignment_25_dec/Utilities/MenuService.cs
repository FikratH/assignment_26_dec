using assignment_25_dec.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_25_dec.Utilities
{
    internal static class MenuService
    {
        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Good Luck!");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"The application will close in {i}...");
                Thread.Sleep(1000);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
        public static void FilterByType(Store store)
        {
            int i = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please, select the type you want to choose:\n");
            Enum.GetValues(typeof(Category)).Cast<Category>().ToList().ForEach(x => Console.WriteLine($"{++i}. {x}"));
            bool result = int.TryParse(Console.ReadLine(), out int choice);
            Console.WriteLine(" ");
            if (!result || choice <= 0 || choice > i)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, enter a correct number!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
            }
            else if (result)
            {
                Category type = (Category)Enum.GetValues(typeof(Category)).GetValue(choice - 1);
                if (store.FilterProductsByType(type) == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No products in stock!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                }
                else
                {
                    foreach (Product item in store.FilterProductsByType(type))
                    {
                        Console.WriteLine(item);
                    }
                    Thread.Sleep(3500);
                }
            }
            Console.Clear();
        }
        public static void AddProduct(Store store)
        {
            Console.WriteLine("Please, enter product name:");
            string name = Console.ReadLine();
        price:
            Console.WriteLine("Please, enter product price (AZN):");
            bool priceResult = double.TryParse(Console.ReadLine(), out double price);
            if (!priceResult)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, enter a correct price!");
                Console.ForegroundColor = ConsoleColor.White;
                goto price;
            }
            Console.WriteLine("Please, choose product type:\n");
            int i = 0;
            Enum.GetValues(typeof(Category)).Cast<Category>().ToList().ForEach(x => Console.WriteLine($"{++i}. {x}"));
        type:
            bool result = int.TryParse(Console.ReadLine(), out int choice);
            Console.WriteLine(" ");
            if (!result || choice <= 0 || choice > i)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, enter a correct number!");
                Console.ForegroundColor = ConsoleColor.White;
                goto type;
            }
            else if (result)
            {
                Category type = (Category)Enum.GetValues(typeof(Category)).GetValue(choice - 1);
                Product product = new(name, price, type);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Product {name} ({type}) with {price} AZN price was successfully created!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Thread.Sleep(1500);
            Console.Clear();
        }
        public static void RemoveProduct(Store store)
        {
        prodID:
            Console.WriteLine("Please, enter a product ID to delete it:");
            ShowAllProducts();
            bool result = int.TryParse(Console.ReadLine(), out int idToDelete);
            if (!result)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, enter a correct number!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                goto prodID;
            }
            else
            {
                store.RemoveProductByNo(idToDelete);
            }
            Thread.Sleep(2500);
            Console.Clear();
        }
        public static void FilterByName(Store store)
        {
            Console.WriteLine("Please, enter a name of products:");
            string name = Console.ReadLine();
            if (store.FilterProductsByName(name) == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no products with this name!\n");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("\nProducts:\n");
                foreach (Product product in store.FilterProductsByName(name))
                {
                    Console.WriteLine(product);
                }
                Thread.Sleep(3500);
            }
            Console.Clear();
        }
        public static void ShowAllProducts()
        {
            if (Store.products.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no products in stock!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (Product product in Store.products)
                {
                    Console.WriteLine(product);
                }
            }
        }
    }
}

