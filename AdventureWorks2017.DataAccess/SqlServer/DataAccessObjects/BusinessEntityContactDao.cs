
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class BusinessEntityContactDao : AbstractDaoWithPrimaryKey<BusinessEntityContactModel,BusinessEntityContactModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             PersonID,
             ContactTypeID,
             rowguid,
             ModifiedDate
 from Person.BusinessEntityContact";

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
        
        public override string InsertQuery => @"Insert Into Person.BusinessEntityContact
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
            @"Update Person.BusinessEntityContact
Set
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
PersonID=@PersonID  AND 
ContactTypeID=@ContactTypeID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonID", updated.PersonID);
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", updated.ContactTypeID);
        }

        public override string DeleteQuery =>
@"delete from
    Person.BusinessEntityContact
where
BusinessEntityID=@BusinessEntityID  AND 
PersonID=@PersonID  AND 
ContactTypeID=@ContactTypeID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityContactModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonID", deleted.PersonID);
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", deleted.ContactTypeID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID  AND 
PersonID=@PersonID  AND 
ContactTypeID=@ContactTypeID 
";

        public override void MapPrimaryParameters(BusinessEntityContactModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonID", key.PersonID);
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", key.ContactTypeID);

        }

    }
}
