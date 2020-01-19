using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ContactTypeModelPrimaryKey
    {
        public int ContactTypeID { get; set; }

    }

    public class ContactTypeModel
    {
        public int ContactTypeID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
