using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class BusinessEntityContactDao : AbstractDao<BusinessEntityContactModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             PersonID,
             ContactTypeID,
             rowguid,
             ModifiedDate
 from BusinessEntityContact";

        protected override BusinessEntityContactModel ToModel(SqlDataReader dataReader)
        {
            var result = new BusinessEntityContactModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.PersonID = (int)(dataReader["PersonID"]);
             result.ContactTypeID = (int)(dataReader["ContactTypeID"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into BusinessEntityContact
(
BusinessEntityID,
PersonID,
ContactTypeID,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@PersonID,
@ContactTypeID,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, BusinessEntityContactModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonID", inserted.PersonID);
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", inserted.ContactTypeID);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update BusinessEntityContact
Set
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
PersonID=@PersonID  AND 
ContactTypeID=@ContactTypeID  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonID", updated.PersonID);
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", updated.ContactTypeID);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    BusinessEntityContact
where
BusinessEntityID=@BusinessEntityID  AND 
PersonID=@PersonID  AND 
ContactTypeID=@ContactTypeID  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonID", deleted.PersonID);
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", deleted.ContactTypeID);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
