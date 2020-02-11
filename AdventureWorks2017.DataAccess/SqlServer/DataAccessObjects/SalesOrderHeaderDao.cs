
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesOrderHeaderDao : AbstractDaoWithPrimaryKey<SalesOrderHeaderModel,SalesOrderHeaderModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             SalesOrderID,
             RevisionNumber,
             OrderDate,
             DueDate,
             ShipDate,
             Status,
             OnlineOrderFlag,
             SalesOrderNumber,
             PurchaseOrderNumber,
             AccountNumber,
             CustomerID,
             SalesPersonID,
             TerritoryID,
             BillToAddressID,
             ShipToAddressID,
             ShipMethodID,
             CreditCardID,
             CreditCardApprovalCode,
             CurrencyRateID,
             SubTotal,
             TaxAmt,
             Freight,
             TotalDue,
             Comment,
             rowguid,
             ModifiedDate
 from Sales.SalesOrderHeader";

        protected override SalesOrderHeaderModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesOrderHeaderModel();
             result.SalesOrderID = (int)(dataReader["SalesOrderID"]);
             result.RevisionNumber = (byte)(dataReader["RevisionNumber"]);
             result.OrderDate = (DateTime)(dataReader["OrderDate"]);
             result.DueDate = (DateTime)(dataReader["DueDate"]);
             result.ShipDate = (DateTime)(dataReader["ShipDate"] is DBNull ? null : dataReader["ShipDate"]);
             result.Status = (byte)(dataReader["Status"]);
             result.OnlineOrderFlag = (bool)(dataReader["OnlineOrderFlag"]);
             result.SalesOrderNumber = (string)(dataReader["SalesOrderNumber"]);
             result.PurchaseOrderNumber = (string)(dataReader["PurchaseOrderNumber"] is DBNull ? null : dataReader["PurchaseOrderNumber"]);
             result.AccountNumber = (string)(dataReader["AccountNumber"] is DBNull ? null : dataReader["AccountNumber"]);
             result.CustomerID = (int)(dataReader["CustomerID"]);
             result.SalesPersonID = (int?)(dataReader["SalesPersonID"] is DBNull ? null : dataReader["SalesPersonID"]);
             result.TerritoryID = (int?)(dataReader["TerritoryID"] is DBNull ? null : dataReader["TerritoryID"]);
             result.BillToAddressID = (int)(dataReader["BillToAddressID"]);
             result.ShipToAddressID = (int)(dataReader["ShipToAddressID"]);
             result.ShipMethodID = (int)(dataReader["ShipMethodID"]);
             result.CreditCardID = (int?)(dataReader["CreditCardID"] is DBNull ? null : dataReader["CreditCardID"]);
             result.CreditCardApprovalCode = (string)(dataReader["CreditCardApprovalCode"] is DBNull ? null : dataReader["CreditCardApprovalCode"]);
             result.CurrencyRateID = (int?)(dataReader["CurrencyRateID"] is DBNull ? null : dataReader["CurrencyRateID"]);
             result.SubTotal = (decimal)(dataReader["SubTotal"]);
             result.TaxAmt = (decimal)(dataReader["TaxAmt"]);
             result.Freight = (decimal)(dataReader["Freight"]);
             result.TotalDue = (decimal)(dataReader["TotalDue"]);
             result.Comment = (string)(dataReader["Comment"] is DBNull ? null : dataReader["Comment"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Sales.SalesOrderHeader
(
RevisionNumber,
OrderDate,
DueDate,
ShipDate,
Status,
OnlineOrderFlag,
SalesOrderNumber,
PurchaseOrderNumber,
AccountNumber,
CustomerID,
SalesPersonID,
TerritoryID,
BillToAddressID,
ShipToAddressID,
ShipMethodID,
CreditCardID,
CreditCardApprovalCode,
CurrencyRateID,
SubTotal,
TaxAmt,
Freight,
TotalDue,
Comment,
rowguid,
ModifiedDate
)
output 
inserted.SalesOrderID

VALUES
(
@RevisionNumber,
@OrderDate,
@DueDate,
@ShipDate,
@Status,
@OnlineOrderFlag,
@SalesOrderNumber,
@PurchaseOrderNumber,
@AccountNumber,
@CustomerID,
@SalesPersonID,
@TerritoryID,
@BillToAddressID,
@ShipToAddressID,
@ShipMethodID,
@CreditCardID,
@CreditCardApprovalCode,
@CurrencyRateID,
@SubTotal,
@TaxAmt,
@Freight,
@TotalDue,
@Comment,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesOrderHeaderModel inserted)
        {
            inserted.SalesOrderID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@RevisionNumber", inserted.RevisionNumber);
            sqlCommand.Parameters.AddWithValue("@OrderDate", inserted.OrderDate);
            sqlCommand.Parameters.AddWithValue("@DueDate", inserted.DueDate);
            sqlCommand.Parameters.AddWithValue("@ShipDate", inserted.ShipDate);
            sqlCommand.Parameters.AddWithValue("@Status", inserted.Status);
            sqlCommand.Parameters.AddWithValue("@OnlineOrderFlag", inserted.OnlineOrderFlag);
            sqlCommand.Parameters.AddWithValue("@SalesOrderNumber", inserted.SalesOrderNumber);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderNumber", inserted.PurchaseOrderNumber);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", inserted.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@CustomerID", inserted.CustomerID);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", inserted.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", inserted.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@BillToAddressID", inserted.BillToAddressID);
            sqlCommand.Parameters.AddWithValue("@ShipToAddressID", inserted.ShipToAddressID);
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", inserted.ShipMethodID);
            sqlCommand.Parameters.AddWithValue("@CreditCardID", inserted.CreditCardID);
            sqlCommand.Parameters.AddWithValue("@CreditCardApprovalCode", inserted.CreditCardApprovalCode);
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", inserted.CurrencyRateID);
            sqlCommand.Parameters.AddWithValue("@SubTotal", inserted.SubTotal);
            sqlCommand.Parameters.AddWithValue("@TaxAmt", inserted.TaxAmt);
            sqlCommand.Parameters.AddWithValue("@Freight", inserted.Freight);
            sqlCommand.Parameters.AddWithValue("@TotalDue", inserted.TotalDue);
            sqlCommand.Parameters.AddWithValue("@Comment", inserted.Comment);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Sales.SalesOrderHeader
Set
    RevisionNumber=@RevisionNumber,
    OrderDate=@OrderDate,
    DueDate=@DueDate,
    ShipDate=@ShipDate,
    Status=@Status,
    OnlineOrderFlag=@OnlineOrderFlag,
    SalesOrderNumber=@SalesOrderNumber,
    PurchaseOrderNumber=@PurchaseOrderNumber,
    AccountNumber=@AccountNumber,
    CustomerID=@CustomerID,
    SalesPersonID=@SalesPersonID,
    TerritoryID=@TerritoryID,
    BillToAddressID=@BillToAddressID,
    ShipToAddressID=@ShipToAddressID,
    ShipMethodID=@ShipMethodID,
    CreditCardID=@CreditCardID,
    CreditCardApprovalCode=@CreditCardApprovalCode,
    CurrencyRateID=@CurrencyRateID,
    SubTotal=@SubTotal,
    TaxAmt=@TaxAmt,
    Freight=@Freight,
    TotalDue=@TotalDue,
    Comment=@Comment,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
SalesOrderID=@SalesOrderID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@RevisionNumber", updated.RevisionNumber);
            sqlCommand.Parameters.AddWithValue("@OrderDate", updated.OrderDate);
            sqlCommand.Parameters.AddWithValue("@DueDate", updated.DueDate);
            sqlCommand.Parameters.AddWithValue("@ShipDate", updated.ShipDate);
            sqlCommand.Parameters.AddWithValue("@Status", updated.Status);
            sqlCommand.Parameters.AddWithValue("@OnlineOrderFlag", updated.OnlineOrderFlag);
            sqlCommand.Parameters.AddWithValue("@SalesOrderNumber", updated.SalesOrderNumber);
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderNumber", updated.PurchaseOrderNumber);
            sqlCommand.Parameters.AddWithValue("@AccountNumber", updated.AccountNumber);
            sqlCommand.Parameters.AddWithValue("@CustomerID", updated.CustomerID);
            sqlCommand.Parameters.AddWithValue("@SalesPersonID", updated.SalesPersonID);
            sqlCommand.Parameters.AddWithValue("@TerritoryID", updated.TerritoryID);
            sqlCommand.Parameters.AddWithValue("@BillToAddressID", updated.BillToAddressID);
            sqlCommand.Parameters.AddWithValue("@ShipToAddressID", updated.ShipToAddressID);
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", updated.ShipMethodID);
            sqlCommand.Parameters.AddWithValue("@CreditCardID", updated.CreditCardID);
            sqlCommand.Parameters.AddWithValue("@CreditCardApprovalCode", updated.CreditCardApprovalCode);
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", updated.CurrencyRateID);
            sqlCommand.Parameters.AddWithValue("@SubTotal", updated.SubTotal);
            sqlCommand.Parameters.AddWithValue("@TaxAmt", updated.TaxAmt);
            sqlCommand.Parameters.AddWithValue("@Freight", updated.Freight);
            sqlCommand.Parameters.AddWithValue("@TotalDue", updated.TotalDue);
            sqlCommand.Parameters.AddWithValue("@Comment", updated.Comment);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", updated.SalesOrderID);
        }

        public override string DeleteQuery =>
@"delete from
    Sales.SalesOrderHeader
where
SalesOrderID=@SalesOrderID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesOrderHeaderModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", deleted.SalesOrderID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"SalesOrderID=@SalesOrderID 
";

        public override void MapPrimaryParameters(SalesOrderHeaderModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@SalesOrderID", key.SalesOrderID);

        }

    }
}
