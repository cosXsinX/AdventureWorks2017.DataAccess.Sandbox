using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductSubcategoryModelPrimaryKey
    {
        public int ProductSubcategoryID { get; set; }

    }

    public class ProductSubcategoryModel
    {
        public int ProductSubcategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
