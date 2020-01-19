using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct CountryRegionCurrencyModelPrimaryKey
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }

    }

    public class CountryRegionCurrencyModel
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
