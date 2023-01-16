using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TableServicing.Entities;
using TableServicing.Repostitory;
using TableServicing;

namespace TableServicing.Services
{
    internal class Menu
    {
        public void InitiateMenu()
        {
            while (true)
            {
                Console.WriteLine($"Grand Insertyourname --------------------------- {time}");
                Console.WriteLine(" ");
                PrintTables();
                Console.WriteLine(" ");
                Console.WriteLine("W - Check Menu               Q - Logoff");
                Console.WriteLine(" ");
                Console.WriteLine("--------------------------------------------------------------------");
                var key = Console.ReadKey();
                Console.WriteLine(" ");
                if (key.KeyChar == 'w')
                {
                    Console.Clear();
                    PrintMenu();
                }
                else if (key.KeyChar == '2')
                {
                    Console.Clear();
                    TakeOrder();
                }
                else if (key.KeyChar == '3')
                {
                    Console.Clear();
                    TakeOrder();
                }
                else if (key.KeyChar == '4')
                {
                    Console.Clear();
                    TakeOrder();
                }
                else if (key.KeyChar == '5')
                {
                    Console.Clear();
                    TakeOrder();
                }
                else if (key.KeyChar == 'q')
                {
                    Console.Clear();
                    Console.WriteLine("You haved logged off");
                    Environment.Exit(0);
                }
            }
        }

        string time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public void PrintTables()
        {
            foreach (Tables table in TablesRepository.Tables)
            {
                Console.WriteLine(table);
            }
        }

        public int GetSelection()
        {
            bool isSuccess = int.TryParse(Console.ReadLine(), out int result);
            if (isSuccess)
            {
                return result;
            }
            Console.WriteLine("Invalid entry");
            return 0;
        }

        public void PrintMenu()
        {
            foreach (Appetizers appetizers in AppetizersRepository.Appetizers)
            {
                Console.WriteLine(appetizers);
            }
            Console.WriteLine(" ");

            foreach (Meals mainMeal in MealsRepository.Meals)
            {
                Console.WriteLine(mainMeal);
            }
            Console.WriteLine(" ");

            foreach (Drinks drink in DrinksRepository.Drinks)
            {
                Console.WriteLine(drink);
            }
            Console.WriteLine(" ");
        }

        public void TakeOrder()
        {
            while (true)
            {
                Console.WriteLine($"Order for this Table");
                Orders.PrintCost();
                Console.WriteLine("1. Appetizers");
                Console.WriteLine("2. Main meals");
                Console.WriteLine("3. Drinks");
                Console.WriteLine("4. View full order");
                Console.WriteLine("5. Pay for order");
                Console.WriteLine("6. Mark table as FREE");
                Console.WriteLine("7. Back");
                var key = Console.ReadKey();
                Console.WriteLine(" ");
                if (key.KeyChar == '1')
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Appetizers");
                    AddAppetizersToOrder();
                }
                else if (key.KeyChar == '2')
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Main meals");
                    AddMainMealToOrder();
                }
                else if (key.KeyChar == '3')
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Drinks");
                    AddDrinksToOrder();
                }
                else if (key.KeyChar == '4')
                {
                    Console.Clear();
                    Orders.PrintOrder();
                    TakeOrder();
                }
                else if (key.KeyChar == '5')
                {
                    Console.Clear();
                    Console.WriteLine("Pay for Order");
                    Orders.PrintOrder();
                    Orders.PrintCost();
                    PayForOrder();
                    InitiateMenu();
                }
                else if (key.KeyChar == '6')
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Mark table as Free");
                    InitiateMenu();
                }
                else if (key.KeyChar == '7')
                {
                    Console.Clear();
                    InitiateMenu();
                }
            }
        }

        public void PrintMainMeals()
        {
            foreach (Meals mainMeal in MealsRepository.Meals)
            {
                Console.WriteLine(mainMeal);
            }
            Console.WriteLine(" ");
        }

        public void PrintAppetizers()
        {
            foreach (Appetizers appetizers in AppetizersRepository.Appetizers)
            {
                Console.WriteLine(appetizers);
            }
            Console.WriteLine(" ");
        }

        public void PrintDrinks()
        {
            foreach (Drinks drink in DrinksRepository.Drinks)
            {
                Console.WriteLine(drink);
            }
        }

        public void AddMainMealToOrder()
        {
            PrintMainMeals();
            Console.WriteLine("Choose index of item you want to add to this order:");
            var selectMainMeal = GetSelection();
            Console.WriteLine(" ");
            var mainmeal = MealsRepository.Meals[selectMainMeal - 1];
            if (mainmeal != null)
            {
                Orders.AddProduct(mainmeal);
                Console.WriteLine($"{mainmeal} was added to order "); // order number
                Console.WriteLine(" ");
                Console.Clear();
                TakeOrder();
            }
            else
            {
                Console.WriteLine($"Meal with index {selectMainMeal - 1} does not exist");
                Console.WriteLine(" ");
                Console.Clear();
                TakeOrder();
            }
        }

        public void AddDrinksToOrder()
        {
            PrintDrinks();
            Console.WriteLine("Choose index of item you want to add to this order:");
            var selectedDrink = GetSelection();
            var drink = DrinksRepository.Drinks[selectedDrink - 1];
            if (drink != null)
            {
                Orders.AddProduct(drink);
                Console.WriteLine($"{drink} was added to your order");
                Console.WriteLine(" ");
                Console.Clear();
                TakeOrder();

            }
            else
            {
                Console.WriteLine($"Candy with index {selectedDrink - 1} does not exist");
                Console.WriteLine(" ");
                Console.Clear();
                TakeOrder();
            }
        }

        public void AddAppetizersToOrder()
        {
            PrintAppetizers();
            Console.WriteLine("Choose index of item you want to add to this order:");
            var selectAppetizer = GetSelection();
            Console.WriteLine(" ");
            var appetizer = AppetizersRepository.Appetizers[selectAppetizer - 1];
            if (appetizer != null)
            {
                Orders.AddProduct(appetizer);
                Console.WriteLine($"{appetizer} was added to order ");
                Console.WriteLine(" ");
                Console.Clear();
                TakeOrder();
            }
            else
            {
                Console.WriteLine($"Meal with index {selectAppetizer - 1} does not exist");
                Console.WriteLine(" ");
                Console.Clear();
                TakeOrder();
            }
        }
        public void PrintCheque()
        {
            Console.WriteLine("---------------------Grand Insertyourname---------------------");
            Console.WriteLine($"Date: {time}");
            Console.WriteLine("--------------------------------------------------------------");
            Orders.PrintOrder();
            Console.WriteLine("--------------------------------------------------------------");
            Orders.PrintCost();
            Console.WriteLine($"Thank you for visiting \n Grand Insertyourname");
            Console.WriteLine("--------------------------------------------------------------");
            var Service = new Servicing();
            Service.WriteToFile();
            // SendEmail("client007@gmail.com", "Google Support", "Supsup");
            // SendEmail("Grandinsertyourname@restaurant.com", "Google Support", "Supsup");
        }

        public void PrintChequeRest()
        {
            Console.WriteLine($"Date: {time}");
            Orders.PrintOrder();
            Orders.PrintCost();
            Console.WriteLine("--------------------------------------------------------------");
            // SendEmail("Grandinsertyourname@restaurant.com", "Google Support", "Supsup");
        }



        public void PayForOrder()
        {
            Console.WriteLine("1. Pay for order and print receipt.");
            Console.WriteLine("2. Pay for order without receipt.");
            Console.WriteLine("3. Back");
            var Selection = GetSelection();
            Console.WriteLine(" ");
            switch (Selection)
            {
                case 0:
                    break;
                case 1:
                    Console.Clear();
                    PrintCheque();
                    PrintChequeRest();
                    Orders.RemoveOrder();
                    RR();
                    break;
                case 2:
                    Console.Clear();
                    PrintChequeRest();
                    Orders.RemoveOrder();
                    RR();
                    break;
                case 3:
                    Console.Clear();
                    TakeOrder();
                    break;
            }
        }

        public void RR()
        {
            Console.WriteLine("1. Back");
            var Selection = GetSelection();
            switch (Selection)
            {
                case 0:
                    break;
                case 1:
                    Console.Clear();
                    InitiateMenu();
                    break;
            }
        }

        public void SendEmail(string to, string subject, string body)
        {
            var fromAddress = new MailAddress("plswork@gmail.com", "From Me");
            var toAddress = new MailAddress(to, "future me");
            const string fromPassword = "123";



            var netClient = new SmtpClient
            {
                Host = "",
                Port = 1,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };
            netClient.Send(message);
        }
    }
}
