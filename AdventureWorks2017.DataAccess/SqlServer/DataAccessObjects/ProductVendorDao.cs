using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductVendorDao : AbstractDaoWithPrimaryKey<ProductVendorModel,ProductVendorModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductID,
             BusinessEntityID,
             AverageLeadTime,
             StandardPrice,
             LastReceiptCost,
             LastReceiptDate,
             MinOrderQty,
             MaxOrderQty,
             OnOrderQty,
             UnitMeasureCode,
             ModifiedDate
 from Purchasing.ProductVendor";

        protected override ProductVendorModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductVendorModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.AverageLeadTime = (int)(dataReader["AverageLeadTime"]);
             result.StandardPrice = (decimal)(dataReader["StandardPrice"]);
             result.LastReceiptCost = (decimal)(dataReader["LastReceiptCost"] is DBNull ? null : dataReader["LastReceiptCost"]);
             result.LastReceiptDate = (DateTime)(dataReader["LastReceiptDate"] is DBNull ? null : dataReader["LastReceiptDate"]);
             result.MinOrderQty = (int)(dataReader["MinOrderQty"]);
             result.MaxOrderQty = (int)(dataReader["MaxOrderQty"]);
             result.OnOrderQty = (int)(dataReader["OnOrderQty"] is DBNull ? null : dataReader["OnOrderQty"]);
             result.UnitMeasureCode = (string)(dataReader["UnitMeasureCode"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Purchasing.ProductVendor
(
ProductID,
BusinessEntityID,
AverageLeadTime,
StandardPrice,
LastReceiptCost,
LastReceiptDate,
MinOrderQty,
MaxOrderQty,
OnOrderQty,
UnitMeasureCode,
ModifiedDate
)

VALUES
(
@ProductID,
@BusinessEntityID,
@AverageLeadTime,
@StandardPrice,
@LastReceiptCost,
@LastReceiptDate,
@MinOrderQty,
@MaxOrderQty,
@OnOrderQty,
@UnitMeasureCode,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductVendorModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductVendorModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@AverageLeadTime", inserted.AverageLeadTime);
            sqlCommand.Parameters.AddWithValue("@StandardPrice", inserted.StandardPrice);
            sqlCommand.Parameters.AddWithValue("@LastReceiptCost", inserted.LastReceiptCost);
            sqlCommand.Parameters.AddWithValue("@LastReceiptDate", inserted.LastReceiptDate);
            sqlCommand.Parameters.AddWithValue("@MinOrderQty", inserted.MinOrderQty);
            sqlCommand.Parameters.AddWithValue("@MaxOrderQty", inserted.MaxOrderQty);
            sqlCommand.Parameters.AddWithValue("@OnOrderQty", inserted.OnOrderQty);
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", inserted.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Purchasing.ProductVendor
Set
    AverageLeadTime=@AverageLeadTime,
    StandardPrice=@StandardPrice,
    LastReceiptCost=@LastReceiptCost,
    LastReceiptDate=@LastReceiptDate,
    MinOrderQty=@MinOrderQty,
    MaxOrderQty=@MaxOrderQty,
    OnOrderQty=@OnOrderQty,
    UnitMeasureCode=@UnitMeasureCode,
    ModifiedDate=@ModifiedDate

Where
ProductID=@ProductID  AND 
BusinessEntityID=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductVendorModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@AverageLeadTime", updated.AverageLeadTime);
            sqlCommand.Parameters.AddWithValue("@StandardPrice", updated.StandardPrice);
            sqlCommand.Parameters.AddWithValue("@LastReceiptCost", updated.LastReceiptCost);
            sqlCommand.Parameters.AddWithValue("@LastReceiptDate", updated.LastReceiptDate);
            sqlCommand.Parameters.AddWithValue("@MinOrderQty", updated.MinOrderQty);
            sqlCommand.Parameters.AddWithValue("@MaxOrderQty", updated.MaxOrderQty);
            sqlCommand.Parameters.AddWithValue("@OnOrderQty", updated.OnOrderQty);
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", updated.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductVendorModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    Purchasing.ProductVendor
where
ProductID=@ProductID  AND 
BusinessEntityID=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductVendorModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductID=@ProductID  AND 
BusinessEntityID=@BusinessEntityID 
";

        public override void MapPrimaryParameters(ProductVendorModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);

        }

    }
}
