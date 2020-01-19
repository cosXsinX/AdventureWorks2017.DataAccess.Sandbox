using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class UnitMeasureDao : AbstractDao<UnitMeasureModel>
    {
        public override string SelectQuery => @"select 
             UnitMeasureCode,
             Name,
             ModifiedDate
 from UnitMeasure";

        protected override UnitMeasureModel ToModel(SqlDataReader dataReader)
        {
            var result = new UnitMeasureModel();
             result.UnitMeasureCode = (string)(dataReader["UnitMeasureCode"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into UnitMeasure
(
UnitMeasureCode,
Name,
ModifiedDate
)

VALUES
(
@UnitMeasureCode,
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, UnitMeasureModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, UnitMeasureModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", inserted.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update UnitMeasure
Set
    ModifiedDate=@ModifiedDate

Where
UnitMeasureCode=@UnitMeasureCode  AND 
Name=@Name 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, UnitMeasureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, UnitMeasureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", updated.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
        }

        public override string DeleteQuery =>
@"delete from
    UnitMeasure
where
UnitMeasureCode=@UnitMeasureCode  AND 
Name=@Name 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, UnitMeasureModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", deleted.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
        }
    }
}
