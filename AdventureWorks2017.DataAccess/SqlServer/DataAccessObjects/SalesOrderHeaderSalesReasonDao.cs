using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesOrderHeaderSalesReasonDao : AbstractDao<SalesOrderHeaderSalesReasonModel>
    {
        public override string SelectQuery => @"select 
             SalesOrderID,
             SalesReasonID,
             ModifiedDate
 from SalesOrderHeaderSalesReason";

        protected override SalesOrderHeaderSalesReasonModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesOrderHeaderSalesReasonModel();
             result.SalesOrderID = (int)(dataReader["SalesOrderID"]);
             result.SalesReasonID = (int)(dataReader["SalesReasonID"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into SalesOrderHeaderSalesReason
(
SalesOrderID,
SalesReasonID,
ModifiedDate
)

VALUES
(
@SalesOrderID,
@SalesReasonID,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesOrderHeaderSalesReasonModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderSalesReasonModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", inserted.SalesOrderID);
            sqlCommand.Parameters.AddWithValue("@SalesReasonID", inserted.SalesReasonID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update SalesOrderHeaderSalesReason
Set
    ModifiedDate=@ModifiedDate

Where
SalesOrderID=@SalesOrderID  AND 
SalesReasonID=@SalesReasonID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderSalesReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderSalesReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", updated.SalesOrderID);
            sqlCommand.Parameters.AddWithValue("@SalesReasonID", updated.SalesReasonID);
        }

        public override string DeleteQuery =>
@"delete from
    SalesOrderHeaderSalesReason
where
SalesOrderID=@SalesOrderID  AND 
SalesReasonID=@SalesReasonID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderSalesReasonModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", deleted.SalesOrderID);
            sqlCommand.Parameters.AddWithValue("@SalesReasonID", deleted.SalesReasonID);
        }
    }
}
