
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CountryRegionDao : AbstractDaoWithPrimaryKey<CountryRegionModel,CountryRegionModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             CountryRegionCode,
             Name,
             ModifiedDate
 from Person.CountryRegion";

        protected override CountryRegionModel ToModel(SqlDataReader dataReader)
        {
            var result = new CountryRegionModel();
             result.CountryRegionCode = (string)(dataReader["CountryRegionCode"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Person.CountryRegion
(
CountryRegionCode,
Name,
ModifiedDate
)

VALUES
(
@CountryRegionCode,
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CountryRegionModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CountryRegionModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", inserted.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Person.CountryRegion
Set
    Name=@Name,
    ModifiedDate=@ModifiedDate

Where
CountryRegionCode=@CountryRegionCode 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CountryRegionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CountryRegionModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", updated.CountryRegionCode);
        }

        public override string DeleteQuery =>
@"delete from
    Person.CountryRegion
where
CountryRegionCode=@CountryRegionCode 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CountryRegionModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", deleted.CountryRegionCode);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"CountryRegionCode=@CountryRegionCode 
";

        public override void MapPrimaryParameters(CountryRegionModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", key.CountryRegionCode);

        }

    }
}
