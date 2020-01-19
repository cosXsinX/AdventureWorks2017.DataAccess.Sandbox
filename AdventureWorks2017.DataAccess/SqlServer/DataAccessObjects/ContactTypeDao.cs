using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ContactTypeDao : AbstractDaoWithPrimaryKey<ContactTypeModel,ContactTypeModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ContactTypeID,
             Name,
             ModifiedDate
 from Person.ContactType";

        protected override ContactTypeModel ToModel(SqlDataReader dataReader)
        {
            var result = new ContactTypeModel();
             result.ContactTypeID = (int)(dataReader["ContactTypeID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Person.ContactType
(
Name,
ModifiedDate
)
output 
inserted.ContactTypeID

VALUES
(
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ContactTypeModel inserted)
        {
            inserted.ContactTypeID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ContactTypeModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Person.ContactType
Set
    Name=@Name,
    ModifiedDate=@ModifiedDate

Where
ContactTypeID=@ContactTypeID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ContactTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ContactTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", updated.ContactTypeID);
        }

        public override string DeleteQuery =>
@"delete from
    Person.ContactType
where
ContactTypeID=@ContactTypeID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ContactTypeModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", deleted.ContactTypeID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ContactTypeID=@ContactTypeID 
";

        public override void MapPrimaryParameters(ContactTypeModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", key.ContactTypeID);

        }

    }
}
