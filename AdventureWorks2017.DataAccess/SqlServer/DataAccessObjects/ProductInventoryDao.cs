using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductInventoryDao : AbstractDaoWithPrimaryKey<ProductInventoryModel,ProductInventoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductID,
             LocationID,
             Shelf,
             Bin,
             Quantity,
             rowguid,
             ModifiedDate
 from Production.ProductInventory";

        protected override ProductInventoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductInventoryModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.LocationID = (short)(dataReader["LocationID"]);
             result.Shelf = (string)(dataReader["Shelf"]);
             result.Bin = (byte)(dataReader["Bin"]);
             result.Quantity = (short)(dataReader["Quantity"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductInventory
(
ProductID,
LocationID,
Shelf,
Bin,
Quantity,
rowguid,
ModifiedDate
)

VALUES
(
@ProductID,
@LocationID,
@Shelf,
@Bin,
@Quantity,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductInventoryModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductInventoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@LocationID", inserted.LocationID);
            sqlCommand.Parameters.AddWithValue("@Shelf", inserted.Shelf);
            sqlCommand.Parameters.AddWithValue("@Bin", inserted.Bin);
            sqlCommand.Parameters.AddWithValue("@Quantity", inserted.Quantity);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductInventory
Set
    Shelf=@Shelf,
    Bin=@Bin,
    Quantity=@Quantity,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
ProductID=@ProductID  AND 
LocationID=@LocationID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductInventoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Shelf", updated.Shelf);
            sqlCommand.Parameters.AddWithValue("@Bin", updated.Bin);
            sqlCommand.Parameters.AddWithValue("@Quantity", updated.Quantity);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductInventoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@LocationID", updated.LocationID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductInventory
where
ProductID=@ProductID  AND 
LocationID=@LocationID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductInventoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@LocationID", deleted.LocationID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductID=@ProductID  AND 
LocationID=@LocationID 
";

        public override void MapPrimaryParameters(ProductInventoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);
            sqlCommand.Parameters.AddWithValue("@LocationID", key.LocationID);

        }

    }
}
