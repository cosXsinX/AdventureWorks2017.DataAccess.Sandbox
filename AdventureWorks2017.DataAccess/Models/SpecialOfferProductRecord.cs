using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SpecialOfferProductModelPrimaryKey
    {
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }

    }

    public class SpecialOfferProductModel
    {
        public int SpecialOfferID { get; set; }
        public int ProductID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
