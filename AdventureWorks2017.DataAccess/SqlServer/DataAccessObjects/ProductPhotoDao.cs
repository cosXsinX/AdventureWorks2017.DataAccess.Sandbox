using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductPhotoDao : AbstractDao<ProductPhotoModel>
    {
        public override string SelectQuery => @"select 
             ProductPhotoID,
             ThumbNailPhoto,
             ThumbnailPhotoFileName,
             LargePhoto,
             LargePhotoFileName,
             ModifiedDate
 from ProductPhoto";

        protected override ProductPhotoModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductPhotoModel();
             result.ProductPhotoID = (int)(dataReader["ProductPhotoID"]);
             result.ThumbNailPhoto = (byte[])(dataReader["ThumbNailPhoto"] is DBNull ? null : dataReader["ThumbNailPhoto"]);
             result.ThumbnailPhotoFileName = (string)(dataReader["ThumbnailPhotoFileName"] is DBNull ? null : dataReader["ThumbnailPhotoFileName"]);
             result.LargePhoto = (byte[])(dataReader["LargePhoto"] is DBNull ? null : dataReader["LargePhoto"]);
             result.LargePhotoFileName = (string)(dataReader["LargePhotoFileName"] is DBNull ? null : dataReader["LargePhotoFileName"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into ProductPhoto
(
ThumbNailPhoto,
ThumbnailPhotoFileName,
LargePhoto,
LargePhotoFileName,
ModifiedDate
)
output 
inserted.ProductPhotoID

VALUES
(
@ThumbNailPhoto,
@ThumbnailPhotoFileName,
@LargePhoto,
@LargePhotoFileName,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductPhotoModel inserted)
        {
            inserted.ProductPhotoID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductPhotoModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ThumbNailPhoto", inserted.ThumbNailPhoto);
            sqlCommand.Parameters.AddWithValue("@ThumbnailPhotoFileName", inserted.ThumbnailPhotoFileName);
            sqlCommand.Parameters.AddWithValue("@LargePhoto", inserted.LargePhoto);
            sqlCommand.Parameters.AddWithValue("@LargePhotoFileName", inserted.LargePhotoFileName);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update ProductPhoto
Set
    ThumbNailPhoto=@ThumbNailPhoto,
    ThumbnailPhotoFileName=@ThumbnailPhotoFileName,
    LargePhoto=@LargePhoto,
    LargePhotoFileName=@LargePhotoFileName,
    ModifiedDate=@ModifiedDate

Where
ProductPhotoID=@ProductPhotoID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductPhotoModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ThumbNailPhoto", updated.ThumbNailPhoto);
            sqlCommand.Parameters.AddWithValue("@ThumbnailPhotoFileName", updated.ThumbnailPhotoFileName);
            sqlCommand.Parameters.AddWithValue("@LargePhoto", updated.LargePhoto);
            sqlCommand.Parameters.AddWithValue("@LargePhotoFileName", updated.LargePhotoFileName);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductPhotoModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductPhotoID", updated.ProductPhotoID);
        }

        public override string DeleteQuery =>
@"delete from
    ProductPhoto
where
ProductPhotoID=@ProductPhotoID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductPhotoModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductPhotoID", deleted.ProductPhotoID);
        }
    }
}
