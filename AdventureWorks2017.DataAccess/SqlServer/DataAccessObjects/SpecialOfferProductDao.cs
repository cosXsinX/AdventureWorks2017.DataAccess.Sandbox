using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SpecialOfferProductDao : AbstractDao<SpecialOfferProductModel>
    {
        public override string SelectQuery => @"select 
             SpecialOfferID,
             ProductID,
             rowguid,
             ModifiedDate
 from SpecialOfferProduct";

        protected override SpecialOfferProductModel ToModel(SqlDataReader dataReader)
        {
            var result = new SpecialOfferProductModel();
             result.SpecialOfferID = (int)(dataReader["SpecialOfferID"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into SpecialOfferProduct
(
SpecialOfferID,
ProductID,
rowguid,
ModifiedDate
)

VALUES
(
@SpecialOfferID,
@ProductID,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SpecialOfferProductModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SpecialOfferProductModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", inserted.SpecialOfferID);
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update SpecialOfferProduct
Set
    ModifiedDate=@ModifiedDate

Where
SpecialOfferID=@SpecialOfferID  AND 
ProductID=@ProductID  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SpecialOfferProductModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SpecialOfferProductModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", updated.SpecialOfferID);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    SpecialOfferProduct
where
SpecialOfferID=@SpecialOfferID  AND 
ProductID=@ProductID  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SpecialOfferProductModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", deleted.SpecialOfferID);
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
