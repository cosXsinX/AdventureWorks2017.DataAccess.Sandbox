using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SalesTaxRateModelPrimaryKey
    {
        public int SalesTaxRateID { get; set; }

    }

    public class SalesTaxRateModel
    {
        public int SalesTaxRateID { get; set; }
        public int StateProvinceID { get; set; }
        public byte TaxType { get; set; }
        public decimal TaxRate { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
