using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class StateProvinceDao : AbstractDao<StateProvinceModel>
    {
        public override string SelectQuery => @"select 
             StateProvinceID,
             StateProvinceCode,
             CountryRegionCode,
             IsOnlyStateProvinceFlag,
             Name,
             TerritoryID,
             rowguid,
             ModifiedDate
 from StateProvince";

        protected override StateProvinceModel ToModel(SqlDataReader dataReader)
        {
            var result = new StateProvinceModel();
             result.StateProvinceID = (int)(dataReader["StateProvinceID"]);
             result.StateProvinceCode = (string)(dataReader["StateProvinceCode"]);
             result.CountryRegionCode = (string)(dataReader["CountryRegionCode"]);
             result.IsOnlyStateProvinceFlag = (bool)(dataReader["IsOnlyStateProvinceFlag"]);
             result.Name = (string)(dataReader["Name"]);
             result.TerritoryID = (int)(dataReader["TerritoryID"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into StateProvince
(
StateProvinceCode,
CountryRegionCode,
IsOnlyStateProvinceFlag,
Name,
TerritoryID,
rowguid,
ModifiedDate
)
output 
inserted.StateProvinceID

VALUES
(
@StateProvinceCode,
@CountryRegionCode,
@IsOnlyStateProvinceFlag,
@Name,
@TerritoryID,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, StateProvinceModel inserted)
        {
            inserted.StateProvinceID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, StateProvinceModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@StateProvinceCode", inserted.StateProvinceCode);
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", inserted.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@IsOnlyStateProvinceFlag", inserted.IsOnlyStateProvinceFlag);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", inserted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update StateProvince
Set
    IsOnlyStateProvinceFlag=@IsOnlyStateProvinceFlag,
    TerritoryID=@TerritoryID,
    ModifiedDate=@ModifiedDate

Where
StateProvinceID=@StateProvinceID  AND 
StateProvinceCode=@StateProvinceCode  AND 
CountryRegionCode=@CountryRegionCode  AND 
Name=@Name  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, StateProvinceModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@IsOnlyStateProvinceFlag", updated.IsOnlyStateProvinceFlag);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, StateProvinceModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", updated.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@StateProvinceCode", updated.StateProvinceCode);
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", updated.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    StateProvince
where
StateProvinceID=@StateProvinceID  AND 
StateProvinceCode=@StateProvinceCode  AND 
CountryRegionCode=@CountryRegionCode  AND 
Name=@Name  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, StateProvinceModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", deleted.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@StateProvinceCode", deleted.StateProvinceCode);
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", deleted.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
