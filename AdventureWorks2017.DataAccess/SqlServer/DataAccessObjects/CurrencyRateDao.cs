using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CurrencyRateDao : AbstractDao<CurrencyRateModel>
    {
        public override string SelectQuery => @"select 
             CurrencyRateID,
             CurrencyRateDate,
             FromCurrencyCode,
             ToCurrencyCode,
             AverageRate,
             EndOfDayRate,
             ModifiedDate
 from CurrencyRate";

        protected override CurrencyRateModel ToModel(SqlDataReader dataReader)
        {
            var result = new CurrencyRateModel();
             result.CurrencyRateID = (int)(dataReader["CurrencyRateID"]);
             result.CurrencyRateDate = (DateTime)(dataReader["CurrencyRateDate"]);
             result.FromCurrencyCode = (string)(dataReader["FromCurrencyCode"]);
             result.ToCurrencyCode = (string)(dataReader["ToCurrencyCode"]);
             result.AverageRate = (decimal)(dataReader["AverageRate"]);
             result.EndOfDayRate = (decimal)(dataReader["EndOfDayRate"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into CurrencyRate
(
CurrencyRateDate,
FromCurrencyCode,
ToCurrencyCode,
AverageRate,
EndOfDayRate,
ModifiedDate
)
output 
inserted.CurrencyRateID

VALUES
(
@CurrencyRateDate,
@FromCurrencyCode,
@ToCurrencyCode,
@AverageRate,
@EndOfDayRate,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CurrencyRateModel inserted)
        {
            inserted.CurrencyRateID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CurrencyRateModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateDate", inserted.CurrencyRateDate);
            sqlCommand.Parameters.AddWithValue("@FromCurrencyCode", inserted.FromCurrencyCode);
            sqlCommand.Parameters.AddWithValue("@ToCurrencyCode", inserted.ToCurrencyCode);
            sqlCommand.Parameters.AddWithValue("@AverageRate", inserted.AverageRate);
            sqlCommand.Parameters.AddWithValue("@EndOfDayRate", inserted.EndOfDayRate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update CurrencyRate
Set
    AverageRate=@AverageRate,
    EndOfDayRate=@EndOfDayRate,
    ModifiedDate=@ModifiedDate

Where
CurrencyRateID=@CurrencyRateID  AND 
CurrencyRateDate=@CurrencyRateDate  AND 
FromCurrencyCode=@FromCurrencyCode  AND 
ToCurrencyCode=@ToCurrencyCode 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CurrencyRateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@AverageRate", updated.AverageRate);
            sqlCommand.Parameters.AddWithValue("@EndOfDayRate", updated.EndOfDayRate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CurrencyRateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", updated.CurrencyRateID);
            sqlCommand.Parameters.AddWithValue("@CurrencyRateDate", updated.CurrencyRateDate);
            sqlCommand.Parameters.AddWithValue("@FromCurrencyCode", updated.FromCurrencyCode);
            sqlCommand.Parameters.AddWithValue("@ToCurrencyCode", updated.ToCurrencyCode);
        }

        public override string DeleteQuery =>
@"delete from
    CurrencyRate
where
CurrencyRateID=@CurrencyRateID  AND 
CurrencyRateDate=@CurrencyRateDate  AND 
FromCurrencyCode=@FromCurrencyCode  AND 
ToCurrencyCode=@ToCurrencyCode 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CurrencyRateModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", deleted.CurrencyRateID);
            sqlCommand.Parameters.AddWithValue("@CurrencyRateDate", deleted.CurrencyRateDate);
            sqlCommand.Parameters.AddWithValue("@FromCurrencyCode", deleted.FromCurrencyCode);
            sqlCommand.Parameters.AddWithValue("@ToCurrencyCode", deleted.ToCurrencyCode);
        }
    }
}
