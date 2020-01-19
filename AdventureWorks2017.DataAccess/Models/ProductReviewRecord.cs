using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductReviewModelPrimaryKey
    {
        public int ProductReviewID { get; set; }

    }

    public class ProductReviewModel
    {
        public int ProductReviewID { get; set; }
        public int ProductID { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
