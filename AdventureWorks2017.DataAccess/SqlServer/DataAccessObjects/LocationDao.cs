using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class LocationDao : AbstractDaoWithPrimaryKey<LocationModel,LocationModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             LocationID,
             Name,
             CostRate,
             Availability,
             ModifiedDate
 from Production.Location";

        protected override LocationModel ToModel(SqlDataReader dataReader)
        {
            var result = new LocationModel();
             result.LocationID = (short)(dataReader["LocationID"]);
             result.Name = (string)(dataReader["Name"]);
             result.CostRate = (decimal)(dataReader["CostRate"]);
             result.Availability = (decimal)(dataReader["Availability"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.Location
(
Name,
CostRate,
Availability,
ModifiedDate
)
output 
inserted.LocationID

VALUES
(
@Name,
@CostRate,
@Availability,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, LocationModel inserted)
        {
            inserted.LocationID = (short)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, LocationModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@CostRate", inserted.CostRate);
            sqlCommand.Parameters.AddWithValue("@Availability", inserted.Availability);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.Location
Set
    Name=@Name,
    CostRate=@CostRate,
    Availability=@Availability,
    ModifiedDate=@ModifiedDate

Where
LocationID=@LocationID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, LocationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@CostRate", updated.CostRate);
            sqlCommand.Parameters.AddWithValue("@Availability", updated.Availability);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, LocationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@LocationID", updated.LocationID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.Location
where
LocationID=@LocationID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, LocationModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@LocationID", deleted.LocationID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"LocationID=@LocationID 
";

        public override void MapPrimaryParameters(LocationModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@LocationID", key.LocationID);

        }

    }
}
