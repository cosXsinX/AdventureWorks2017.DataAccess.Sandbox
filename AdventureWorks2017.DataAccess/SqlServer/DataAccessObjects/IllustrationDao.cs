using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class IllustrationDao : AbstractDaoWithPrimaryKey<IllustrationModel,IllustrationModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             IllustrationID,
             Diagram,
             ModifiedDate
 from Production.Illustration";

        protected override IllustrationModel ToModel(SqlDataReader dataReader)
        {
            var result = new IllustrationModel();
             result.IllustrationID = (int)(dataReader["IllustrationID"]);
             result.Diagram = (System.Xml.XmlDocument)(dataReader["Diagram"] is DBNull ? null : dataReader["Diagram"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.Illustration
(
Diagram,
ModifiedDate
)
output 
inserted.IllustrationID

VALUES
(
@Diagram,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, IllustrationModel inserted)
        {
            inserted.IllustrationID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, IllustrationModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Diagram", inserted.Diagram);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.Illustration
Set
    Diagram=@Diagram,
    ModifiedDate=@ModifiedDate

Where
IllustrationID=@IllustrationID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, IllustrationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Diagram", updated.Diagram);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, IllustrationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@IllustrationID", updated.IllustrationID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.Illustration
where
IllustrationID=@IllustrationID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, IllustrationModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@IllustrationID", deleted.IllustrationID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"IllustrationID=@IllustrationID 
";

        public override void MapPrimaryParameters(IllustrationModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@IllustrationID", key.IllustrationID);

        }

    }
}
