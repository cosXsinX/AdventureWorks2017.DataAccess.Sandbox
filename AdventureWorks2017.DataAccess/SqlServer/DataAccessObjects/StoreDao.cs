using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class StoreDao : AbstractDao<StoreModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             Name,
             SalesPersonID,
             Demographics,
             rowguid,
             ModifiedDate
 from Store";

        protected override StoreModel ToModel(SqlDataReader dataReader)
        {
            var result = new StoreModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.Name = (string)(dataReader["Name"]);
             result.SalesPersonID = (int)(dataReader["SalesPersonID"] is DBNull ? null : dataReader["SalesPersonID"]);
             result.Demographics = (System.Xml.XmlDocument)(dataReader["Demographics"] is DBNull ? null : dataReader["Demographics"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Store
(
BusinessEntityID,
Name,
SalesPersonID,
Demographics,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@Name,
@SalesPersonID,
@Demographics,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, StoreModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, StoreModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", inserted.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@Demographics", inserted.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Store
Set
    Name=@Name,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
SalesPersonID=@SalesPersonID  AND 
Demographics=@Demographics  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, StoreModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, StoreModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", updated.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@Demographics", updated.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    Store
where
BusinessEntityID=@BusinessEntityID  AND 
SalesPersonID=@SalesPersonID  AND 
Demographics=@Demographics  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, StoreModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", deleted.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@Demographics", deleted.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
