using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class LocationDao : AbstractDao<LocationModel>
    {
        public override string SelectQuery => @"select 
             LocationID,
             Name,
             CostRate,
             Availability,
             ModifiedDate
 from Location";

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
        
        public override string InsertQuery => @"Insert Into Location
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
            @"Update Location
Set
    CostRate=@CostRate,
    Availability=@Availability,
    ModifiedDate=@ModifiedDate

Where
LocationID=@LocationID  AND 
Name=@Name 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, LocationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CostRate", updated.CostRate);
            sqlCommand.Parameters.AddWithValue("@Availability", updated.Availability);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, LocationModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@LocationID", updated.LocationID);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
        }

        public override string DeleteQuery =>
@"delete from
    Location
where
LocationID=@LocationID  AND 
Name=@Name 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, LocationModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@LocationID", deleted.LocationID);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
        }
    }
}
