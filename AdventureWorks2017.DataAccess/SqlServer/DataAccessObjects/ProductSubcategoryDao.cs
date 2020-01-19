using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductSubcategoryDao : AbstractDao<ProductSubcategoryModel>
    {
        public override string SelectQuery => @"select 
             ProductSubcategoryID,
             ProductCategoryID,
             Name,
             rowguid,
             ModifiedDate
 from ProductSubcategory";

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
        
        public override string InsertQuery => @"Insert Into ProductSubcategory
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
            @"Update ProductSubcategory
Set
    ProductCategoryID=@ProductCategoryID,
    ModifiedDate=@ModifiedDate

Where
ProductSubcategoryID=@ProductSubcategoryID  AND 
Name=@Name  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductCategoryID", updated.ProductCategoryID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", updated.ProductSubcategoryID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    ProductSubcategory
where
ProductSubcategoryID=@ProductSubcategoryID  AND 
Name=@Name  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductSubcategoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", deleted.ProductSubcategoryID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
