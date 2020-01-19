using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct SalesReasonModelPrimaryKey
    {
        public int SalesReasonID { get; set; }

    }

    public class SalesReasonModel
    {
        public int SalesReasonID { get; set; }
        public string Name { get; set; }
        public string ReasonType { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
