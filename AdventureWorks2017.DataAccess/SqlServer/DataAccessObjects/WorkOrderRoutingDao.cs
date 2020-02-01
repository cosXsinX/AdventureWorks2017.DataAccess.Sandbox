
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class WorkOrderRoutingDao : AbstractDaoWithPrimaryKey<WorkOrderRoutingModel,WorkOrderRoutingModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             WorkOrderID,
             ProductID,
             OperationSequence,
             LocationID,
             ScheduledStartDate,
             ScheduledEndDate,
             ActualStartDate,
             ActualEndDate,
             ActualResourceHrs,
             PlannedCost,
             ActualCost,
             ModifiedDate
 from Production.WorkOrderRouting";

        protected override WorkOrderRoutingModel ToModel(SqlDataReader dataReader)
        {
            var result = new WorkOrderRoutingModel();
             result.WorkOrderID = (int)(dataReader["WorkOrderID"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.OperationSequence = (short)(dataReader["OperationSequence"]);
             result.LocationID = (short)(dataReader["LocationID"]);
             result.ScheduledStartDate = (DateTime)(dataReader["ScheduledStartDate"]);
             result.ScheduledEndDate = (DateTime)(dataReader["ScheduledEndDate"]);
             result.ActualStartDate = (DateTime)(dataReader["ActualStartDate"] is DBNull ? null : dataReader["ActualStartDate"]);
             result.ActualEndDate = (DateTime)(dataReader["ActualEndDate"] is DBNull ? null : dataReader["ActualEndDate"]);
             result.ActualResourceHrs = (decimal)(dataReader["ActualResourceHrs"] is DBNull ? null : dataReader["ActualResourceHrs"]);
             result.PlannedCost = (decimal)(dataReader["PlannedCost"]);
             result.ActualCost = (decimal)(dataReader["ActualCost"] is DBNull ? null : dataReader["ActualCost"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.WorkOrderRouting
(
WorkOrderID,
ProductID,
OperationSequence,
LocationID,
ScheduledStartDate,
ScheduledEndDate,
ActualStartDate,
ActualEndDate,
ActualResourceHrs,
PlannedCost,
ActualCost,
ModifiedDate
)

VALUES
(
@WorkOrderID,
@ProductID,
@OperationSequence,
@LocationID,
@ScheduledStartDate,
@ScheduledEndDate,
@ActualStartDate,
@ActualEndDate,
@ActualResourceHrs,
@PlannedCost,
@ActualCost,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, WorkOrderRoutingModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, WorkOrderRoutingModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", inserted.WorkOrderID);
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@OperationSequence", inserted.OperationSequence);
            sqlCommand.Parameters.AddWithValue("@LocationID", inserted.LocationID);
            sqlCommand.Parameters.AddWithValue("@ScheduledStartDate", inserted.ScheduledStartDate);
            sqlCommand.Parameters.AddWithValue("@ScheduledEndDate", inserted.ScheduledEndDate);
            sqlCommand.Parameters.AddWithValue("@ActualStartDate", inserted.ActualStartDate);
            sqlCommand.Parameters.AddWithValue("@ActualEndDate", inserted.ActualEndDate);
            sqlCommand.Parameters.AddWithValue("@ActualResourceHrs", inserted.ActualResourceHrs);
            sqlCommand.Parameters.AddWithValue("@PlannedCost", inserted.PlannedCost);
            sqlCommand.Parameters.AddWithValue("@ActualCost", inserted.ActualCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.WorkOrderRouting
Set
    LocationID=@LocationID,
    ScheduledStartDate=@ScheduledStartDate,
    ScheduledEndDate=@ScheduledEndDate,
    ActualStartDate=@ActualStartDate,
    ActualEndDate=@ActualEndDate,
    ActualResourceHrs=@ActualResourceHrs,
    PlannedCost=@PlannedCost,
    ActualCost=@ActualCost,
    ModifiedDate=@ModifiedDate

Where
WorkOrderID=@WorkOrderID  AND 
ProductID=@ProductID  AND 
OperationSequence=@OperationSequence 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, WorkOrderRoutingModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@LocationID", updated.LocationID);
            sqlCommand.Parameters.AddWithValue("@ScheduledStartDate", updated.ScheduledStartDate);
            sqlCommand.Parameters.AddWithValue("@ScheduledEndDate", updated.ScheduledEndDate);
            sqlCommand.Parameters.AddWithValue("@ActualStartDate", updated.ActualStartDate);
            sqlCommand.Parameters.AddWithValue("@ActualEndDate", updated.ActualEndDate);
            sqlCommand.Parameters.AddWithValue("@ActualResourceHrs", updated.ActualResourceHrs);
            sqlCommand.Parameters.AddWithValue("@PlannedCost", updated.PlannedCost);
            sqlCommand.Parameters.AddWithValue("@ActualCost", updated.ActualCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, WorkOrderRoutingModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", updated.WorkOrderID);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@OperationSequence", updated.OperationSequence);
        }

        public override string DeleteQuery =>
@"delete from
    Production.WorkOrderRouting
where
WorkOrderID=@WorkOrderID  AND 
ProductID=@ProductID  AND 
OperationSequence=@OperationSequence 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, WorkOrderRoutingModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", deleted.WorkOrderID);
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@OperationSequence", deleted.OperationSequence);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"WorkOrderID=@WorkOrderID  AND 
ProductID=@ProductID  AND 
OperationSequence=@OperationSequence 
";

        public override void MapPrimaryParameters(WorkOrderRoutingModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@WorkOrderID", key.WorkOrderID);
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);
            sqlCommand.Parameters.AddWithValue("@OperationSequence", key.OperationSequence);

        }

    }
}
