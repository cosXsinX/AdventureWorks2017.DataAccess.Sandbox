using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ShiftModelPrimaryKey
    {
        public byte ShiftID { get; set; }

    }

    public class ShiftModel
    {
        public byte ShiftID { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
