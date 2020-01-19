using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct CountryRegionModelPrimaryKey
    {
        public string CountryRegionCode { get; set; }

    }

    public class CountryRegionModel
    {
        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
