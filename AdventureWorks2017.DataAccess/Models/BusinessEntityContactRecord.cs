using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct BusinessEntityContactModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public int PersonID { get; set; }
        public int ContactTypeID { get; set; }

    }

    public class BusinessEntityContactModel
    {
        public int BusinessEntityID { get; set; }
        public int PersonID { get; set; }
        public int ContactTypeID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
