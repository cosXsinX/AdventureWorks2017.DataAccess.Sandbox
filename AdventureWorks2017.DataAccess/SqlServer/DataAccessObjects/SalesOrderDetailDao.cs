using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesOrderDetailDao : AbstractDao<SalesOrderDetailModel>
    {
        public override string SelectQuery => @"select 
             SalesOrderID,
             SalesOrderDetailID,
             CarrierTrackingNumber,
             OrderQty,
             ProductID,
             SpecialOfferID,
             UnitPrice,
             UnitPriceDiscount,
             LineTotal,
             rowguid,
             ModifiedDate
 from SalesOrderDetail";

        protected override SalesOrderDetailModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesOrderDetailModel();
             result.SalesOrderID = (int)(dataReader["SalesOrderID"]);
             result.SalesOrderDetailID = (int)(dataReader["SalesOrderDetailID"]);
             result.CarrierTrackingNumber = (string)(dataReader["CarrierTrackingNumber"] is DBNull ? null : dataReader["CarrierTrackingNumber"]);
             result.OrderQty = (short)(dataReader["OrderQty"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.SpecialOfferID = (int)(dataReader["SpecialOfferID"]);
             result.UnitPrice = (decimal)(dataReader["UnitPrice"]);
             result.UnitPriceDiscount = (decimal)(dataReader["UnitPriceDiscount"]);
             result.LineTotal = (decimal)(dataReader["LineTotal"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into SalesOrderDetail
(
SalesOrderID,
CarrierTrackingNumber,
OrderQty,
ProductID,
SpecialOfferID,
UnitPrice,
UnitPriceDiscount,
LineTotal,
rowguid,
ModifiedDate
)
output 
inserted.SalesOrderDetailID

VALUES
(
@SalesOrderID,
@CarrierTrackingNumber,
@OrderQty,
@ProductID,
@SpecialOfferID,
@UnitPrice,
@UnitPriceDiscount,
@LineTotal,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesOrderDetailModel inserted)
        {
            inserted.SalesOrderDetailID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesOrderDetailModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", inserted.SalesOrderID);
            sqlCommand.Parameters.AddWithValue("@CarrierTrackingNumber", inserted.CarrierTrackingNumber);
            sqlCommand.Parameters.AddWithValue("@OrderQty", inserted.OrderQty);
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", inserted.SpecialOfferID);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", inserted.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@UnitPriceDiscount", inserted.UnitPriceDiscount);
            sqlCommand.Parameters.AddWithValue("@LineTotal", inserted.LineTotal);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update SalesOrderDetail
Set
    CarrierTrackingNumber=@CarrierTrackingNumber,
    OrderQty=@OrderQty,
    SpecialOfferID=@SpecialOfferID,
    UnitPrice=@UnitPrice,
    UnitPriceDiscount=@UnitPriceDiscount,
    LineTotal=@LineTotal,
    ModifiedDate=@ModifiedDate

Where
SalesOrderID=@SalesOrderID  AND 
SalesOrderDetailID=@SalesOrderDetailID  AND 
ProductID=@ProductID  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesOrderDetailModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CarrierTrackingNumber", updated.CarrierTrackingNumber);
            sqlCommand.Parameters.AddWithValue("@OrderQty", updated.OrderQty);
            sqlCommand.Parameters.AddWithValue("@SpecialOfferID", updated.SpecialOfferID);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", updated.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@UnitPriceDiscount", updated.UnitPriceDiscount);
            sqlCommand.Parameters.AddWithValue("@LineTotal", updated.LineTotal);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesOrderDetailModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", updated.SalesOrderID);
            sqlCommand.Parameters.AddWithValue("@SalesOrderDetailID", updated.SalesOrderDetailID);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    SalesOrderDetail
where
SalesOrderID=@SalesOrderID  AND 
SalesOrderDetailID=@SalesOrderDetailID  AND 
ProductID=@ProductID  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesOrderDetailModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", deleted.SalesOrderID);
            sqlCommand.Parameters.AddWithValue("@SalesOrderDetailID", deleted.SalesOrderDetailID);
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
