using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductModelIllustrationModelPrimaryKey
    {
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }

    }

    public class ProductModelIllustrationModel
    {
        public int ProductModelID { get; set; }
        public int IllustrationID { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
