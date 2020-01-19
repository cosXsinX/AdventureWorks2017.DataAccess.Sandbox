using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ScrapReasonDao : AbstractDao<ScrapReasonModel>
    {
        public override string SelectQuery => @"select 
             ScrapReasonID,
             Name,
             ModifiedDate
 from ScrapReason";

        protected override ScrapReasonModel ToModel(SqlDataReader dataReader)
        {
            var result = new ScrapReasonModel();
             result.ScrapReasonID = (short)(dataReader["ScrapReasonID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into ScrapReason
(
Name,
ModifiedDate
)
output 
inserted.ScrapReasonID

VALUES
(
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ScrapReasonModel inserted)
        {
            inserted.ScrapReasonID = (short)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ScrapReasonModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update ScrapReason
Set
    ModifiedDate=@ModifiedDate

Where
ScrapReasonID=@ScrapReasonID  AND 
Name=@Name 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ScrapReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ScrapReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", updated.ScrapReasonID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
        }

        public override string DeleteQuery =>
@"delete from
    ScrapReason
where
ScrapReasonID=@ScrapReasonID  AND 
Name=@Name 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ScrapReasonModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", deleted.ScrapReasonID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
        }
    }
}
