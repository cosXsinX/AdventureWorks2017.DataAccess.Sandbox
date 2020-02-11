
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesPersonDao : AbstractDaoWithPrimaryKey<SalesPersonModel,SalesPersonModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             TerritoryID,
             SalesQuota,
             Bonus,
             CommissionPct,
             SalesYTD,
             SalesLastYear,
             rowguid,
             ModifiedDate
 from Sales.SalesPerson";

        protected override SalesPersonModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesPersonModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.TerritoryID = (int?)(dataReader["TerritoryID"] is DBNull ? null : dataReader["TerritoryID"]);
             result.SalesQuota = (decimal)(dataReader["SalesQuota"] is DBNull ? null : dataReader["SalesQuota"]);
             result.Bonus = (decimal)(dataReader["Bonus"]);
             result.CommissionPct = (decimal)(dataReader["CommissionPct"]);
             result.SalesYTD = (decimal)(dataReader["SalesYTD"]);
             result.SalesLastYear = (decimal)(dataReader["SalesLastYear"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Sales.SalesPerson
(
BusinessEntityID,
TerritoryID,
SalesQuota,
Bonus,
CommissionPct,
SalesYTD,
SalesLastYear,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@TerritoryID,
@SalesQuota,
@Bonus,
@CommissionPct,
@SalesYTD,
@SalesLastYear,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesPersonModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesPersonModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", inserted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@SalesQuota", inserted.SalesQuota);
            sqlCommand.Parameters.AddWithValue("@Bonus", inserted.Bonus);
            sqlCommand.Parameters.AddWithValue("@CommissionPct", inserted.CommissionPct);
            sqlCommand.Parameters.AddWithValue("@SalesYTD", inserted.SalesYTD);
            sqlCommand.Parameters.AddWithValue("@SalesLastYear", inserted.SalesLastYear);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Sales.SalesPerson
Set
    TerritoryID=@TerritoryID,
    SalesQuota=@SalesQuota,
    Bonus=@Bonus,
    CommissionPct=@CommissionPct,
    SalesYTD=@SalesYTD,
    SalesLastYear=@SalesLastYear,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesPersonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@SalesQuota", updated.SalesQuota);
            sqlCommand.Parameters.AddWithValue("@Bonus", updated.Bonus);
            sqlCommand.Parameters.AddWithValue("@CommissionPct", updated.CommissionPct);
            sqlCommand.Parameters.AddWithValue("@SalesYTD", updated.SalesYTD);
            sqlCommand.Parameters.AddWithValue("@SalesLastYear", updated.SalesLastYear);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesPersonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    Sales.SalesPerson
where
BusinessEntityID=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesPersonModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID 
";

        public override void MapPrimaryParameters(SalesPersonModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);

        }

    }
}
