using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductModelModelPrimaryKey
    {
        public int ProductModelID { get; set; }

    }

    public class ProductModelModel
    {
        public int ProductModelID { get; set; }
        public string Name { get; set; }
        public System.Xml.XmlDocument? CatalogDescription { get; set; }
        public System.Xml.XmlDocument? Instructions { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
