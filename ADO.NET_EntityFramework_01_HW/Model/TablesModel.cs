using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_EntityFramework_01_HW.Model
{
    public class TablesModel
    {
        [Key]
        public int intModelID { get; set; }
        [StringLength(10)]
        public string strName { get; set; }
        public int? intManufacturerID { get; set; }
        public int? intSMCSFamilyID { get; set; }
        [StringLength(250)]
        public string strImage { get; set; }

    }
}
