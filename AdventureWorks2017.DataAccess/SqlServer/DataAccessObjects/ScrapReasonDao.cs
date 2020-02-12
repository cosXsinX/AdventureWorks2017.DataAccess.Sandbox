
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ScrapReasonDao : AbstractDaoWithPrimaryKey<ScrapReasonModel,ScrapReasonModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [ScrapReasonID],
             [Name],
             [ModifiedDate]
 from [Production].[ScrapReason]";

        protected override ScrapReasonModel ToModel(SqlDataReader dataReader)
        {
            var result = new ScrapReasonModel();
             result.ScrapReasonID = (short)(dataReader["ScrapReasonID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[ScrapReason]
(
[Name],
[ModifiedDate]
)
output 
inserted.[ScrapReasonID]

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
            @"Update [Production].[ScrapReason]
Set
    [Name]=@Name,
    [ModifiedDate]=@ModifiedDate

Where
[ScrapReasonID]=@ScrapReasonID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ScrapReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ScrapReasonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", updated.ScrapReasonID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[ScrapReason]
where
[ScrapReasonID]=@ScrapReasonID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ScrapReasonModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", deleted.ScrapReasonID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ScrapReasonID=@ScrapReasonID 
";

        public override void MapPrimaryParameters(ScrapReasonModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ScrapReasonID", key.ScrapReasonID);

        }

    }
}
