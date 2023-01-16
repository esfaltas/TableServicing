using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableServicing.Entities;
using TableServicing.Services;

namespace TableServicing.Repostitory
{
    internal class MealsRepository
    {
        private Servicing Service = new Servicing();
        public static List<Meals> Meals { get; set; }

        public MealsRepository()
        {
            Meals = Service.ReadMainMeals();
        }
    }
}
