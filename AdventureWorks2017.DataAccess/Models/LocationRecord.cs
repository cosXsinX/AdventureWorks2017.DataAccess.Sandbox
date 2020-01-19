using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct LocationModelPrimaryKey
    {
        public short LocationID { get; set; }

    }

    public class LocationModel
    {
        public short LocationID { get; set; }
        public string Name { get; set; }
        public decimal CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
