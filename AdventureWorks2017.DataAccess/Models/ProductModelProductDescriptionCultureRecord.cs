using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductModelProductDescriptionCultureModelPrimaryKey
    {
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string CultureID { get; set; }

    }

    public class ProductModelProductDescriptionCultureModel
    {
        public int ProductModelID { get; set; }
        public int ProductDescriptionID { get; set; }
        public string CultureID { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
