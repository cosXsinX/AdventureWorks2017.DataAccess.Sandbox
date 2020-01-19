using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SpecialOfferDao : AbstractDaoWithPrimaryKey<SpecialOfferModel,SpecialOfferModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             SpecialOfferID,
             Description,
             DiscountPct,
             Type,
             Category,
             StartDate,
             EndDate,
             MinQty,
             MaxQty,
             rowguid,
             ModifiedDate
 from Sales.SpecialOffer";

        protected override SpecialOfferModel ToModel(SqlDataReader dataReader)
        {
            var result = new SpecialOfferModel();
             result.SpecialOfferID = (int)(dataReader["SpecialOfferID"]);
             result.Description = (string)(dataReader["Description"]);
             result.DiscountPct = (decimal)(dataReader["DiscountPct"]);
             result.Type = (string)(dataReader["Type"]);
             result.Category = (string)(dataReader["Category"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime)(dataReader["EndDate"]);
             result.MinQty = (int)(dataReader["MinQty"]);
             result.MaxQty = (int)(dataReader["MaxQty"] is DBNull ? null : dataReader["MaxQty"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Sales.SpecialOffer
(
Description,
DiscountPct,
Type,
Category,
StartDate,
EndDate,
MinQty,
MaxQty,
rowguid,
ModifiedDate
)
output 
inserted.SpecialOfferID

VALUES
(
@Description,
@DiscountPct,
@Type,
@Category,
@StartDate,
@EndDate,
@MinQty,
@MaxQty,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SpecialOfferModel inserted)
        {
            inserted.SpecialOfferID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SpecialOfferModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Description", inserted.Description);
            sqlCommand.Parameters.AddWithValue("@DiscountPct", inserted.DiscountPct);
            sqlCommand.Parameters.AddWithValue("@Type", inserted.Type);
            sqlCommand.Parameters.AddWithValue("@Category", inserted.Category);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@MinQty", inserted.MinQty);
            sqlCommand.Parameters.AddWithValue("@MaxQty", inserted.MaxQty);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Sales.SpecialOffer
Set
    Description=@Description,
    DiscountPct=@DiscountPct,
    Type=@Type,
    Category=@Category,
    StartDate=@StartDate,
    EndDate=@EndDate,
    MinQty=@MinQty,
    MaxQty=@MaxQty,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
SpecialOfferID=@SpecialOfferID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SpecialOfferModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Description", updated.Description);
            sqlCommand.Parameters.AddWithValue("@DiscountPct", updated.DiscountPct);
            sqlCommand.Parameters.AddWithValue("@Type", updated.Type);
            sqlCommand.Parameters.AddWithValue("@Category", updated.Category);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@MinQty", updated.MinQty);
            sqlCommand.Parameters.AddWithValue("@MaxQty", updated.MaxQty);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SpecialOfferModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", updated.SpecialOfferID);
        }

        public override string DeleteQuery =>
@"delete from
    Sales.SpecialOffer
where
SpecialOfferID=@SpecialOfferID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SpecialOfferModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", deleted.SpecialOfferID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"SpecialOfferID=@SpecialOfferID 
";

        public override void MapPrimaryParameters(SpecialOfferModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", key.SpecialOfferID);

        }

    }
}
