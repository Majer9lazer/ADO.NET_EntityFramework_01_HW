using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_EntityFramework_01_HW.Model
{
    class CodeFirstDb : DbContext
    {
        public CodeFirstDb() : base("name  = CodeFirstConnection")
        {

        }
        public DbSet<TablesManufacturer> TablesManufacturers { get; set; }
        public DbSet<TablesModel> TablesModels { get; set; }
    }
}
