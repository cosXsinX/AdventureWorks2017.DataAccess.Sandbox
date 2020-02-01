
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class StoreDao : AbstractDaoWithPrimaryKey<StoreModel,StoreModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             Name,
             SalesPersonID,
             Demographics,
             rowguid,
             ModifiedDate
 from Sales.Store";

        protected override StoreModel ToModel(SqlDataReader dataReader)
        {
            var result = new StoreModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.Name = (string)(dataReader["Name"]);
             result.SalesPersonID = (int)(dataReader["SalesPersonID"] is DBNull ? null : dataReader["SalesPersonID"]);
             result.Demographics = (System.Xml.XmlDocument)(dataReader["Demographics"] is DBNull ? null : dataReader["Demographics"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Sales.Store
(
BusinessEntityID,
Name,
SalesPersonID,
Demographics,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@Name,
@SalesPersonID,
@Demographics,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, StoreModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, StoreModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", inserted.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@Demographics", inserted.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Sales.Store
Set
    Name=@Name,
    SalesPersonID=@SalesPersonID,
    Demographics=@Demographics,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, StoreModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", updated.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@Demographics", updated.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, StoreModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    Sales.Store
where
BusinessEntityID=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, StoreModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID 
";

        public override void MapPrimaryParameters(StoreModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);

        }

    }
}
