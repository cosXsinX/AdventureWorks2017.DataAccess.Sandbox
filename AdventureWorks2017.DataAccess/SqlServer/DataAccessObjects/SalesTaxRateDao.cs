using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class SalesTaxRateDao : AbstractDao<SalesTaxRateModel>
    {
        public override string SelectQuery => @"select 
             SalesTaxRateID,
             StateProvinceID,
             TaxType,
             TaxRate,
             Name,
             rowguid,
             ModifiedDate
 from SalesTaxRate";

        protected override SalesTaxRateModel ToModel(SqlDataReader dataReader)
        {
            var result = new SalesTaxRateModel();
             result.SalesTaxRateID = (int)(dataReader["SalesTaxRateID"]);
             result.StateProvinceID = (int)(dataReader["StateProvinceID"]);
             result.TaxType = (byte)(dataReader["TaxType"]);
             result.TaxRate = (decimal)(dataReader["TaxRate"]);
             result.Name = (string)(dataReader["Name"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into SalesTaxRate
(
StateProvinceID,
TaxType,
TaxRate,
Name,
rowguid,
ModifiedDate
)
output 
inserted.SalesTaxRateID

VALUES
(
@StateProvinceID,
@TaxType,
@TaxRate,
@Name,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, SalesTaxRateModel inserted)
        {
            inserted.SalesTaxRateID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, SalesTaxRateModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", inserted.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@TaxType", inserted.TaxType);
            sqlCommand.Parameters.AddWithValue("@TaxRate", inserted.TaxRate);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update SalesTaxRate
Set
    TaxRate=@TaxRate,
    Name=@Name,
    ModifiedDate=@ModifiedDate

Where
SalesTaxRateID=@SalesTaxRateID  AND 
StateProvinceID=@StateProvinceID  AND 
TaxType=@TaxType  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, SalesTaxRateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@TaxRate", updated.TaxRate);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, SalesTaxRateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@SalesTaxRateID", updated.SalesTaxRateID);
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", updated.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@TaxType", updated.TaxType);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    SalesTaxRate
where
SalesTaxRateID=@SalesTaxRateID  AND 
StateProvinceID=@StateProvinceID  AND 
TaxType=@TaxType  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, SalesTaxRateModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@SalesTaxRateID", deleted.SalesTaxRateID);
            sqlCommand.Parameters.AddWithValue("@StateProvinceID", deleted.StateProvinceID);
            sqlCommand.Parameters.AddWithValue("@TaxType", deleted.TaxType);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
