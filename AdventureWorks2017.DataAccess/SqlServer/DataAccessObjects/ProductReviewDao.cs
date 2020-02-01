
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductReviewDao : AbstractDaoWithPrimaryKey<ProductReviewModel,ProductReviewModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductReviewID,
             ProductID,
             ReviewerName,
             ReviewDate,
             EmailAddress,
             Rating,
             Comments,
             ModifiedDate
 from Production.ProductReview";

        protected override ProductReviewModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductReviewModel();
             result.ProductReviewID = (int)(dataReader["ProductReviewID"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.ReviewerName = (string)(dataReader["ReviewerName"]);
             result.ReviewDate = (DateTime)(dataReader["ReviewDate"]);
             result.EmailAddress = (string)(dataReader["EmailAddress"]);
             result.Rating = (int)(dataReader["Rating"]);
             result.Comments = (string)(dataReader["Comments"] is DBNull ? null : dataReader["Comments"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductReview
(
ProductID,
ReviewerName,
ReviewDate,
EmailAddress,
Rating,
Comments,
ModifiedDate
)
output 
inserted.ProductReviewID

VALUES
(
@ProductID,
@ReviewerName,
@ReviewDate,
@EmailAddress,
@Rating,
@Comments,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductReviewModel inserted)
        {
            inserted.ProductReviewID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductReviewModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReviewerName", inserted.ReviewerName);
            sqlCommand.Parameters.AddWithValue("@ReviewDate", inserted.ReviewDate);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", inserted.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@Rating", inserted.Rating);
            sqlCommand.Parameters.AddWithValue("@Comments", inserted.Comments);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductReview
Set
    ProductID=@ProductID,
    ReviewerName=@ReviewerName,
    ReviewDate=@ReviewDate,
    EmailAddress=@EmailAddress,
    Rating=@Rating,
    Comments=@Comments,
    ModifiedDate=@ModifiedDate

Where
ProductReviewID=@ProductReviewID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductReviewModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReviewerName", updated.ReviewerName);
            sqlCommand.Parameters.AddWithValue("@ReviewDate", updated.ReviewDate);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", updated.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@Rating", updated.Rating);
            sqlCommand.Parameters.AddWithValue("@Comments", updated.Comments);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductReviewModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductReviewID", updated.ProductReviewID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductReview
where
ProductReviewID=@ProductReviewID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductReviewModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductReviewID", deleted.ProductReviewID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductReviewID=@ProductReviewID 
";

        public override void MapPrimaryParameters(ProductReviewModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductReviewID", key.ProductReviewID);

        }

    }
}
