using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks2017.Models
{
    public struct ProductDocumentModelPrimaryKey
    {
        public int ProductID { get; set; }
        public Microsoft.SqlServer.Types.SqlHierarchyId DocumentNode { get; set; }

    }

    public class ProductDocumentModel
    {
        public int ProductID { get; set; }
        public Microsoft.SqlServer.Types.SqlHierarchyId DocumentNode { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
