using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SalesTerritoryHistoryModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public int TerritoryID { get; set; }
        public DateTime StartDate { get; set; }

    }

    public class SalesTerritoryHistoryModel
    {
        public int BusinessEntityID { get; set; }
        public int TerritoryID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
