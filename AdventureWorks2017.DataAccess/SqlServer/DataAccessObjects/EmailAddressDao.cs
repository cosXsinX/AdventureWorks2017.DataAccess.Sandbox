
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class EmailAddressDao : AbstractDaoWithPrimaryKey<EmailAddressModel,EmailAddressModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [BusinessEntityID],
             [EmailAddressID],
             [EmailAddress],
             [rowguid],
             [ModifiedDate]
 from [Person].[EmailAddress]";

        protected override EmailAddressModel ToModel(SqlDataReader dataReader)
        {
            var result = new EmailAddressModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.EmailAddressID = (int)(dataReader["EmailAddressID"]);
             result.EmailAddress = (string?)(dataReader["EmailAddress"] is DBNull ? null : dataReader["EmailAddress"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Person].[EmailAddress]
(
[BusinessEntityID],
[EmailAddress],
[rowguid],
[ModifiedDate]
)
output 
inserted.[EmailAddressID]

VALUES
(
@BusinessEntityID,
@EmailAddress,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, EmailAddressModel inserted)
        {
            inserted.EmailAddressID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, EmailAddressModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@EmailAddress", inserted.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Person].[EmailAddress]
Set
    [EmailAddress]=@EmailAddress,
    [rowguid]=@rowguid,
    [ModifiedDate]=@ModifiedDate

Where
[BusinessEntityID]=@BusinessEntityID  AND 
[EmailAddressID]=@EmailAddressID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, EmailAddressModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@EmailAddress", updated.EmailAddress);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, EmailAddressModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@EmailAddressID", updated.EmailAddressID);
        }

        public override string DeleteQuery =>
@"delete from
    [Person].[EmailAddress]
where
[BusinessEntityID]=@BusinessEntityID  AND 
[EmailAddressID]=@EmailAddressID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, EmailAddressModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@EmailAddressID", deleted.EmailAddressID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID  AND 
EmailAddressID=@EmailAddressID 
";

        public override void MapPrimaryParameters(EmailAddressModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@EmailAddressID", key.EmailAddressID);

        }

    }
}
