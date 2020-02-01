
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class UnitMeasureDao : AbstractDaoWithPrimaryKey<UnitMeasureModel,UnitMeasureModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             UnitMeasureCode,
             Name,
             ModifiedDate
 from Production.UnitMeasure";

        protected override UnitMeasureModel ToModel(SqlDataReader dataReader)
        {
            var result = new UnitMeasureModel();
             result.UnitMeasureCode = (string)(dataReader["UnitMeasureCode"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.UnitMeasure
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
            @"Update Production.UnitMeasure
Set
    Name=@Name,
    ModifiedDate=@ModifiedDate

Where
UnitMeasureCode=@UnitMeasureCode 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, UnitMeasureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, UnitMeasureModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", updated.UnitMeasureCode);
        }

        public override string DeleteQuery =>
@"delete from
    Production.UnitMeasure
where
UnitMeasureCode=@UnitMeasureCode 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, UnitMeasureModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", deleted.UnitMeasureCode);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"UnitMeasureCode=@UnitMeasureCode 
";

        public override void MapPrimaryParameters(UnitMeasureModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", key.UnitMeasureCode);

        }

    }
}
