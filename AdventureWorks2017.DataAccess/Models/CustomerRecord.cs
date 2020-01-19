using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct CustomerModelPrimaryKey
    {
        public int CustomerID { get; set; }

    }

    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public int? PersonID { get; set; }
        public int? StoreID { get; set; }
        public int? TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
