using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ContactTypeDao : AbstractDao<ContactTypeModel>
    {
        public override string SelectQuery => @"select 
             ContactTypeID,
             Name,
             ModifiedDate
 from ContactType";

        protected override ContactTypeModel ToModel(SqlDataReader dataReader)
        {
            var result = new ContactTypeModel();
             result.ContactTypeID = (int)(dataReader["ContactTypeID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into ContactType
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
            @"Update ContactType
Set
    ModifiedDate=@ModifiedDate

Where
ContactTypeID=@ContactTypeID  AND 
Name=@Name 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ContactTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ContactTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", updated.ContactTypeID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
        }

        public override string DeleteQuery =>
@"delete from
    ContactType
where
ContactTypeID=@ContactTypeID  AND 
Name=@Name 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ContactTypeModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ContactTypeID", deleted.ContactTypeID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
        }
    }
}
