
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class CreditCardDao : AbstractDaoWithPrimaryKey<CreditCardModel,CreditCardModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [CreditCardID],
             [CardType],
             [CardNumber],
             [ExpMonth],
             [ExpYear],
             [ModifiedDate]
 from [Sales].[CreditCard]";

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
        
        public override string InsertQuery => @"Insert Into [Sales].[CreditCard]
(
[CardType],
[CardNumber],
[ExpMonth],
[ExpYear],
[ModifiedDate]
)
output 
inserted.[CreditCardID]

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
            @"Update [Sales].[CreditCard]
Set
    [CardType]=@CardType,
    [CardNumber]=@CardNumber,
    [ExpMonth]=@ExpMonth,
    [ExpYear]=@ExpYear,
    [ModifiedDate]=@ModifiedDate

Where
[CreditCardID]=@CreditCardID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, CreditCardModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CardType", updated.CardType);
            sqlCommand.Parameters.AddWithValue("@CardNumber", updated.CardNumber);
            sqlCommand.Parameters.AddWithValue("@ExpMonth", updated.ExpMonth);
            sqlCommand.Parameters.AddWithValue("@ExpYear", updated.ExpYear);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, CreditCardModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@CreditCardID", updated.CreditCardID);
        }

        public override string DeleteQuery =>
@"delete from
    [Sales].[CreditCard]
where
[CreditCardID]=@CreditCardID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, CreditCardModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@CreditCardID", deleted.CreditCardID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"CreditCardID=@CreditCardID 
";

        public override void MapPrimaryParameters(CreditCardModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@CreditCardID", key.CreditCardID);

        }

    }
}
