using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductReviewDao : AbstractDao<ProductReviewModel>
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
 from ProductReview";

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
        
        public override string InsertQuery => @"Insert Into ProductReview
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
            @"Update ProductReview
Set
    ReviewDate=@ReviewDate,
    EmailAddress=@EmailAddress,
    Rating=@Rating,
    ModifiedDate=@ModifiedDate

Where
ProductReviewID=@ProductReviewID  AND 
ProductID=@ProductID  AND 
ReviewerName=@ReviewerName  AND 
Comments=@Comments 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductReviewModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ReviewDate", updated.ReviewDate);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", updated.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@Rating", updated.Rating);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductReviewModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductReviewID", updated.ProductReviewID);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReviewerName", updated.ReviewerName);
            sqlCommand.Parameters.AddWithValue("@Comments", updated.Comments);
        }

        public override string DeleteQuery =>
@"delete from
    ProductReview
where
ProductReviewID=@ProductReviewID  AND 
ProductID=@ProductID  AND 
ReviewerName=@ReviewerName  AND 
Comments=@Comments 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductReviewModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductReviewID", deleted.ProductReviewID);
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReviewerName", deleted.ReviewerName);
            sqlCommand.Parameters.AddWithValue("@Comments", deleted.Comments);
        }
    }
}
