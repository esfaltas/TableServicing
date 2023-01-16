using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableServicing.Entities;
using TableServicing.Services;

namespace TableServicing.Repostitory
{
    internal class AppetizersRepository
    {
        private Servicing Service = new Servicing();
        public static List<Appetizers> Appetizers { get; set; }

        public AppetizersRepository()
        {
            Appetizers = Service.ReadAppetizers();
        }
    }
}
