using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CountryRegionCurrencyDao : AbstractDao<CountryRegionCurrencyModel>
    {
        public override string SelectQuery => @"select 
             CountryRegionCode,
             CurrencyCode,
             ModifiedDate
 from CountryRegionCurrency";

        protected override CountryRegionCurrencyModel ToModel(SqlDataReader dataReader)
        {
            var result = new CountryRegionCurrencyModel();
             result.CountryRegionCode = (string)(dataReader["CountryRegionCode"]);
             result.CurrencyCode = (string)(dataReader["CurrencyCode"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into CountryRegionCurrency
(
CountryRegionCode,
CurrencyCode,
ModifiedDate
)

VALUES
(
@CountryRegionCode,
@CurrencyCode,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CountryRegionCurrencyModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CountryRegionCurrencyModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", inserted.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@CurrencyCode", inserted.CurrencyCode);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update CountryRegionCurrency
Set
    ModifiedDate=@ModifiedDate

Where
CountryRegionCode=@CountryRegionCode  AND 
CurrencyCode=@CurrencyCode 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CountryRegionCurrencyModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CountryRegionCurrencyModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", updated.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@CurrencyCode", updated.CurrencyCode);
        }

        public override string DeleteQuery =>
@"delete from
    CountryRegionCurrency
where
CountryRegionCode=@CountryRegionCode  AND 
CurrencyCode=@CurrencyCode 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CountryRegionCurrencyModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CountryRegionCode", deleted.CountryRegionCode);
            sqlCommand.Parameters.AddWithValue("@CurrencyCode", deleted.CurrencyCode);
        }
    }
}
