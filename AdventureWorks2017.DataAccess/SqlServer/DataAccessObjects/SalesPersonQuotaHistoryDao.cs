using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesPersonQuotaHistoryDao : AbstractDao<SalesPersonQuotaHistoryModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             QuotaDate,
             SalesQuota,
             rowguid,
             ModifiedDate
 from SalesPersonQuotaHistory";

        protected override SalesPersonQuotaHistoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesPersonQuotaHistoryModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.QuotaDate = (DateTime)(dataReader["QuotaDate"]);
             result.SalesQuota = (decimal)(dataReader["SalesQuota"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into SalesPersonQuotaHistory
(
BusinessEntityID,
QuotaDate,
SalesQuota,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@QuotaDate,
@SalesQuota,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesPersonQuotaHistoryModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesPersonQuotaHistoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@QuotaDate", inserted.QuotaDate);
            sqlCommand.Parameters.AddWithValue("@SalesQuota", inserted.SalesQuota);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update SalesPersonQuotaHistory
Set
    SalesQuota=@SalesQuota,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
QuotaDate=@QuotaDate  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesPersonQuotaHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SalesQuota", updated.SalesQuota);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesPersonQuotaHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@QuotaDate", updated.QuotaDate);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    SalesPersonQuotaHistory
where
BusinessEntityID=@BusinessEntityID  AND 
QuotaDate=@QuotaDate  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesPersonQuotaHistoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@QuotaDate", deleted.QuotaDate);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
