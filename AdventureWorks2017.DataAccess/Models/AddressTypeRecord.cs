using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct AddressTypeModelPrimaryKey
    {
        public int AddressTypeID { get; set; }

    }

    public class AddressTypeModel
    {
        public int AddressTypeID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
