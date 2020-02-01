
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductDescriptionDao : AbstractDaoWithPrimaryKey<ProductDescriptionModel,ProductDescriptionModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductDescriptionID,
             Description,
             rowguid,
             ModifiedDate
 from Production.ProductDescription";

        protected override ProductDescriptionModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductDescriptionModel();
             result.ProductDescriptionID = (int)(dataReader["ProductDescriptionID"]);
             result.Description = (string)(dataReader["Description"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductDescription
(
Description,
rowguid,
ModifiedDate
)
output 
inserted.ProductDescriptionID

VALUES
(
@Description,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductDescriptionModel inserted)
        {
            inserted.ProductDescriptionID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Description", inserted.Description);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductDescription
Set
    Description=@Description,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
ProductDescriptionID=@ProductDescriptionID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Description", updated.Description);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", updated.ProductDescriptionID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductDescription
where
ProductDescriptionID=@ProductDescriptionID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", deleted.ProductDescriptionID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductDescriptionID=@ProductDescriptionID 
";

        public override void MapPrimaryParameters(ProductDescriptionModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", key.ProductDescriptionID);

        }

    }
}
