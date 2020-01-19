using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class DatabaseLogDao : AbstractDaoWithPrimaryKey<DatabaseLogModel,DatabaseLogModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             DatabaseLogID,
             PostTime,
             DatabaseUser,
             Event,
             Schema,
             Object,
             TSQL,
             XmlEvent
 from dbo.DatabaseLog";

        protected override DatabaseLogModel ToModel(SqlDataReader dataReader)
        {
            var result = new DatabaseLogModel();
             result.DatabaseLogID = (int)(dataReader["DatabaseLogID"]);
             result.PostTime = (DateTime)(dataReader["PostTime"]);
             result.DatabaseUser = (string)(dataReader["DatabaseUser"]);
             result.Event = (string)(dataReader["Event"]);
             result.Schema = (string)(dataReader["Schema"] is DBNull ? null : dataReader["Schema"]);
             result.Object = (string)(dataReader["Object"] is DBNull ? null : dataReader["Object"]);
             result.TSQL = (string)(dataReader["TSQL"]);
             result.XmlEvent = (System.Xml.XmlDocument)(dataReader["XmlEvent"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into dbo.DatabaseLog
(
PostTime,
DatabaseUser,
Event,
Schema,
Object,
TSQL,
XmlEvent
)
output 
inserted.DatabaseLogID

VALUES
(
@PostTime,
@DatabaseUser,
@Event,
@Schema,
@Object,
@TSQL,
@XmlEvent
)";

        public override void InsertionGeneratedAutoIdMapping(object id, DatabaseLogModel inserted)
        {
            inserted.DatabaseLogID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, DatabaseLogModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@PostTime", inserted.PostTime);
            sqlCommand.Parameters.AddWithValue("@DatabaseUser", inserted.DatabaseUser);
            sqlCommand.Parameters.AddWithValue("@Event", inserted.Event);
            sqlCommand.Parameters.AddWithValue("@Schema", inserted.Schema);
            sqlCommand.Parameters.AddWithValue("@Object", inserted.Object);
            sqlCommand.Parameters.AddWithValue("@TSQL", inserted.TSQL);
            sqlCommand.Parameters.AddWithValue("@XmlEvent", inserted.XmlEvent);

        }

        public override string UpdateQuery =>
            @"Update dbo.DatabaseLog
Set
    PostTime=@PostTime,
    DatabaseUser=@DatabaseUser,
    Event=@Event,
    Schema=@Schema,
    Object=@Object,
    TSQL=@TSQL,
    XmlEvent=@XmlEvent

Where
DatabaseLogID=@DatabaseLogID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, DatabaseLogModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PostTime", updated.PostTime);
            sqlCommand.Parameters.AddWithValue("@DatabaseUser", updated.DatabaseUser);
            sqlCommand.Parameters.AddWithValue("@Event", updated.Event);
            sqlCommand.Parameters.AddWithValue("@Schema", updated.Schema);
            sqlCommand.Parameters.AddWithValue("@Object", updated.Object);
            sqlCommand.Parameters.AddWithValue("@TSQL", updated.TSQL);
            sqlCommand.Parameters.AddWithValue("@XmlEvent", updated.XmlEvent);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, DatabaseLogModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@DatabaseLogID", updated.DatabaseLogID);
        }

        public override string DeleteQuery =>
@"delete from
    dbo.DatabaseLog
where
DatabaseLogID=@DatabaseLogID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, DatabaseLogModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@DatabaseLogID", deleted.DatabaseLogID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"DatabaseLogID=@DatabaseLogID 
";

        public override void MapPrimaryParameters(DatabaseLogModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@DatabaseLogID", key.DatabaseLogID);

        }

    }
}
