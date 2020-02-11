
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CustomerDao : AbstractDaoWithPrimaryKey<CustomerModel,CustomerModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             CustomerID,
             PersonID,
             StoreID,
             TerritoryID,
             AccountNumber,
             rowguid,
             ModifiedDate
 from Sales.Customer";

        protected override CustomerModel ToModel(SqlDataReader dataReader)
        {
            var result = new CustomerModel();
             result.CustomerID = (int)(dataReader["CustomerID"]);
             result.PersonID = (int?)(dataReader["PersonID"] is DBNull ? null : dataReader["PersonID"]);
             result.StoreID = (int?)(dataReader["StoreID"] is DBNull ? null : dataReader["StoreID"]);
             result.TerritoryID = (int?)(dataReader["TerritoryID"] is DBNull ? null : dataReader["TerritoryID"]);
             result.AccountNumber = (string)(dataReader["AccountNumber"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Sales.Customer
(
PersonID,
StoreID,
TerritoryID,
AccountNumber,
rowguid,
ModifiedDate
)
output 
inserted.CustomerID

VALUES
(
@PersonID,
@StoreID,
@TerritoryID,
@AccountNumber,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CustomerModel inserted)
        {
            inserted.CustomerID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CustomerModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@PersonID", inserted.PersonID);
            sqlCommand.Parameters.AddWithValue("@StoreID", inserted.StoreID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", inserted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", inserted.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Sales.Customer
Set
    PersonID=@PersonID,
    StoreID=@StoreID,
    TerritoryID=@TerritoryID,
    AccountNumber=@AccountNumber,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
CustomerID=@CustomerID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CustomerModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PersonID", updated.PersonID);
            sqlCommand.Parameters.AddWithValue("@StoreID", updated.StoreID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", updated.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CustomerModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CustomerID", updated.CustomerID);
        }

        public override string DeleteQuery =>
@"delete from
    Sales.Customer
where
CustomerID=@CustomerID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CustomerModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CustomerID", deleted.CustomerID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"CustomerID=@CustomerID 
";

        public override void MapPrimaryParameters(CustomerModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@CustomerID", key.CustomerID);

        }

    }
}
