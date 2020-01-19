using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public class BusinessEntityModel
    {
        public int BusinessEntityID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
