using assignment_25_dec.Entities;
using assignment_25_dec.Utilities;
using System.Xml;

namespace assignment_25_dec
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Store store = new Store();
            Product hell = new("Hell", 1.2, Category.Beverage);
            Product cola = new("Cola", 0.9, Category.Beverage);
            Product fanta = new("Fanta", 0.9, Category.Beverage);
            Product sprite = new("Cola", 0.9, Category.Beverage);

            int selection = 1;
            do
            {
            start:
                Console.WriteLine("\r\n ██████  ██████   █████  ███    ██ ██████  ███    ███  █████  ██████  ████████ \r\n██       ██   ██ ██   ██ ████   ██ ██   ██ ████  ████ ██   ██ ██   ██    ██    \r\n██   ███ ██████  ███████ ██ ██  ██ ██   ██ ██ ████ ██ ███████ ██████     ██    \r\n██    ██ ██   ██ ██   ██ ██  ██ ██ ██   ██ ██  ██  ██ ██   ██ ██   ██    ██    \r\n ██████  ██   ██ ██   ██ ██   ████ ██████  ██      ██ ██   ██ ██   ██    ██    \r\n                                                                               \r\n                                                                               \r\n");
                Console.WriteLine("╔════════════════════════╗");
                Console.WriteLine("║                        ║");
                Console.WriteLine("║  1. Add product        ║");
                Console.WriteLine("║  2. Remove product     ║");
                Console.WriteLine("║  3. Filter by name     ║");
                Console.WriteLine("║  4. Filter by type     ║");
                Console.WriteLine("║  0. Exit               ║");
                Console.WriteLine("║                        ║");
                Console.WriteLine("╚════════════════════════╝");
                Console.WriteLine(" ");
                int down = 16;
                int top = 11;
                int y = top;

                Console.CursorTop = top;
                Console.CursorSize = 95;
                Console.CursorLeft = 26;

                ConsoleKey key;
                while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
                {
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (y > top)
                        {
                            y--;
                            Console.CursorTop = y;
                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (y < down - 1)
                        {
                            y++;
                            Console.CursorTop = y;
                        }
                    }
                }
                Console.CursorTop = down + 3;
                Console.CursorLeft = 0;
                if (y == top) //1
                {
                    MenuService.AddProduct(store);
                }
                else if (y == top + 1) //2
                {
                    MenuService.RemoveProduct(store);
                }
                else if (y == top + 2) //3
                {
                    MenuService.FilterByName(store);
                }
                else if (y == top + 3) //4
                {
                    MenuService.FilterByType(store);
                }
                else if (y == top + 4) //0
                {
                    MenuService.Exit();
                }
            } while (selection != 0);
        }
    }
}