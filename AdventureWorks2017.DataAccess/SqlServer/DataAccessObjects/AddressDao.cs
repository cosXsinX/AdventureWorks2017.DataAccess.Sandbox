
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class AddressDao : AbstractDaoWithPrimaryKey<AddressModel,AddressModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             AddressID,
             AddressLine1,
             AddressLine2,
             City,
             StateProvinceID,
             PostalCode,
             SpatialLocation,
             rowguid,
             ModifiedDate
 from Person.Address";

        protected override AddressModel ToModel(SqlDataReader dataReader)
        {
            var result = new AddressModel();
             result.AddressID = (int)(dataReader["AddressID"]);
             result.AddressLine1 = (string)(dataReader["AddressLine1"]);
             result.AddressLine2 = (string)(dataReader["AddressLine2"] is DBNull ? null : dataReader["AddressLine2"]);
             result.City = (string)(dataReader["City"]);
             result.StateProvinceID = (int)(dataReader["StateProvinceID"]);
             result.PostalCode = (string)(dataReader["PostalCode"]);
             result.SpatialLocation = (Microsoft.SqlServer.Types.SqlGeography)(dataReader["SpatialLocation"] is DBNull ? null : dataReader["SpatialLocation"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Person.Address
(
AddressLine1,
AddressLine2,
City,
StateProvinceID,
PostalCode,
SpatialLocation,
rowguid,
ModifiedDate
)
output 
inserted.AddressID

VALUES
(
@AddressLine1,
@AddressLine2,
@City,
@StateProvinceID,
@PostalCode,
@SpatialLocation,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, AddressModel inserted)
        {
            inserted.AddressID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, AddressModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@AddressLine1", inserted.AddressLine1);
            sqlCommand.Parameters.AddWithValue("@AddressLine2", inserted.AddressLine2);
            sqlCommand.Parameters.AddWithValue("@City", inserted.City);
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", inserted.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@PostalCode", inserted.PostalCode);
            sqlCommand.Parameters.AddWithValue("@SpatialLocation", inserted.SpatialLocation);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Person.Address
Set
    AddressLine1=@AddressLine1,
    AddressLine2=@AddressLine2,
    City=@City,
    StateProvinceID=@StateProvinceID,
    PostalCode=@PostalCode,
    SpatialLocation=@SpatialLocation,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
AddressID=@AddressID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, AddressModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@AddressLine1", updated.AddressLine1);
            sqlCommand.Parameters.AddWithValue("@AddressLine2", updated.AddressLine2);
            sqlCommand.Parameters.AddWithValue("@City", updated.City);
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", updated.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@PostalCode", updated.PostalCode);
            sqlCommand.Parameters.AddWithValue("@SpatialLocation", updated.SpatialLocation);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, AddressModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@AddressID", updated.AddressID);
        }

        public override string DeleteQuery =>
@"delete from
    Person.Address
where
AddressID=@AddressID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, AddressModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@AddressID", deleted.AddressID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"AddressID=@AddressID 
";

        public override void MapPrimaryParameters(AddressModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@AddressID", key.AddressID);

        }

    }
}
