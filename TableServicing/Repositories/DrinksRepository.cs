using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableServicing.Entities;
using TableServicing.Services;

namespace TableServicing.Repostitory
{
    internal class DrinksRepository
    {
        private Servicing Service = new Servicing();
        public static List<Drinks> Drinks { get; set; }

        public DrinksRepository()
        {
            Drinks = Service.ReadDrinks();
        }
    }
}
