using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ScrapReasonModelPrimaryKey
    {
        public short ScrapReasonID { get; set; }

    }

    public class ScrapReasonModel
    {
        public short ScrapReasonID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
