
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ErrorLogDao : AbstractDaoWithPrimaryKey<ErrorLogModel,ErrorLogModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ErrorLogID,
             ErrorTime,
             UserName,
             ErrorNumber,
             ErrorSeverity,
             ErrorState,
             ErrorProcedure,
             ErrorLine,
             ErrorMessage
 from dbo.ErrorLog";

        protected override ErrorLogModel ToModel(SqlDataReader dataReader)
        {
            var result = new ErrorLogModel();
             result.ErrorLogID = (int)(dataReader["ErrorLogID"]);
             result.ErrorTime = (DateTime)(dataReader["ErrorTime"]);
             result.UserName = (string)(dataReader["UserName"]);
             result.ErrorNumber = (int)(dataReader["ErrorNumber"]);
             result.ErrorSeverity = (int)(dataReader["ErrorSeverity"] is DBNull ? null : dataReader["ErrorSeverity"]);
             result.ErrorState = (int)(dataReader["ErrorState"] is DBNull ? null : dataReader["ErrorState"]);
             result.ErrorProcedure = (string)(dataReader["ErrorProcedure"] is DBNull ? null : dataReader["ErrorProcedure"]);
             result.ErrorLine = (int)(dataReader["ErrorLine"] is DBNull ? null : dataReader["ErrorLine"]);
             result.ErrorMessage = (string)(dataReader["ErrorMessage"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into dbo.ErrorLog
(
ErrorTime,
UserName,
ErrorNumber,
ErrorSeverity,
ErrorState,
ErrorProcedure,
ErrorLine,
ErrorMessage
)
output 
inserted.ErrorLogID

VALUES
(
@ErrorTime,
@UserName,
@ErrorNumber,
@ErrorSeverity,
@ErrorState,
@ErrorProcedure,
@ErrorLine,
@ErrorMessage
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ErrorLogModel inserted)
        {
            inserted.ErrorLogID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ErrorLogModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ErrorTime", inserted.ErrorTime);
            sqlCommand.Parameters.AddWithValue("@UserName", inserted.UserName);
            sqlCommand.Parameters.AddWithValue("@ErrorNumber", inserted.ErrorNumber);
            sqlCommand.Parameters.AddWithValue("@ErrorSeverity", inserted.ErrorSeverity);
            sqlCommand.Parameters.AddWithValue("@ErrorState", inserted.ErrorState);
            sqlCommand.Parameters.AddWithValue("@ErrorProcedure", inserted.ErrorProcedure);
            sqlCommand.Parameters.AddWithValue("@ErrorLine", inserted.ErrorLine);
            sqlCommand.Parameters.AddWithValue("@ErrorMessage", inserted.ErrorMessage);

        }

        public override string UpdateQuery =>
            @"Update dbo.ErrorLog
Set
    ErrorTime=@ErrorTime,
    UserName=@UserName,
    ErrorNumber=@ErrorNumber,
    ErrorSeverity=@ErrorSeverity,
    ErrorState=@ErrorState,
    ErrorProcedure=@ErrorProcedure,
    ErrorLine=@ErrorLine,
    ErrorMessage=@ErrorMessage

Where
ErrorLogID=@ErrorLogID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ErrorLogModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ErrorTime", updated.ErrorTime);
            sqlCommand.Parameters.AddWithValue("@UserName", updated.UserName);
            sqlCommand.Parameters.AddWithValue("@ErrorNumber", updated.ErrorNumber);
            sqlCommand.Parameters.AddWithValue("@ErrorSeverity", updated.ErrorSeverity);
            sqlCommand.Parameters.AddWithValue("@ErrorState", updated.ErrorState);
            sqlCommand.Parameters.AddWithValue("@ErrorProcedure", updated.ErrorProcedure);
            sqlCommand.Parameters.AddWithValue("@ErrorLine", updated.ErrorLine);
            sqlCommand.Parameters.AddWithValue("@ErrorMessage", updated.ErrorMessage);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ErrorLogModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ErrorLogID", updated.ErrorLogID);
        }

        public override string DeleteQuery =>
@"delete from
    dbo.ErrorLog
where
ErrorLogID=@ErrorLogID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ErrorLogModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ErrorLogID", deleted.ErrorLogID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ErrorLogID=@ErrorLogID 
";

        public override void MapPrimaryParameters(ErrorLogModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ErrorLogID", key.ErrorLogID);

        }

    }
}
