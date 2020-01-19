using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductDescriptionModelPrimaryKey
    {
        public int ProductDescriptionID { get; set; }

    }

    public class ProductDescriptionModel
    {
        public int ProductDescriptionID { get; set; }
        public string Description { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
