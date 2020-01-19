using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct CurrencyModelPrimaryKey
    {
        public string CurrencyCode { get; set; }

    }

    public class CurrencyModel
    {
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
