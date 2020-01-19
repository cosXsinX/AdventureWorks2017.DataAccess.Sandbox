using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CultureDao : AbstractDao<CultureModel>
    {
        public override string SelectQuery => @"select 
             CultureID,
             Name,
             ModifiedDate
 from Culture";

        protected override CultureModel ToModel(SqlDataReader dataReader)
        {
            var result = new CultureModel();
             result.CultureID = (string)(dataReader["CultureID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Culture
(
CultureID,
Name,
ModifiedDate
)

VALUES
(
@CultureID,
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CultureModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CultureModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@CultureID", inserted.CultureID);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Culture
Set
    ModifiedDate=@ModifiedDate

Where
CultureID=@CultureID  AND 
Name=@Name 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CultureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CultureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CultureID", updated.CultureID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
        }

        public override string DeleteQuery =>
@"delete from
    Culture
where
CultureID=@CultureID  AND 
Name=@Name 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CultureModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CultureID", deleted.CultureID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
        }
    }
}
