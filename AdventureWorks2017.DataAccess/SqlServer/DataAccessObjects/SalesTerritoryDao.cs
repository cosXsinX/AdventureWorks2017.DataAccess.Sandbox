
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesTerritoryDao : AbstractDaoWithPrimaryKey<SalesTerritoryModel,SalesTerritoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             TerritoryID,
             Name,
             CountryRegionCode,
             Group,
             SalesYTD,
             SalesLastYear,
             CostYTD,
             CostLastYear,
             rowguid,
             ModifiedDate
 from Sales.SalesTerritory";

        protected override SalesTerritoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesTerritoryModel();
             result.TerritoryID = (int)(dataReader["TerritoryID"]);
             result.Name = (string)(dataReader["Name"]);
             result.CountryRegionCode = (string)(dataReader["CountryRegionCode"]);
             result.Group = (string)(dataReader["Group"]);
             result.SalesYTD = (decimal)(dataReader["SalesYTD"]);
             result.SalesLastYear = (decimal)(dataReader["SalesLastYear"]);
             result.CostYTD = (decimal)(dataReader["CostYTD"]);
             result.CostLastYear = (decimal)(dataReader["CostLastYear"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Sales.SalesTerritory
(
Name,
CountryRegionCode,
Group,
SalesYTD,
SalesLastYear,
CostYTD,
CostLastYear,
rowguid,
ModifiedDate
)
output 
inserted.TerritoryID

VALUES
(
@Name,
@CountryRegionCode,
@Group,
@SalesYTD,
@SalesLastYear,
@CostYTD,
@CostLastYear,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesTerritoryModel inserted)
        {
            inserted.TerritoryID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesTerritoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", inserted.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@Group", inserted.Group);
            sqlCommand.Parameters.AddWithValue("@SalesYTD", inserted.SalesYTD);
            sqlCommand.Parameters.AddWithValue("@SalesLastYear", inserted.SalesLastYear);
            sqlCommand.Parameters.AddWithValue("@CostYTD", inserted.CostYTD);
            sqlCommand.Parameters.AddWithValue("@CostLastYear", inserted.CostLastYear);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Sales.SalesTerritory
Set
    Name=@Name,
    CountryRegionCode=@CountryRegionCode,
    Group=@Group,
    SalesYTD=@SalesYTD,
    SalesLastYear=@SalesLastYear,
    CostYTD=@CostYTD,
    CostLastYear=@CostLastYear,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
TerritoryID=@TerritoryID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesTerritoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", updated.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@Group", updated.Group);
            sqlCommand.Parameters.AddWithValue("@SalesYTD", updated.SalesYTD);
            sqlCommand.Parameters.AddWithValue("@SalesLastYear", updated.SalesLastYear);
            sqlCommand.Parameters.AddWithValue("@CostYTD", updated.CostYTD);
            sqlCommand.Parameters.AddWithValue("@CostLastYear", updated.CostLastYear);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesTerritoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
        }

        public override string DeleteQuery =>
@"delete from
    Sales.SalesTerritory
where
TerritoryID=@TerritoryID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesTerritoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@TerritoryID", deleted.TerritoryID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"TerritoryID=@TerritoryID 
";

        public override void MapPrimaryParameters(SalesTerritoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@TerritoryID", key.TerritoryID);

        }

    }
}
