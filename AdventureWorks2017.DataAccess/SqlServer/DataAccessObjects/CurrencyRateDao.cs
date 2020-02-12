
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CurrencyRateDao : AbstractDaoWithPrimaryKey<CurrencyRateModel,CurrencyRateModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [CurrencyRateID],
             [CurrencyRateDate],
             [FromCurrencyCode],
             [ToCurrencyCode],
             [AverageRate],
             [EndOfDayRate],
             [ModifiedDate]
 from [Sales].[CurrencyRate]";

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
        
        public override string InsertQuery => @"Insert Into [Sales].[CurrencyRate]
(
[CurrencyRateDate],
[FromCurrencyCode],
[ToCurrencyCode],
[AverageRate],
[EndOfDayRate],
[ModifiedDate]
)
output 
inserted.[CurrencyRateID]

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
            @"Update [Sales].[CurrencyRate]
Set
    [CurrencyRateDate]=@CurrencyRateDate,
    [FromCurrencyCode]=@FromCurrencyCode,
    [ToCurrencyCode]=@ToCurrencyCode,
    [AverageRate]=@AverageRate,
    [EndOfDayRate]=@EndOfDayRate,
    [ModifiedDate]=@ModifiedDate

Where
[CurrencyRateID]=@CurrencyRateID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CurrencyRateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateDate", updated.CurrencyRateDate);
            sqlCommand.Parameters.AddWithValue("@FromCurrencyCode", updated.FromCurrencyCode);
            sqlCommand.Parameters.AddWithValue("@ToCurrencyCode", updated.ToCurrencyCode);
            sqlCommand.Parameters.AddWithValue("@AverageRate", updated.AverageRate);
            sqlCommand.Parameters.AddWithValue("@EndOfDayRate", updated.EndOfDayRate);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CurrencyRateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", updated.CurrencyRateID);
        }

        public override string DeleteQuery =>
@"delete from
    [Sales].[CurrencyRate]
where
[CurrencyRateID]=@CurrencyRateID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CurrencyRateModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", deleted.CurrencyRateID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"CurrencyRateID=@CurrencyRateID 
";

        public override void MapPrimaryParameters(CurrencyRateModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyRateID", key.CurrencyRateID);

        }

    }
}
