using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct UnitMeasureModelPrimaryKey
    {
        public string UnitMeasureCode { get; set; }

    }

    public class UnitMeasureModel
    {
        public string UnitMeasureCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
