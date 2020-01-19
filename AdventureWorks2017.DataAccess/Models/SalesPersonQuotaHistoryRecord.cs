using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SalesPersonQuotaHistoryModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public DateTime QuotaDate { get; set; }

    }

    public class SalesPersonQuotaHistoryModel
    {
        public int BusinessEntityID { get; set; }
        public DateTime QuotaDate { get; set; }
        public decimal SalesQuota { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
