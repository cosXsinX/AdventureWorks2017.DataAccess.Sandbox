using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ShoppingCartItemDao : AbstractDao<ShoppingCartItemModel>
    {
        public override string SelectQuery => @"select 
             ShoppingCartItemID,
             ShoppingCartID,
             Quantity,
             ProductID,
             DateCreated,
             ModifiedDate
 from ShoppingCartItem";

        protected override ShoppingCartItemModel ToModel(SqlDataReader dataReader)
        {
            var result = new ShoppingCartItemModel();
             result.ShoppingCartItemID = (int)(dataReader["ShoppingCartItemID"]);
             result.ShoppingCartID = (string)(dataReader["ShoppingCartID"]);
             result.Quantity = (int)(dataReader["Quantity"]);
             result.ProductID = (int)(dataReader["ProductID"]);
             result.DateCreated = (DateTime)(dataReader["DateCreated"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into ShoppingCartItem
(
ShoppingCartID,
Quantity,
ProductID,
DateCreated,
ModifiedDate
)
output 
inserted.ShoppingCartItemID

VALUES
(
@ShoppingCartID,
@Quantity,
@ProductID,
@DateCreated,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ShoppingCartItemModel inserted)
        {
            inserted.ShoppingCartItemID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ShoppingCartItemModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ShoppingCartID", inserted.ShoppingCartID);
            sqlCommand.Parameters.AddWithValue("@Quantity", inserted.Quantity);
            sqlCommand.Parameters.AddWithValue("@ProductID", inserted.ProductID);
            sqlCommand.Parameters.AddWithValue("@DateCreated", inserted.DateCreated);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update ShoppingCartItem
Set
    Quantity=@Quantity,
    DateCreated=@DateCreated,
    ModifiedDate=@ModifiedDate

Where
ShoppingCartItemID=@ShoppingCartItemID  AND 
ShoppingCartID=@ShoppingCartID  AND 
ProductID=@ProductID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ShoppingCartItemModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Quantity", updated.Quantity);
            sqlCommand.Parameters.AddWithValue("@DateCreated", updated.DateCreated);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ShoppingCartItemModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ShoppingCartItemID", updated.ShoppingCartItemID);
            sqlCommand.Parameters.AddWithValue("@ShoppingCartID", updated.ShoppingCartID);
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
        }

        public override string DeleteQuery =>
@"delete from
    ShoppingCartItem
where
ShoppingCartItemID=@ShoppingCartItemID  AND 
ShoppingCartID=@ShoppingCartID  AND 
ProductID=@ProductID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ShoppingCartItemModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ShoppingCartItemID", deleted.ShoppingCartItemID);
            sqlCommand.Parameters.AddWithValue("@ShoppingCartID", deleted.ShoppingCartID);
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
        }
    }
}
