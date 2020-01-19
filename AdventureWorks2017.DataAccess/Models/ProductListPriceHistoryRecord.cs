using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductListPriceHistoryModelPrimaryKey
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }

    }

    public class ProductListPriceHistoryModel
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
