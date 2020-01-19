using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductInventoryModelPrimaryKey
    {
        public int ProductID { get; set; }
        public short LocationID { get; set; }

    }

    public class ProductInventoryModel
    {
        public int ProductID { get; set; }
        public short LocationID { get; set; }
        public string Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
