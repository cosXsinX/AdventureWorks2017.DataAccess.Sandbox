using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SalesOrderHeaderSalesReasonModelPrimaryKey
    {
        public int SalesOrderID { get; set; }
        public int SalesReasonID { get; set; }

    }

    public class SalesOrderHeaderSalesReasonModel
    {
        public int SalesOrderID { get; set; }
        public int SalesReasonID { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
