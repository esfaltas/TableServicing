using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TableServicing.Entities
{
    internal class Meals : Products
    {
        public override string? ToString()
        {
            return $"{Name}. Cost {Price} Euro";
        }
    }
}
