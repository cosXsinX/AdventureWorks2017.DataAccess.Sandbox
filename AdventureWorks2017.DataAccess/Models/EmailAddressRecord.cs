using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct EmailAddressModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public int EmailAddressID { get; set; }

    }

    public class EmailAddressModel
    {
        public int BusinessEntityID { get; set; }
        public int EmailAddressID { get; set; }
        public string? EmailAddress { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
