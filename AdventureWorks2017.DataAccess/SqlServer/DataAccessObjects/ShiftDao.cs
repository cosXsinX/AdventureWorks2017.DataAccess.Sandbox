using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ShiftDao : AbstractDao<ShiftModel>
    {
        public override string SelectQuery => @"select 
             ShiftID,
             Name,
             StartTime,
             EndTime,
             ModifiedDate
 from Shift";

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
        
        public override string InsertQuery => @"Insert Into Shift
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
            @"Update Shift
Set
    ModifiedDate=@ModifiedDate

Where
ShiftID=@ShiftID  AND 
Name=@Name  AND 
StartTime=@StartTime  AND 
EndTime=@EndTime 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ShiftModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ShiftModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ShiftID", updated.ShiftID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@StartTime", updated.StartTime);
            sqlCommand.Parameters.AddWithValue("@EndTime", updated.EndTime);
        }

        public override string DeleteQuery =>
@"delete from
    Shift
where
ShiftID=@ShiftID  AND 
Name=@Name  AND 
StartTime=@StartTime  AND 
EndTime=@EndTime 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ShiftModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ShiftID", deleted.ShiftID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
            sqlCommand.Parameters.AddWithValue("@StartTime", deleted.StartTime);
            sqlCommand.Parameters.AddWithValue("@EndTime", deleted.EndTime);
        }
    }
}
