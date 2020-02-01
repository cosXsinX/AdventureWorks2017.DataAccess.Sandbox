
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class AWBuildVersionDao : AbstractDaoWithPrimaryKey<AWBuildVersionModel,AWBuildVersionModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             SystemInformationID,
             Database Version,
             VersionDate,
             ModifiedDate
 from dbo.AWBuildVersion";

        protected override AWBuildVersionModel ToModel(SqlDataReader dataReader)
        {
            var result = new AWBuildVersionModel();
             result.SystemInformationID = (byte)(dataReader["SystemInformationID"]);
             result.DatabaseVersion = (string)(dataReader["Database Version"]);
             result.VersionDate = (DateTime)(dataReader["VersionDate"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into dbo.AWBuildVersion
(
Database Version,
VersionDate,
ModifiedDate
)
output 
inserted.SystemInformationID

VALUES
(
@Database Version,
@VersionDate,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, AWBuildVersionModel inserted)
        {
            inserted.SystemInformationID = (byte)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, AWBuildVersionModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Database Version", inserted.DatabaseVersion);
            sqlCommand.Parameters.AddWithValue("@VersionDate", inserted.VersionDate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update dbo.AWBuildVersion
Set
    Database Version=@Database Version,
    VersionDate=@VersionDate,
    ModifiedDate=@ModifiedDate

Where
SystemInformationID=@SystemInformationID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, AWBuildVersionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Database Version", updated.DatabaseVersion);
            sqlCommand.Parameters.AddWithValue("@VersionDate", updated.VersionDate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, AWBuildVersionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SystemInformationID", updated.SystemInformationID);
        }

        public override string DeleteQuery =>
@"delete from
    dbo.AWBuildVersion
where
SystemInformationID=@SystemInformationID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, AWBuildVersionModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SystemInformationID", deleted.SystemInformationID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"SystemInformationID=@SystemInformationID 
";

        public override void MapPrimaryParameters(AWBuildVersionModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@SystemInformationID", key.SystemInformationID);

        }

    }
}
