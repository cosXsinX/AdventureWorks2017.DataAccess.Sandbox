using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductDescriptionDao : AbstractDao<ProductDescriptionModel>
    {
        public override string SelectQuery => @"select 
             ProductDescriptionID,
             Description,
             rowguid,
             ModifiedDate
 from ProductDescription";

        protected override ProductDescriptionModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductDescriptionModel();
             result.ProductDescriptionID = (int)(dataReader["ProductDescriptionID"]);
             result.Description = (string)(dataReader["Description"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into ProductDescription
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
            @"Update ProductDescription
Set
    Description=@Description,
    ModifiedDate=@ModifiedDate

Where
ProductDescriptionID=@ProductDescriptionID  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Description", updated.Description);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", updated.ProductDescriptionID);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    ProductDescription
where
ProductDescriptionID=@ProductDescriptionID  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductDescriptionModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", deleted.ProductDescriptionID);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
