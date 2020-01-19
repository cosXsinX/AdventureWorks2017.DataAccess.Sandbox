using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct BusinessEntityAddressModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }

    }

    public class BusinessEntityAddressModel
    {
        public int BusinessEntityID { get; set; }
        public int AddressID { get; set; }
        public int AddressTypeID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
