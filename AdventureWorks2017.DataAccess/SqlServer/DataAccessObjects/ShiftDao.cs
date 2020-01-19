using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ShiftDao : AbstractDaoWithPrimaryKey<ShiftModel,ShiftModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ShiftID,
             Name,
             StartTime,
             EndTime,
             ModifiedDate
 from HumanResources.Shift";

        protected override ShiftModel ToModel(SqlDataReader dataReader)
        {
            var result = new ShiftModel();
             result.ShiftID = (byte)(dataReader["ShiftID"]);
             result.Name = (string)(dataReader["Name"]);
             result.StartTime = (TimeSpan)(dataReader["StartTime"]);
             result.EndTime = (TimeSpan)(dataReader["EndTime"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into HumanResources.Shift
(
Name,
StartTime,
EndTime,
ModifiedDate
)
output 
inserted.ShiftID

VALUES
(
@Name,
@StartTime,
@EndTime,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ShiftModel inserted)
        {
            inserted.ShiftID = (byte)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ShiftModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@StartTime", inserted.StartTime);
            sqlCommand.Parameters.AddWithValue("@EndTime", inserted.EndTime);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update HumanResources.Shift
Set
    Name=@Name,
    StartTime=@StartTime,
    EndTime=@EndTime,
    ModifiedDate=@ModifiedDate

Where
ShiftID=@ShiftID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ShiftModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@StartTime", updated.StartTime);
            sqlCommand.Parameters.AddWithValue("@EndTime", updated.EndTime);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ShiftModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ShiftID", updated.ShiftID);
        }

        public override string DeleteQuery =>
@"delete from
    HumanResources.Shift
where
ShiftID=@ShiftID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ShiftModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ShiftID", deleted.ShiftID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ShiftID=@ShiftID 
";

        public override void MapPrimaryParameters(ShiftModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ShiftID", key.ShiftID);

        }

    }
}
