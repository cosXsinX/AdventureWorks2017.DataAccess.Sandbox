
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductDocumentDao : AbstractDaoWithPrimaryKey<ProductDocumentModel,ProductDocumentModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductID,
             DocumentNode,
             ModifiedDate
 from Production.ProductDocument";

        protected override ProductDocumentModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductDocumentModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.DocumentNode = (Microsoft.SqlServer.Types.SqlHierarchyId)(dataReader["DocumentNode"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductDocument
(
ProductID,
DocumentNode,
ModifiedDate
)

VALUES
(
@ProductID,
@DocumentNode,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductDocumentModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductDocumentModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@DocumentNode", inserted.DocumentNode);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductDocument
Set
    ModifiedDate=@ModifiedDate

Where
ProductID=@ProductID  AND 
DocumentNode=@DocumentNode 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductDocumentModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductDocumentModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@DocumentNode", updated.DocumentNode);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductDocument
where
ProductID=@ProductID  AND 
DocumentNode=@DocumentNode 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductDocumentModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@DocumentNode", deleted.DocumentNode);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductID=@ProductID  AND 
DocumentNode=@DocumentNode 
";

        public override void MapPrimaryParameters(ProductDocumentModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);
            sqlCommand.Parameters.AddWithValue("@DocumentNode", key.DocumentNode);

        }

    }
}
