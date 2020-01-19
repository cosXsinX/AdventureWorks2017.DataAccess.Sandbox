using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CurrencyDao : AbstractDao<CurrencyModel>
    {
        public override string SelectQuery => @"select 
             CurrencyCode,
             Name,
             ModifiedDate
 from Currency";

        protected override CurrencyModel ToModel(SqlDataReader dataReader)
        {
            var result = new CurrencyModel();
             result.CurrencyCode = (string)(dataReader["CurrencyCode"]);
             result.Name = (string)(dataReader["Name"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Currency
(
CurrencyCode,
Name,
ModifiedDate
)

VALUES
(
@CurrencyCode,
@Name,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CurrencyModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CurrencyModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyCode", inserted.CurrencyCode);
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Currency
Set
    ModifiedDate=@ModifiedDate

Where
CurrencyCode=@CurrencyCode  AND 
Name=@Name 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CurrencyModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CurrencyModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyCode", updated.CurrencyCode);
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
        }

        public override string DeleteQuery =>
@"delete from
    Currency
where
CurrencyCode=@CurrencyCode  AND 
Name=@Name 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CurrencyModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CurrencyCode", deleted.CurrencyCode);
            sqlCommand.Parameters.AddWithValue("@Name", deleted.Name);
        }
    }
}
