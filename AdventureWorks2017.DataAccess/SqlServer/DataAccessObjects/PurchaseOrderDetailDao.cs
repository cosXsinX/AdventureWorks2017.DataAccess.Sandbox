using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PurchaseOrderDetailDao : AbstractDaoWithPrimaryKey<PurchaseOrderDetailModel,PurchaseOrderDetailModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             PurchaseOrderID,
             PurchaseOrderDetailID,
             DueDate,
             OrderQty,
             ProductID,
             UnitPrice,
             LineTotal,
             ReceivedQty,
             RejectedQty,
             StockedQty,
             ModifiedDate
 from Purchasing.PurchaseOrderDetail";

        protected override PurchaseOrderDetailModel ToModel(SqlDataReader dataReader)
        {
            var result = new PurchaseOrderDetailModel();
             result.PurchaseOrderID = (int)(dataReader["PurchaseOrderID"]);
             result.PurchaseOrderDetailID = (int)(dataReader["PurchaseOrderDetailID"]);
             result.DueDate = (DateTime)(dataReader["DueDate"]);
             result.OrderQty = (short)(dataReader["OrderQty"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.UnitPrice = (decimal)(dataReader["UnitPrice"]);
             result.LineTotal = (decimal)(dataReader["LineTotal"]);
             result.ReceivedQty = (decimal)(dataReader["ReceivedQty"]);
             result.RejectedQty = (decimal)(dataReader["RejectedQty"]);
             result.StockedQty = (decimal)(dataReader["StockedQty"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Purchasing.PurchaseOrderDetail
(
PurchaseOrderID,
DueDate,
OrderQty,
ProductID,
UnitPrice,
LineTotal,
ReceivedQty,
RejectedQty,
StockedQty,
ModifiedDate
)
output 
inserted.PurchaseOrderDetailID

VALUES
(
@PurchaseOrderID,
@DueDate,
@OrderQty,
@ProductID,
@UnitPrice,
@LineTotal,
@ReceivedQty,
@RejectedQty,
@StockedQty,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PurchaseOrderDetailModel inserted)
        {
            inserted.PurchaseOrderDetailID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PurchaseOrderDetailModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", inserted.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@DueDate", inserted.DueDate);
            sqlCommand.Parameters.AddWithValue("@OrderQty", inserted.OrderQty);
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", inserted.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@LineTotal", inserted.LineTotal);
            sqlCommand.Parameters.AddWithValue("@ReceivedQty", inserted.ReceivedQty);
            sqlCommand.Parameters.AddWithValue("@RejectedQty", inserted.RejectedQty);
            sqlCommand.Parameters.AddWithValue("@StockedQty", inserted.StockedQty);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Purchasing.PurchaseOrderDetail
Set
    DueDate=@DueDate,
    OrderQty=@OrderQty,
    ProductID=@ProductID,
    UnitPrice=@UnitPrice,
    LineTotal=@LineTotal,
    ReceivedQty=@ReceivedQty,
    RejectedQty=@RejectedQty,
    StockedQty=@StockedQty,
    ModifiedDate=@ModifiedDate

Where
PurchaseOrderID=@PurchaseOrderID  AND 
PurchaseOrderDetailID=@PurchaseOrderDetailID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PurchaseOrderDetailModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@DueDate", updated.DueDate);
            sqlCommand.Parameters.AddWithValue("@OrderQty", updated.OrderQty);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", updated.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@LineTotal", updated.LineTotal);
            sqlCommand.Parameters.AddWithValue("@ReceivedQty", updated.ReceivedQty);
            sqlCommand.Parameters.AddWithValue("@RejectedQty", updated.RejectedQty);
            sqlCommand.Parameters.AddWithValue("@StockedQty", updated.StockedQty);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PurchaseOrderDetailModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", updated.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderDetailID", updated.PurchaseOrderDetailID);
        }

        public override string DeleteQuery =>
@"delete from
    Purchasing.PurchaseOrderDetail
where
PurchaseOrderID=@PurchaseOrderID  AND 
PurchaseOrderDetailID=@PurchaseOrderDetailID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PurchaseOrderDetailModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", deleted.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderDetailID", deleted.PurchaseOrderDetailID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"PurchaseOrderID=@PurchaseOrderID  AND 
PurchaseOrderDetailID=@PurchaseOrderDetailID 
";

        public override void MapPrimaryParameters(PurchaseOrderDetailModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", key.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderDetailID", key.PurchaseOrderDetailID);

        }

    }
}
