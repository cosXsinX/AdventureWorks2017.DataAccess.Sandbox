
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class TransactionHistoryDao : AbstractDaoWithPrimaryKey<TransactionHistoryModel,TransactionHistoryModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [TransactionID],
             [ProductID],
             [ReferenceOrderID],
             [ReferenceOrderLineID],
             [TransactionDate],
             [TransactionType],
             [Quantity],
             [ActualCost],
             [ModifiedDate]
 from [Production].[TransactionHistory]";

        protected override TransactionHistoryModel ToModel(SqlDataReader dataReader)
        {
            var result = new TransactionHistoryModel();
             result.TransactionID = (int)(dataReader["TransactionID"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.ReferenceOrderID = (int)(dataReader["ReferenceOrderID"]);
             result.ReferenceOrderLineID = (int)(dataReader["ReferenceOrderLineID"]);
             result.TransactionDate = (DateTime)(dataReader["TransactionDate"]);
             result.TransactionType = (string)(dataReader["TransactionType"]);
             result.Quantity = (int)(dataReader["Quantity"]);
             result.ActualCost = (decimal)(dataReader["ActualCost"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[TransactionHistory]
(
[ProductID],
[ReferenceOrderID],
[ReferenceOrderLineID],
[TransactionDate],
[TransactionType],
[Quantity],
[ActualCost],
[ModifiedDate]
)
output 
inserted.[TransactionID]

VALUES
(
@ProductID,
@ReferenceOrderID,
@ReferenceOrderLineID,
@TransactionDate,
@TransactionType,
@Quantity,
@ActualCost,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, TransactionHistoryModel inserted)
        {
            inserted.TransactionID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, TransactionHistoryModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderID", inserted.ReferenceOrderID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderLineID", inserted.ReferenceOrderLineID);
            sqlCommand.Parameters.AddWithValue("@TransactionDate", inserted.TransactionDate);
            sqlCommand.Parameters.AddWithValue("@TransactionType", inserted.TransactionType);
            sqlCommand.Parameters.AddWithValue("@Quantity", inserted.Quantity);
            sqlCommand.Parameters.AddWithValue("@ActualCost", inserted.ActualCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Production].[TransactionHistory]
Set
    [ProductID]=@ProductID,
    [ReferenceOrderID]=@ReferenceOrderID,
    [ReferenceOrderLineID]=@ReferenceOrderLineID,
    [TransactionDate]=@TransactionDate,
    [TransactionType]=@TransactionType,
    [Quantity]=@Quantity,
    [ActualCost]=@ActualCost,
    [ModifiedDate]=@ModifiedDate

Where
[TransactionID]=@TransactionID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, TransactionHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderID", updated.ReferenceOrderID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderLineID", updated.ReferenceOrderLineID);
            sqlCommand.Parameters.AddWithValue("@TransactionDate", updated.TransactionDate);
            sqlCommand.Parameters.AddWithValue("@TransactionType", updated.TransactionType);
            sqlCommand.Parameters.AddWithValue("@Quantity", updated.Quantity);
            sqlCommand.Parameters.AddWithValue("@ActualCost", updated.ActualCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, TransactionHistoryModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionID", updated.TransactionID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[TransactionHistory]
where
[TransactionID]=@TransactionID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, TransactionHistoryModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionID", deleted.TransactionID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"TransactionID=@TransactionID 
";

        public override void MapPrimaryParameters(TransactionHistoryModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionID", key.TransactionID);

        }

    }
}
