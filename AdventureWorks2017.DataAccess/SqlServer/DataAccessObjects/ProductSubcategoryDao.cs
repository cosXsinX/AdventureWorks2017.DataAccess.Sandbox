
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductSubcategoryDao : AbstractDaoWithPrimaryKey<ProductSubcategoryModel,ProductSubcategoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductSubcategoryID,
             ProductCategoryID,
             Name,
             rowguid,
             ModifiedDate
 from Production.ProductSubcategory";

        protected override ProductSubcategoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductSubcategoryModel();
             result.ProductSubcategoryID = (int)(dataReader["ProductSubcategoryID"]);
             result.ProductCategoryID = (int)(dataReader["ProductCategoryID"]);
             result.Name = (string)(dataReader["Name"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductSubcategory
(
ProductCategoryID,
Name,
rowguid,
ModifiedDate
)
output 
inserted.ProductSubcategoryID

VALUES
(
@ProductCategoryID,
@Name,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductSubcategoryModel inserted)
        {
            inserted.ProductSubcategoryID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", inserted.ProductCategoryID);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductSubcategory
Set
    ProductCategoryID=@ProductCategoryID,
    Name=@Name,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
ProductSubcategoryID=@ProductSubcategoryID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", updated.ProductCategoryID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", updated.ProductSubcategoryID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductSubcategory
where
ProductSubcategoryID=@ProductSubcategoryID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", deleted.ProductSubcategoryID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductSubcategoryID=@ProductSubcategoryID 
";

        public override void MapPrimaryParameters(ProductSubcategoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", key.ProductSubcategoryID);

        }

    }
}
