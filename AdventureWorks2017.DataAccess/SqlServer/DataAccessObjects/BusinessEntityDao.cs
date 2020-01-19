using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class BusinessEntityDao : AbstractDao<BusinessEntityModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             rowguid,
             ModifiedDate
 from BusinessEntity";

        protected override BusinessEntityModel ToModel(SqlDataReader dataReader)
        {
            var result = new BusinessEntityModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into BusinessEntity
(
rowguid,
ModifiedDate
)
output 
inserted.BusinessEntityID

VALUES
(
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, BusinessEntityModel inserted)
        {
            inserted.BusinessEntityID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, BusinessEntityModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update BusinessEntity
Set
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, BusinessEntityModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    BusinessEntity
where
BusinessEntityID=@BusinessEntityID  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
