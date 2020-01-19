using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductCategoryModelPrimaryKey
    {
        public int ProductCategoryID { get; set; }

    }

    public class ProductCategoryModel
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
