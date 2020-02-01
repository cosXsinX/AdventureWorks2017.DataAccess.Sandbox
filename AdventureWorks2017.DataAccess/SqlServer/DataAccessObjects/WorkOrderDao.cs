
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class WorkOrderDao : AbstractDaoWithPrimaryKey<WorkOrderModel,WorkOrderModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             WorkOrderID,
             ProductID,
             OrderQty,
             StockedQty,
             ScrappedQty,
             StartDate,
             EndDate,
             DueDate,
             ScrapReasonID,
             ModifiedDate
 from Production.WorkOrder";

        protected override WorkOrderModel ToModel(SqlDataReader dataReader)
        {
            var result = new WorkOrderModel();
             result.WorkOrderID = (int)(dataReader["WorkOrderID"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.OrderQty = (int)(dataReader["OrderQty"]);
             result.StockedQty = (int)(dataReader["StockedQty"]);
             result.ScrappedQty = (short)(dataReader["ScrappedQty"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime)(dataReader["EndDate"] is DBNull ? null : dataReader["EndDate"]);
             result.DueDate = (DateTime)(dataReader["DueDate"]);
             result.ScrapReasonID = (short)(dataReader["ScrapReasonID"] is DBNull ? null : dataReader["ScrapReasonID"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.WorkOrder
(
ProductID,
OrderQty,
StockedQty,
ScrappedQty,
StartDate,
EndDate,
DueDate,
ScrapReasonID,
ModifiedDate
)
output 
inserted.WorkOrderID

VALUES
(
@ProductID,
@OrderQty,
@StockedQty,
@ScrappedQty,
@StartDate,
@EndDate,
@DueDate,
@ScrapReasonID,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, WorkOrderModel inserted)
        {
            inserted.WorkOrderID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, WorkOrderModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@OrderQty", inserted.OrderQty);
            sqlCommand.Parameters.AddWithValue("@StockedQty", inserted.StockedQty);
            sqlCommand.Parameters.AddWithValue("@ScrappedQty", inserted.ScrappedQty);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@DueDate", inserted.DueDate);
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", inserted.ScrapReasonID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.WorkOrder
Set
    ProductID=@ProductID,
    OrderQty=@OrderQty,
    StockedQty=@StockedQty,
    ScrappedQty=@ScrappedQty,
    StartDate=@StartDate,
    EndDate=@EndDate,
    DueDate=@DueDate,
    ScrapReasonID=@ScrapReasonID,
    ModifiedDate=@ModifiedDate

Where
WorkOrderID=@WorkOrderID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, WorkOrderModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@OrderQty", updated.OrderQty);
            sqlCommand.Parameters.AddWithValue("@StockedQty", updated.StockedQty);
            sqlCommand.Parameters.AddWithValue("@ScrappedQty", updated.ScrappedQty);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@DueDate", updated.DueDate);
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", updated.ScrapReasonID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, WorkOrderModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", updated.WorkOrderID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.WorkOrder
where
WorkOrderID=@WorkOrderID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, WorkOrderModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", deleted.WorkOrderID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"WorkOrderID=@WorkOrderID 
";

        public override void MapPrimaryParameters(WorkOrderModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", key.WorkOrderID);

        }

    }
}
