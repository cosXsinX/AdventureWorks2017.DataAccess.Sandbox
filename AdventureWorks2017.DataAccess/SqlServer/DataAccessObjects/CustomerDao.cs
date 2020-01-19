using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CustomerDao : AbstractDao<CustomerModel>
    {
        public override string SelectQuery => @"select 
             CustomerID,
             PersonID,
             StoreID,
             TerritoryID,
             AccountNumber,
             rowguid,
             ModifiedDate
 from Customer";

        protected override CustomerModel ToModel(SqlDataReader dataReader)
        {
            var result = new CustomerModel();
             result.CustomerID = (int)(dataReader["CustomerID"]);
             result.PersonID = (int)(dataReader["PersonID"] is DBNull ? null : dataReader["PersonID"]);
             result.StoreID = (int)(dataReader["StoreID"] is DBNull ? null : dataReader["StoreID"]);
             result.TerritoryID = (int)(dataReader["TerritoryID"] is DBNull ? null : dataReader["TerritoryID"]);
             result.AccountNumber = (string)(dataReader["AccountNumber"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Customer
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
            @"Update Customer
Set
    PersonID=@PersonID,
    StoreID=@StoreID,
    ModifiedDate=@ModifiedDate

Where
CustomerID=@CustomerID  AND 
TerritoryID=@TerritoryID  AND 
AccountNumber=@AccountNumber  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CustomerModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PersonID", updated.PersonID);
            sqlCommand.Parameters.AddWithValue("@StoreID", updated.StoreID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CustomerModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CustomerID", updated.CustomerID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", updated.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    Customer
where
CustomerID=@CustomerID  AND 
TerritoryID=@TerritoryID  AND 
AccountNumber=@AccountNumber  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CustomerModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CustomerID", deleted.CustomerID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", deleted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", deleted.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
