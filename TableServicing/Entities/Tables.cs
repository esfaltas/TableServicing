using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TableServicing.Entities;

namespace TableServicing.Entities
{
    internal class Tables : Table
    {
        public override string? ToString()
        {
            return $"Table {TableName}     has {NumberOfSeats} seats   -  {Availability}";
        }
    }

    internal class Table
    {
        public string TableName { get; set; }
        public decimal NumberOfSeats { get; set; }
        public string Availability { get; set; }
    }
}
                                          