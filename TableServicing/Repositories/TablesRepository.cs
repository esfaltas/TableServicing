using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableServicing.Services;
using TableServicing.Entities;
using TableServicing;

namespace TableServicing.Repostitory
{
    internal class TablesRepository
    {
        private Servicing Service = new Servicing();
        public static List<Tables> Tables { get; set; }

        public TablesRepository()
        {
            Tables = Service.ReadTables();
        }
    }
}
