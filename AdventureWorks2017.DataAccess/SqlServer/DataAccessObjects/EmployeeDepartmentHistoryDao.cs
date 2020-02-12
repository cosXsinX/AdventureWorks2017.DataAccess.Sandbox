
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class EmployeeDepartmentHistoryDao : AbstractDaoWithPrimaryKey<EmployeeDepartmentHistoryModel,EmployeeDepartmentHistoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [BusinessEntityID],
             [DepartmentID],
             [ShiftID],
             [StartDate],
             [EndDate],
             [ModifiedDate]
 from [HumanResources].[EmployeeDepartmentHistory]";

        protected override EmployeeDepartmentHistoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new EmployeeDepartmentHistoryModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.DepartmentID = (short)(dataReader["DepartmentID"]);
             result.ShiftID = (byte)(dataReader["ShiftID"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime?)(dataReader["EndDate"] is DBNull ? null : dataReader["EndDate"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [HumanResources].[EmployeeDepartmentHistory]
(
[BusinessEntityID],
[DepartmentID],
[ShiftID],
[StartDate],
[EndDate],
[ModifiedDate]
)

VALUES
(
@BusinessEntityID,
@DepartmentID,
@ShiftID,
@StartDate,
@EndDate,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, EmployeeDepartmentHistoryModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, EmployeeDepartmentHistoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", inserted.DepartmentID);
            sqlCommand.Parameters.AddWithValue("@ShiftID", inserted.ShiftID);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [HumanResources].[EmployeeDepartmentHistory]
Set
    [EndDate]=@EndDate,
    [ModifiedDate]=@ModifiedDate

Where
[BusinessEntityID]=@BusinessEntityID  AND 
[DepartmentID]=@DepartmentID  AND 
[ShiftID]=@ShiftID  AND 
[StartDate]=@StartDate 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, EmployeeDepartmentHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, EmployeeDepartmentHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", updated.DepartmentID);
            sqlCommand.Parameters.AddWithValue("@ShiftID", updated.ShiftID);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
        }

        public override string DeleteQuery =>
@"delete from
    [HumanResources].[EmployeeDepartmentHistory]
where
[BusinessEntityID]=@BusinessEntityID  AND 
[DepartmentID]=@DepartmentID  AND 
[ShiftID]=@ShiftID  AND 
[StartDate]=@StartDate 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, EmployeeDepartmentHistoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", deleted.DepartmentID);
            sqlCommand.Parameters.AddWithValue("@ShiftID", deleted.ShiftID);
            sqlCommand.Parameters.AddWithValue("@StartDate", deleted.StartDate);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID  AND 
DepartmentID=@DepartmentID  AND 
ShiftID=@ShiftID  AND 
StartDate=@StartDate 
";

        public override void MapPrimaryParameters(EmployeeDepartmentHistoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@DepartmentID", key.DepartmentID);
            sqlCommand.Parameters.AddWithValue("@ShiftID", key.ShiftID);
            sqlCommand.Parameters.AddWithValue("@StartDate", key.StartDate);

        }

    }
}
