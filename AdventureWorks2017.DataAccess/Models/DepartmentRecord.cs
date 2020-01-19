using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct DepartmentModelPrimaryKey
    {
        public short DepartmentID { get; set; }

    }

    public class DepartmentModel
    {
        public short DepartmentID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
