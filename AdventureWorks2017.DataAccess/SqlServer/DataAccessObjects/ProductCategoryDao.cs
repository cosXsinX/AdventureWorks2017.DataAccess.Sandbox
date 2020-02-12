
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductCategoryDao : AbstractDaoWithPrimaryKey<ProductCategoryModel,ProductCategoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [ProductCategoryID],
             [Name],
             [rowguid],
             [ModifiedDate]
 from [Production].[ProductCategory]";

        protected override ProductCategoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductCategoryModel();
             result.ProductCategoryID = (int)(dataReader["ProductCategoryID"]);
             result.Name = (string)(dataReader["Name"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[ProductCategory]
(
[Name],
[rowguid],
[ModifiedDate]
)
output 
inserted.[ProductCategoryID]

VALUES
(
@Name,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductCategoryModel inserted)
        {
            inserted.ProductCategoryID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductCategoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Production].[ProductCategory]
Set
    [Name]=@Name,
    [rowguid]=@rowguid,
    [ModifiedDate]=@ModifiedDate

Where
[ProductCategoryID]=@ProductCategoryID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductCategoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductCategoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", updated.ProductCategoryID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[ProductCategory]
where
[ProductCategoryID]=@ProductCategoryID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductCategoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", deleted.ProductCategoryID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductCategoryID=@ProductCategoryID 
";

        public override void MapPrimaryParameters(ProductCategoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", key.ProductCategoryID);

        }

    }
}
