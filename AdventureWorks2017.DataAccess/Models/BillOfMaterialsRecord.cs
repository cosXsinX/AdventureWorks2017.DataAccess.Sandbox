using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public class BillOfMaterialsModel
    {
        public int BillOfMaterialsID { get; set; }
        public int? ProductAssemblyID { get; set; }
        public int ComponentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UnitMeasureCode { get; set; }
        public short BOMLevel { get; set; }
        public decimal PerAssemblyQty { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
