using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductProductPhotoDao : AbstractDaoWithPrimaryKey<ProductProductPhotoModel,ProductProductPhotoModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductID,
             ProductPhotoID,
             Primary,
             ModifiedDate
 from Production.ProductProductPhoto";

        protected override ProductProductPhotoModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductProductPhotoModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.ProductPhotoID = (int)(dataReader["ProductPhotoID"]);
             result.Primary = (bool)(dataReader["Primary"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductProductPhoto
(
ProductID,
ProductPhotoID,
Primary,
ModifiedDate
)

VALUES
(
@ProductID,
@ProductPhotoID,
@Primary,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductProductPhotoModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductProductPhotoModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@ProductPhotoID", inserted.ProductPhotoID);
            sqlCommand.Parameters.AddWithValue("@Primary", inserted.Primary);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductProductPhoto
Set
    Primary=@Primary,
    ModifiedDate=@ModifiedDate

Where
ProductID=@ProductID  AND 
ProductPhotoID=@ProductPhotoID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductProductPhotoModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Primary", updated.Primary);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductProductPhotoModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@ProductPhotoID", updated.ProductPhotoID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductProductPhoto
where
ProductID=@ProductID  AND 
ProductPhotoID=@ProductPhotoID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductProductPhotoModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@ProductPhotoID", deleted.ProductPhotoID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductID=@ProductID  AND 
ProductPhotoID=@ProductPhotoID 
";

        public override void MapPrimaryParameters(ProductProductPhotoModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);
            sqlCommand.Parameters.AddWithValue("@ProductPhotoID", key.ProductPhotoID);

        }

    }
}
