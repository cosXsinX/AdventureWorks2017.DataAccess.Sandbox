using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class AddressTypeDao : AbstractDao<AddressTypeModel>
    {
        public override string SelectQuery => @"select 
             AddressTypeID,
             Name,
             rowguid,
             ModifiedDate
 from AddressType";

        protected override AddressTypeModel ToModel(SqlDataReader dataReader)
        {
            var result = new AddressTypeModel();
             result.AddressTypeID = (int)(dataReader["AddressTypeID"]);
             result.Name = (string)(dataReader["Name"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into AddressType
(
Name,
rowguid,
ModifiedDate
)
output 
inserted.AddressTypeID

VALUES
(
@Name,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, AddressTypeModel inserted)
        {
            inserted.AddressTypeID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, AddressTypeModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update AddressType
Set
    ModifiedDate=@ModifiedDate

Where
AddressTypeID=@AddressTypeID  AND 
Name=@Name  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, AddressTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, AddressTypeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@AddressTypeID", updated.AddressTypeID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    AddressType
where
AddressTypeID=@AddressTypeID  AND 
Name=@Name  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, AddressTypeModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@AddressTypeID", deleted.AddressTypeID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
