
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PasswordDao : AbstractDaoWithPrimaryKey<PasswordModel,PasswordModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [BusinessEntityID],
             [PasswordHash],
             [PasswordSalt],
             [rowguid],
             [ModifiedDate]
 from [Person].[Password]";

        protected override PasswordModel ToModel(SqlDataReader dataReader)
        {
            var result = new PasswordModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.PasswordHash = (string)(dataReader["PasswordHash"]);
             result.PasswordSalt = (string)(dataReader["PasswordSalt"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Person].[Password]
(
[BusinessEntityID],
[PasswordHash],
[PasswordSalt],
[rowguid],
[ModifiedDate]
)

VALUES
(
@BusinessEntityID,
@PasswordHash,
@PasswordSalt,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PasswordModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PasswordModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PasswordHash", inserted.PasswordHash);
            sqlCommand.Parameters.AddWithValue("@PasswordSalt", inserted.PasswordSalt);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Person].[Password]
Set
    [PasswordHash]=@PasswordHash,
    [PasswordSalt]=@PasswordSalt,
    [rowguid]=@rowguid,
    [ModifiedDate]=@ModifiedDate

Where
[BusinessEntityID]=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PasswordModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PasswordHash", updated.PasswordHash);
            sqlCommand.Parameters.AddWithValue("@PasswordSalt", updated.PasswordSalt);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PasswordModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    [Person].[Password]
where
[BusinessEntityID]=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PasswordModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID 
";

        public override void MapPrimaryParameters(PasswordModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);

        }

    }
}
