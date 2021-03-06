
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesTerritoryHistoryDao : AbstractDaoWithPrimaryKey<SalesTerritoryHistoryModel,SalesTerritoryHistoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [BusinessEntityID],
             [TerritoryID],
             [StartDate],
             [EndDate],
             [rowguid],
             [ModifiedDate]
 from [Sales].[SalesTerritoryHistory]";

        protected override SalesTerritoryHistoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesTerritoryHistoryModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.TerritoryID = (int)(dataReader["TerritoryID"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime?)(dataReader["EndDate"] is DBNull ? null : dataReader["EndDate"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Sales].[SalesTerritoryHistory]
(
[BusinessEntityID],
[TerritoryID],
[StartDate],
[EndDate],
[rowguid],
[ModifiedDate]
)

VALUES
(
@BusinessEntityID,
@TerritoryID,
@StartDate,
@EndDate,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesTerritoryHistoryModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesTerritoryHistoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", inserted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Sales].[SalesTerritoryHistory]
Set
    [EndDate]=@EndDate,
    [rowguid]=@rowguid,
    [ModifiedDate]=@ModifiedDate

Where
[BusinessEntityID]=@BusinessEntityID  AND 
[TerritoryID]=@TerritoryID  AND 
[StartDate]=@StartDate 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesTerritoryHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesTerritoryHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
        }

        public override string DeleteQuery =>
@"delete from
    [Sales].[SalesTerritoryHistory]
where
[BusinessEntityID]=@BusinessEntityID  AND 
[TerritoryID]=@TerritoryID  AND 
[StartDate]=@StartDate 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesTerritoryHistoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", deleted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@StartDate", deleted.StartDate);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID  AND 
TerritoryID=@TerritoryID  AND 
StartDate=@StartDate 
";

        public override void MapPrimaryParameters(SalesTerritoryHistoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", key.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@StartDate", key.StartDate);

        }

    }
}
