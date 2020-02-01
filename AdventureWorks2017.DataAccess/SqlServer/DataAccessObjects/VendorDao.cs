
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class VendorDao : AbstractDaoWithPrimaryKey<VendorModel,VendorModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             AccountNumber,
             Name,
             CreditRating,
             PreferredVendorStatus,
             ActiveFlag,
             PurchasingWebServiceURL,
             ModifiedDate
 from Purchasing.Vendor";

        protected override VendorModel ToModel(SqlDataReader dataReader)
        {
            var result = new VendorModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.AccountNumber = (string)(dataReader["AccountNumber"]);
             result.Name = (string)(dataReader["Name"]);
             result.CreditRating = (byte)(dataReader["CreditRating"]);
             result.PreferredVendorStatus = (bool)(dataReader["PreferredVendorStatus"]);
             result.ActiveFlag = (bool)(dataReader["ActiveFlag"]);
             result.PurchasingWebServiceURL = (string)(dataReader["PurchasingWebServiceURL"] is DBNull ? null : dataReader["PurchasingWebServiceURL"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Purchasing.Vendor
(
BusinessEntityID,
AccountNumber,
Name,
CreditRating,
PreferredVendorStatus,
ActiveFlag,
PurchasingWebServiceURL,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@AccountNumber,
@Name,
@CreditRating,
@PreferredVendorStatus,
@ActiveFlag,
@PurchasingWebServiceURL,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, VendorModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, VendorModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", inserted.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@CreditRating", inserted.CreditRating);
            sqlCommand.Parameters.AddWithValue("@PreferredVendorStatus", inserted.PreferredVendorStatus);
            sqlCommand.Parameters.AddWithValue("@ActiveFlag", inserted.ActiveFlag);
            sqlCommand.Parameters.AddWithValue("@PurchasingWebServiceURL", inserted.PurchasingWebServiceURL);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Purchasing.Vendor
Set
    AccountNumber=@AccountNumber,
    Name=@Name,
    CreditRating=@CreditRating,
    PreferredVendorStatus=@PreferredVendorStatus,
    ActiveFlag=@ActiveFlag,
    PurchasingWebServiceURL=@PurchasingWebServiceURL,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, VendorModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@AccountNumber", updated.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@CreditRating", updated.CreditRating);
            sqlCommand.Parameters.AddWithValue("@PreferredVendorStatus", updated.PreferredVendorStatus);
            sqlCommand.Parameters.AddWithValue("@ActiveFlag", updated.ActiveFlag);
            sqlCommand.Parameters.AddWithValue("@PurchasingWebServiceURL", updated.PurchasingWebServiceURL);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, VendorModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    Purchasing.Vendor
where
BusinessEntityID=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, VendorModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID 
";

        public override void MapPrimaryParameters(VendorModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);

        }

    }
}
