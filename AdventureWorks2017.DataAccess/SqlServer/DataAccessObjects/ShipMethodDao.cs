
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ShipMethodDao : AbstractDaoWithPrimaryKey<ShipMethodModel,ShipMethodModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ShipMethodID,
             Name,
             ShipBase,
             ShipRate,
             rowguid,
             ModifiedDate
 from Purchasing.ShipMethod";

        protected override ShipMethodModel ToModel(SqlDataReader dataReader)
        {
            var result = new ShipMethodModel();
             result.ShipMethodID = (int)(dataReader["ShipMethodID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ShipBase = (decimal)(dataReader["ShipBase"]);
             result.ShipRate = (decimal)(dataReader["ShipRate"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Purchasing.ShipMethod
(
Name,
ShipBase,
ShipRate,
rowguid,
ModifiedDate
)
output 
inserted.ShipMethodID

VALUES
(
@Name,
@ShipBase,
@ShipRate,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ShipMethodModel inserted)
        {
            inserted.ShipMethodID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ShipMethodModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ShipBase", inserted.ShipBase);
            sqlCommand.Parameters.AddWithValue("@ShipRate", inserted.ShipRate);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Purchasing.ShipMethod
Set
    Name=@Name,
    ShipBase=@ShipBase,
    ShipRate=@ShipRate,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
ShipMethodID=@ShipMethodID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ShipMethodModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ShipBase", updated.ShipBase);
            sqlCommand.Parameters.AddWithValue("@ShipRate", updated.ShipRate);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ShipMethodModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", updated.ShipMethodID);
        }

        public override string DeleteQuery =>
@"delete from
    Purchasing.ShipMethod
where
ShipMethodID=@ShipMethodID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ShipMethodModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", deleted.ShipMethodID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ShipMethodID=@ShipMethodID 
";

        public override void MapPrimaryParameters(ShipMethodModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", key.ShipMethodID);

        }

    }
}
