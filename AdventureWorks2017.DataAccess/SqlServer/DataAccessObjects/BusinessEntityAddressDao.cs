using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class BusinessEntityAddressDao : AbstractDao<BusinessEntityAddressModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             AddressID,
             AddressTypeID,
             rowguid,
             ModifiedDate
 from BusinessEntityAddress";

        protected override BusinessEntityAddressModel ToModel(SqlDataReader dataReader)
        {
            var result = new BusinessEntityAddressModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.AddressID = (int)(dataReader["AddressID"]);
             result.AddressTypeID = (int)(dataReader["AddressTypeID"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into BusinessEntityAddress
(
BusinessEntityID,
AddressID,
AddressTypeID,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@AddressID,
@AddressTypeID,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, BusinessEntityAddressModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, BusinessEntityAddressModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@AddressID", inserted.AddressID);
            sqlCommand.Parameters.AddWithValue("@AddressTypeID", inserted.AddressTypeID);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update BusinessEntityAddress
Set
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
AddressID=@AddressID  AND 
AddressTypeID=@AddressTypeID  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, BusinessEntityAddressModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityAddressModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@AddressID", updated.AddressID);
            sqlCommand.Parameters.AddWithValue("@AddressTypeID", updated.AddressTypeID);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    BusinessEntityAddress
where
BusinessEntityID=@BusinessEntityID  AND 
AddressID=@AddressID  AND 
AddressTypeID=@AddressTypeID  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityAddressModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@AddressID", deleted.AddressID);
            sqlCommand.Parameters.AddWithValue("@AddressTypeID", deleted.AddressTypeID);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
