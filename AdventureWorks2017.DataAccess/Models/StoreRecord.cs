using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct StoreModelPrimaryKey
    {
        public int BusinessEntityID { get; set; }

    }

    public class StoreModel
    {
        public int BusinessEntityID { get; set; }
        public string Name { get; set; }
        public int? SalesPersonID { get; set; }
        public System.Xml.XmlDocument? Demographics { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
