using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class TransactionHistoryArchiveDao : AbstractDao<TransactionHistoryArchiveModel>
    {
        public override string SelectQuery => @"select 
             TransactionID,
             ProductID,
             ReferenceOrderID,
             ReferenceOrderLineID,
             TransactionDate,
             TransactionType,
             Quantity,
             ActualCost,
             ModifiedDate
 from TransactionHistoryArchive";

        protected override TransactionHistoryArchiveModel ToModel(SqlDataReader dataReader)
        {
            var result = new TransactionHistoryArchiveModel();
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
        
        public override string InsertQuery => @"Insert Into TransactionHistoryArchive
(
TransactionID,
ProductID,
ReferenceOrderID,
ReferenceOrderLineID,
TransactionDate,
TransactionType,
Quantity,
ActualCost,
ModifiedDate
)

VALUES
(
@TransactionID,
@ProductID,
@ReferenceOrderID,
@ReferenceOrderLineID,
@TransactionDate,
@TransactionType,
@Quantity,
@ActualCost,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, TransactionHistoryArchiveModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, TransactionHistoryArchiveModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionID", inserted.TransactionID);
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
            @"Update TransactionHistoryArchive
Set
    TransactionDate=@TransactionDate,
    TransactionType=@TransactionType,
    Quantity=@Quantity,
    ActualCost=@ActualCost,
    ModifiedDate=@ModifiedDate

Where
TransactionID=@TransactionID  AND 
ProductID=@ProductID  AND 
ReferenceOrderID=@ReferenceOrderID  AND 
ReferenceOrderLineID=@ReferenceOrderLineID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, TransactionHistoryArchiveModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionDate", updated.TransactionDate);
            sqlCommand.Parameters.AddWithValue("@TransactionType", updated.TransactionType);
            sqlCommand.Parameters.AddWithValue("@Quantity", updated.Quantity);
            sqlCommand.Parameters.AddWithValue("@ActualCost", updated.ActualCost);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, TransactionHistoryArchiveModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionID", updated.TransactionID);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderID", updated.ReferenceOrderID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderLineID", updated.ReferenceOrderLineID);
        }

        public override string DeleteQuery =>
@"delete from
    TransactionHistoryArchive
where
TransactionID=@TransactionID  AND 
ProductID=@ProductID  AND 
ReferenceOrderID=@ReferenceOrderID  AND 
ReferenceOrderLineID=@ReferenceOrderLineID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, TransactionHistoryArchiveModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@TransactionID", deleted.TransactionID);
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderID", deleted.ReferenceOrderID);
            sqlCommand.Parameters.AddWithValue("@ReferenceOrderLineID", deleted.ReferenceOrderLineID);
        }
    }
}
