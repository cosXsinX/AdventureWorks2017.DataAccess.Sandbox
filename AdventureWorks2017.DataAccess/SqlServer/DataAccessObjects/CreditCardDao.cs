using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CreditCardDao : AbstractDao<CreditCardModel>
    {
        public override string SelectQuery => @"select 
             CreditCardID,
             CardType,
             CardNumber,
             ExpMonth,
             ExpYear,
             ModifiedDate
 from CreditCard";

        protected override CreditCardModel ToModel(SqlDataReader dataReader)
        {
            var result = new CreditCardModel();
             result.CreditCardID = (int)(dataReader["CreditCardID"]);
             result.CardType = (string)(dataReader["CardType"]);
             result.CardNumber = (string)(dataReader["CardNumber"]);
             result.ExpMonth = (byte)(dataReader["ExpMonth"]);
             result.ExpYear = (short)(dataReader["ExpYear"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into CreditCard
(
CardType,
CardNumber,
ExpMonth,
ExpYear,
ModifiedDate
)
output 
inserted.CreditCardID

VALUES
(
@CardType,
@CardNumber,
@ExpMonth,
@ExpYear,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, CreditCardModel inserted)
        {
            inserted.CreditCardID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, CreditCardModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@CardType", inserted.CardType);
            sqlCommand.Parameters.AddWithValue("@CardNumber", inserted.CardNumber);
            sqlCommand.Parameters.AddWithValue("@ExpMonth", inserted.ExpMonth);
            sqlCommand.Parameters.AddWithValue("@ExpYear", inserted.ExpYear);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update CreditCard
Set
    CardType=@CardType,
    ExpMonth=@ExpMonth,
    ExpYear=@ExpYear,
    ModifiedDate=@ModifiedDate

Where
CreditCardID=@CreditCardID  AND 
CardNumber=@CardNumber 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CreditCardModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CardType", updated.CardType);
            sqlCommand.Parameters.AddWithValue("@ExpMonth", updated.ExpMonth);
            sqlCommand.Parameters.AddWithValue("@ExpYear", updated.ExpYear);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CreditCardModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CreditCardID", updated.CreditCardID);
            sqlCommand.Parameters.AddWithValue("@CardNumber", updated.CardNumber);
        }

        public override string DeleteQuery =>
@"delete from
    CreditCard
where
CreditCardID=@CreditCardID  AND 
CardNumber=@CardNumber 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CreditCardModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CreditCardID", deleted.CreditCardID);
            sqlCommand.Parameters.AddWithValue("@CardNumber", deleted.CardNumber);
        }
    }
}
