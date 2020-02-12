
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductModelProductDescriptionCultureDao : AbstractDaoWithPrimaryKey<ProductModelProductDescriptionCultureModel,ProductModelProductDescriptionCultureModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [ProductModelID],
             [ProductDescriptionID],
             [CultureID],
             [ModifiedDate]
 from [Production].[ProductModelProductDescriptionCulture]";

        protected override ProductModelProductDescriptionCultureModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductModelProductDescriptionCultureModel();
             result.ProductModelID = (int)(dataReader["ProductModelID"]);
             result.ProductDescriptionID = (int)(dataReader["ProductDescriptionID"]);
             result.CultureID = (string)(dataReader["CultureID"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[ProductModelProductDescriptionCulture]
(
[ProductModelID],
[ProductDescriptionID],
[CultureID],
[ModifiedDate]
)

VALUES
(
@ProductModelID,
@ProductDescriptionID,
@CultureID,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductModelProductDescriptionCultureModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductModelProductDescriptionCultureModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", inserted.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", inserted.ProductDescriptionID);
            sqlCommand.Parameters.AddWithValue("@CultureID", inserted.CultureID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Production].[ProductModelProductDescriptionCulture]
Set
    [ModifiedDate]=@ModifiedDate

Where
[ProductModelID]=@ProductModelID  AND 
[ProductDescriptionID]=@ProductDescriptionID  AND 
[CultureID]=@CultureID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductModelProductDescriptionCultureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductModelProductDescriptionCultureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", updated.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", updated.ProductDescriptionID);
            sqlCommand.Parameters.AddWithValue("@CultureID", updated.CultureID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[ProductModelProductDescriptionCulture]
where
[ProductModelID]=@ProductModelID  AND 
[ProductDescriptionID]=@ProductDescriptionID  AND 
[CultureID]=@CultureID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductModelProductDescriptionCultureModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", deleted.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", deleted.ProductDescriptionID);
            sqlCommand.Parameters.AddWithValue("@CultureID", deleted.CultureID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductModelID=@ProductModelID  AND 
ProductDescriptionID=@ProductDescriptionID  AND 
CultureID=@CultureID 
";

        public override void MapPrimaryParameters(ProductModelProductDescriptionCultureModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", key.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@ProductDescriptionID", key.ProductDescriptionID);
            sqlCommand.Parameters.AddWithValue("@CultureID", key.CultureID);

        }

    }
}
