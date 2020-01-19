using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductCostHistoryDao : AbstractDao<ProductCostHistoryModel>
    {
        public override string SelectQuery => @"select 
             ProductID,
             StartDate,
             EndDate,
             StandardCost,
             ModifiedDate
 from ProductCostHistory";

        protected override ProductCostHistoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductCostHistoryModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime)(dataReader["EndDate"] is DBNull ? null : dataReader["EndDate"]);
             result.StandardCost = (decimal)(dataReader["StandardCost"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into ProductCostHistory
(
ProductID,
StartDate,
EndDate,
StandardCost,
ModifiedDate
)

VALUES
(
@ProductID,
@StartDate,
@EndDate,
@StandardCost,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductCostHistoryModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductCostHistoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@StandardCost", inserted.StandardCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update ProductCostHistory
Set
    EndDate=@EndDate,
    StandardCost=@StandardCost,
    ModifiedDate=@ModifiedDate

Where
ProductID=@ProductID  AND 
StartDate=@StartDate 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductCostHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@StandardCost", updated.StandardCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductCostHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
        }

        public override string DeleteQuery =>
@"delete from
    ProductCostHistory
where
ProductID=@ProductID  AND 
StartDate=@StartDate 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductCostHistoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@StartDate", deleted.StartDate);
        }
    }
}
