
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductListPriceHistoryDao : AbstractDaoWithPrimaryKey<ProductListPriceHistoryModel,ProductListPriceHistoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductID,
             StartDate,
             EndDate,
             ListPrice,
             ModifiedDate
 from Production.ProductListPriceHistory";

        protected override ProductListPriceHistoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductListPriceHistoryModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime)(dataReader["EndDate"] is DBNull ? null : dataReader["EndDate"]);
             result.ListPrice = (decimal)(dataReader["ListPrice"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductListPriceHistory
(
ProductID,
StartDate,
EndDate,
ListPrice,
ModifiedDate
)

VALUES
(
@ProductID,
@StartDate,
@EndDate,
@ListPrice,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductListPriceHistoryModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductListPriceHistoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@ListPrice", inserted.ListPrice);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductListPriceHistory
Set
    EndDate=@EndDate,
    ListPrice=@ListPrice,
    ModifiedDate=@ModifiedDate

Where
ProductID=@ProductID  AND 
StartDate=@StartDate 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductListPriceHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@ListPrice", updated.ListPrice);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductListPriceHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductListPriceHistory
where
ProductID=@ProductID  AND 
StartDate=@StartDate 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductListPriceHistoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", deleted.StartDate);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductID=@ProductID  AND 
StartDate=@StartDate 
";

        public override void MapPrimaryParameters(ProductListPriceHistoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", key.StartDate);

        }

    }
}
