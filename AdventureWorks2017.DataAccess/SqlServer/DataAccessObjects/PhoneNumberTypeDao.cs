using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PhoneNumberTypeDao : AbstractDaoWithPrimaryKey<PhoneNumberTypeModel,PhoneNumberTypeModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             PhoneNumberTypeID,
             Name,
             ModifiedDate
 from Person.PhoneNumberType";

        protected override PhoneNumberTypeModel ToModel(SqlDataReader dataReader)
        {
            var result = new PhoneNumberTypeModel();
             result.PhoneNumberTypeID = (int)(dataReader["PhoneNumberTypeID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Person.PhoneNumberType
(
Name,
ModifiedDate
)
output 
inserted.PhoneNumberTypeID

VALUES
(
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PhoneNumberTypeModel inserted)
        {
            inserted.PhoneNumberTypeID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PhoneNumberTypeModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Person.PhoneNumberType
Set
    Name=@Name,
    ModifiedDate=@ModifiedDate

Where
PhoneNumberTypeID=@PhoneNumberTypeID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PhoneNumberTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PhoneNumberTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", updated.PhoneNumberTypeID);
        }

        public override string DeleteQuery =>
@"delete from
    Person.PhoneNumberType
where
PhoneNumberTypeID=@PhoneNumberTypeID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PhoneNumberTypeModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", deleted.PhoneNumberTypeID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"PhoneNumberTypeID=@PhoneNumberTypeID 
";

        public override void MapPrimaryParameters(PhoneNumberTypeModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@PhoneNumberTypeID", key.PhoneNumberTypeID);

        }

    }
}
