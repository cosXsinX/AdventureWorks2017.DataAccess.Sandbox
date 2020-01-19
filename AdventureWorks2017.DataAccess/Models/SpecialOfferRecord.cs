using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SpecialOfferModelPrimaryKey
    {
        public int SpecialOfferID { get; set; }

    }

    public class SpecialOfferModel
    {
        public int SpecialOfferID { get; set; }
        public string Description { get; set; }
        public decimal DiscountPct { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinQty { get; set; }
        public int? MaxQty { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
