using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PurchaseOrderHeaderDao : AbstractDao<PurchaseOrderHeaderModel>
    {
        public override string SelectQuery => @"select 
             PurchaseOrderID,
             RevisionNumber,
             Status,
             EmployeeID,
             VendorID,
             ShipMethodID,
             OrderDate,
             ShipDate,
             SubTotal,
             TaxAmt,
             Freight,
             TotalDue,
             ModifiedDate
 from PurchaseOrderHeader";

        protected override PurchaseOrderHeaderModel ToModel(SqlDataReader dataReader)
        {
            var result = new PurchaseOrderHeaderModel();
             result.PurchaseOrderID = (int)(dataReader["PurchaseOrderID"]);
             result.RevisionNumber = (byte)(dataReader["RevisionNumber"]);
             result.Status = (byte)(dataReader["Status"]);
             result.EmployeeID = (int)(dataReader["EmployeeID"]);
             result.VendorID = (int)(dataReader["VendorID"]);
             result.ShipMethodID = (int)(dataReader["ShipMethodID"]);
             result.OrderDate = (DateTime)(dataReader["OrderDate"]);
             result.ShipDate = (DateTime)(dataReader["ShipDate"] is DBNull ? null : dataReader["ShipDate"]);
             result.SubTotal = (decimal)(dataReader["SubTotal"]);
             result.TaxAmt = (decimal)(dataReader["TaxAmt"]);
             result.Freight = (decimal)(dataReader["Freight"]);
             result.TotalDue = (decimal)(dataReader["TotalDue"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into PurchaseOrderHeader
(
RevisionNumber,
Status,
EmployeeID,
VendorID,
ShipMethodID,
OrderDate,
ShipDate,
SubTotal,
TaxAmt,
Freight,
TotalDue,
ModifiedDate
)
output 
inserted.PurchaseOrderID

VALUES
(
@RevisionNumber,
@Status,
@EmployeeID,
@VendorID,
@ShipMethodID,
@OrderDate,
@ShipDate,
@SubTotal,
@TaxAmt,
@Freight,
@TotalDue,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PurchaseOrderHeaderModel inserted)
        {
            inserted.PurchaseOrderID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PurchaseOrderHeaderModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@RevisionNumber", inserted.RevisionNumber);
            sqlCommand.Parameters.AddWithValue("@Status", inserted.Status);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", inserted.EmployeeID);
            sqlCommand.Parameters.AddWithValue("@VendorID", inserted.VendorID);
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", inserted.ShipMethodID);
            sqlCommand.Parameters.AddWithValue("@OrderDate", inserted.OrderDate);
            sqlCommand.Parameters.AddWithValue("@ShipDate", inserted.ShipDate);
            sqlCommand.Parameters.AddWithValue("@SubTotal", inserted.SubTotal);
            sqlCommand.Parameters.AddWithValue("@TaxAmt", inserted.TaxAmt);
            sqlCommand.Parameters.AddWithValue("@Freight", inserted.Freight);
            sqlCommand.Parameters.AddWithValue("@TotalDue", inserted.TotalDue);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update PurchaseOrderHeader
Set
    RevisionNumber=@RevisionNumber,
    Status=@Status,
    ShipMethodID=@ShipMethodID,
    OrderDate=@OrderDate,
    ShipDate=@ShipDate,
    SubTotal=@SubTotal,
    TaxAmt=@TaxAmt,
    Freight=@Freight,
    TotalDue=@TotalDue,
    ModifiedDate=@ModifiedDate

Where
PurchaseOrderID=@PurchaseOrderID  AND 
EmployeeID=@EmployeeID  AND 
VendorID=@VendorID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PurchaseOrderHeaderModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@RevisionNumber", updated.RevisionNumber);
            sqlCommand.Parameters.AddWithValue("@Status", updated.Status);
            sqlCommand.Parameters.AddWithValue("@ShipMethodID", updated.ShipMethodID);
            sqlCommand.Parameters.AddWithValue("@OrderDate", updated.OrderDate);
            sqlCommand.Parameters.AddWithValue("@ShipDate", updated.ShipDate);
            sqlCommand.Parameters.AddWithValue("@SubTotal", updated.SubTotal);
            sqlCommand.Parameters.AddWithValue("@TaxAmt", updated.TaxAmt);
            sqlCommand.Parameters.AddWithValue("@Freight", updated.Freight);
            sqlCommand.Parameters.AddWithValue("@TotalDue", updated.TotalDue);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PurchaseOrderHeaderModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", updated.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", updated.EmployeeID);
            sqlCommand.Parameters.AddWithValue("@VendorID", updated.VendorID);
        }

        public override string DeleteQuery =>
@"delete from
    PurchaseOrderHeader
where
PurchaseOrderID=@PurchaseOrderID  AND 
EmployeeID=@EmployeeID  AND 
VendorID=@VendorID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PurchaseOrderHeaderModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@PurchaseOrderID", deleted.PurchaseOrderID);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", deleted.EmployeeID);
            sqlCommand.Parameters.AddWithValue("@VendorID", deleted.VendorID);
        }
    }
}
