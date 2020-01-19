using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct EmployeeDepartmentHistoryModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public short DepartmentID { get; set; }
        public byte ShiftID { get; set; }
        public DateTime StartDate { get; set; }

    }

    public class EmployeeDepartmentHistoryModel
    {
        public int BusinessEntityID { get; set; }
        public short DepartmentID { get; set; }
        public byte ShiftID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
