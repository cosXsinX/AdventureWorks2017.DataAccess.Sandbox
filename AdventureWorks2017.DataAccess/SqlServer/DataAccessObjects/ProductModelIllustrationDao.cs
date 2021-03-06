
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductModelIllustrationDao : AbstractDaoWithPrimaryKey<ProductModelIllustrationModel,ProductModelIllustrationModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [ProductModelID],
             [IllustrationID],
             [ModifiedDate]
 from [Production].[ProductModelIllustration]";

        protected override ProductModelIllustrationModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductModelIllustrationModel();
             result.ProductModelID = (int)(dataReader["ProductModelID"]);
             result.IllustrationID = (int)(dataReader["IllustrationID"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[ProductModelIllustration]
(
[ProductModelID],
[IllustrationID],
[ModifiedDate]
)

VALUES
(
@ProductModelID,
@IllustrationID,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductModelIllustrationModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductModelIllustrationModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", inserted.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@IllustrationID", inserted.IllustrationID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Production].[ProductModelIllustration]
Set
    [ModifiedDate]=@ModifiedDate

Where
[ProductModelID]=@ProductModelID  AND 
[IllustrationID]=@IllustrationID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductModelIllustrationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductModelIllustrationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", updated.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@IllustrationID", updated.IllustrationID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[ProductModelIllustration]
where
[ProductModelID]=@ProductModelID  AND 
[IllustrationID]=@IllustrationID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductModelIllustrationModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", deleted.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@IllustrationID", deleted.IllustrationID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductModelID=@ProductModelID  AND 
IllustrationID=@IllustrationID 
";

        public override void MapPrimaryParameters(ProductModelIllustrationModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", key.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@IllustrationID", key.IllustrationID);

        }

    }
}
