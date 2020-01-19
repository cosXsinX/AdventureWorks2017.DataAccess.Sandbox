using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PersonCreditCardDao : AbstractDao<PersonCreditCardModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             CreditCardID,
             ModifiedDate
 from PersonCreditCard";

        protected override PersonCreditCardModel ToModel(SqlDataReader dataReader)
        {
            var result = new PersonCreditCardModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.CreditCardID = (int)(dataReader["CreditCardID"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into PersonCreditCard
(
BusinessEntityID,
CreditCardID,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@CreditCardID,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PersonCreditCardModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PersonCreditCardModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@CreditCardID", inserted.CreditCardID);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update PersonCreditCard
Set
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
CreditCardID=@CreditCardID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PersonCreditCardModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PersonCreditCardModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@CreditCardID", updated.CreditCardID);
        }

        public override string DeleteQuery =>
@"delete from
    PersonCreditCard
where
BusinessEntityID=@BusinessEntityID  AND 
CreditCardID=@CreditCardID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PersonCreditCardModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@CreditCardID", deleted.CreditCardID);
        }
    }
}
