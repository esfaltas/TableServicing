using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableServicing.Entities;
using TableServicing.Repostitory;

namespace TableServicing.Services
{
    internal class Servicing
    {
        private string mealsPath = "E:\\studijos\\Paskaitos\\paskaituKodai\\BE\\TableServicing\\TableServicing\\Data\\Meals.csv";
        private string appetizersPath = "E:\\studijos\\Paskaitos\\paskaituKodai\\BE\\TableServicing\\TableServicing\\Data\\Appetizers.csv";
        private string tablesPath = "E:\\studijos\\Paskaitos\\paskaituKodai\\BE\\TableServicing\\TableServicing\\Data\\Tables.csv";
        private string drinksPath = "E:\\studijos\\Paskaitos\\paskaituKodai\\BE\\TableServicing\\TableServicing\\Data\\Drinks.csv";
        private string filePath = "E:\\studijos\\Paskaitos\\paskaituKodai\\BE\\TableServicing\\test.txt";

        public List<Meals> ReadMainMeals()
        {
            string text = File.ReadAllText(mealsPath);
            string[] lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var MainMeals = new List<Meals>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] productDataArray = lines[i].Split(',');
                var mainMeal = new Meals
                {
                    Name = productDataArray[0],
                    Price = Convert.ToDecimal(productDataArray[1]),
                };

                MainMeals.Add(mainMeal);
            }

            return MainMeals;
        }

        public List<Drinks> ReadDrinks()
        {
            string text = File.ReadAllText(drinksPath);
            string[] lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var drinks = new List<Drinks>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] productDataArray = lines[i].Split(',');
                var drink = new Drinks
                {
                    Name = productDataArray[0],
                    Price = Convert.ToDecimal(productDataArray[1]),
                };
                drinks.Add(drink);
            }
            return drinks;
        }

        public List<Appetizers> ReadAppetizers()
        {
            string text = File.ReadAllText(appetizersPath);
            string[] lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var appetizers = new List<Appetizers>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] productDataArray = lines[i].Split(',');
                var appetizer = new Appetizers
                {
                    Name = productDataArray[0],
                    Price = Convert.ToDecimal(productDataArray[1]),
                };
                appetizers.Add(appetizer);
            }
            return appetizers;
        }

        public List<Tables> ReadTables()
        {
            string text = File.ReadAllText(tablesPath);
            string[] lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var tables = new List<Tables>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] productDataArray = lines[i].Split(',');
                var table = new Tables
                {
                    TableName = productDataArray[0],
                    NumberOfSeats = Convert.ToDecimal(productDataArray[1]),
                    Availability = productDataArray[2],
                };
                tables.Add(table);
            }
            return tables;
        }

        public void WriteToFile()
        {
            var order = new Orders();
            var printInfo = Orders.PrintOrder;
            DateTime time = DateTime.Now;
            if (File.Exists(filePath))
            {
                using (StreamWriter stream = File.AppendText(filePath))
                {
                    stream.WriteLine(printInfo + " " + time.ToString());
                    stream.Close();
                }
            }
        }
    }
}
