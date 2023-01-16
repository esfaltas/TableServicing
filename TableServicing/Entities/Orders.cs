using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableServicing.Entities
{
    internal class Orders
    {
        private static List<Products> Products = new();

        public static void AddProduct(Products product)
        {
            Products.Add(product);
        }

        public static void RemoveOrder()
        {
            Products.Clear();
        }

        public static void PrintOrder()
        {
            Console.WriteLine("Order:");    // Pridet pavadinima Orderio
            foreach (var product in Products)
            {
                Console.WriteLine(product);
            }
        }

        private static List<Products> Cost = new();

        public static void AddCost(Products Price)
        {
            Cost.Add(Price);
        }

        public static void PrintCost()
        {
            double OrderSum = 0;
            foreach (var price in Products)
            {
                OrderSum = OrderSum + Convert.ToDouble(price.Price);
            }
            Console.WriteLine($"Total cost: {OrderSum} Euros");
            Console.WriteLine(" ");
        }
    }
}
