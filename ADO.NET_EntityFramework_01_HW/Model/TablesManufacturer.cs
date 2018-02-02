using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_EntityFramework_01_HW.Model
{
    public class TablesManufacturer
    {

        [Key]
        public int intManufacturerID { get; set; }
        [StringLength(50)]
        public string strManufacturerChecklistId { get; set; }
        [StringLength(50)]
        public string strName { get; set; }
    }
}
