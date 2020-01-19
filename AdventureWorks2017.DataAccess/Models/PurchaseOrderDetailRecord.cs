using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct PurchaseOrderDetailModelPrimaryKey
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderDetailID { get; set; }

    }

    public class PurchaseOrderDetailModel
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderDetailID { get; set; }
        public DateTime DueDate { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal RejectedQty { get; set; }
        public decimal StockedQty { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
