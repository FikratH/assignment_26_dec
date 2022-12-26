using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_25_dec.Entities
{
    internal class Product
    {
        int _no;
        public int No
        {
            get
            {
                return _no;
            }
            set
            {
                _no = value;
            }
        }
        static int count = 0;
        public string Name;
        public double Price;
        public Category Type;

        public Product(string name, double price, Category type)
        {

            _no = ++count;
            Name = name;
            Price = price;
            Type = type;
            Array.Resize(ref Store.products,Store.products.Length + 1);
            Store.products[Store.products.Length-1] = this;
        }
        public override string ToString()
        {
            return $"ID: {No}\n Name: {Name}\n Price: {Price} AZN\n Type: {Type}\n";
        }
    }
}
