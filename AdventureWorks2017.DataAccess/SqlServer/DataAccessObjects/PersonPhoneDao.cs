using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PersonPhoneDao : AbstractDaoWithPrimaryKey<PersonPhoneModel,PersonPhoneModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             PhoneNumber,
             PhoneNumberTypeID,
             ModifiedDate
 from Person.PersonPhone";

        protected override PersonPhoneModel ToModel(SqlDataReader dataReader)
        {
            var result = new PersonPhoneModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.PhoneNumber = (string)(dataReader["PhoneNumber"]);
             result.PhoneNumberTypeID = (int)(dataReader["PhoneNumberTypeID"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Person.PersonPhone
(
BusinessEntityID,
PhoneNumber,
PhoneNumberTypeID,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@PhoneNumber,
@PhoneNumberTypeID,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PersonPhoneModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PersonPhoneModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", inserted.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", inserted.PhoneNumberTypeID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Person.PersonPhone
Set
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
PhoneNumber=@PhoneNumber  AND 
PhoneNumberTypeID=@PhoneNumberTypeID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PersonPhoneModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PersonPhoneModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", updated.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", updated.PhoneNumberTypeID);
        }

        public override string DeleteQuery =>
@"delete from
    Person.PersonPhone
where
BusinessEntityID=@BusinessEntityID  AND 
PhoneNumber=@PhoneNumber  AND 
PhoneNumberTypeID=@PhoneNumberTypeID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PersonPhoneModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", deleted.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", deleted.PhoneNumberTypeID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID  AND 
PhoneNumber=@PhoneNumber  AND 
PhoneNumberTypeID=@PhoneNumberTypeID 
";

        public override void MapPrimaryParameters(PersonPhoneModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", key.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", key.PhoneNumberTypeID);

        }

    }
}
