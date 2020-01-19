using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesReasonDao : AbstractDao<SalesReasonModel>
    {
        public override string SelectQuery => @"select 
             SalesReasonID,
             Name,
             ReasonType,
             ModifiedDate
 from SalesReason";

        protected override SalesReasonModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesReasonModel();
             result.SalesReasonID = (int)(dataReader["SalesReasonID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ReasonType = (string)(dataReader["ReasonType"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into SalesReason
(
Name,
ReasonType,
ModifiedDate
)
output 
inserted.SalesReasonID

VALUES
(
@Name,
@ReasonType,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesReasonModel inserted)
        {
            inserted.SalesReasonID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesReasonModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ReasonType", inserted.ReasonType);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update SalesReason
Set
    Name=@Name,
    ReasonType=@ReasonType,
    ModifiedDate=@ModifiedDate

Where
SalesReasonID=@SalesReasonID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ReasonType", updated.ReasonType);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SalesReasonID", updated.SalesReasonID);
        }

        public override string DeleteQuery =>
@"delete from
    SalesReason
where
SalesReasonID=@SalesReasonID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesReasonModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesReasonID", deleted.SalesReasonID);
        }
    }
}
