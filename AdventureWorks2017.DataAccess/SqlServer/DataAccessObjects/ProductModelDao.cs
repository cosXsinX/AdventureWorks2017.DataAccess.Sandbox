using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductModelDao : AbstractDaoWithPrimaryKey<ProductModelModel,ProductModelModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             ProductModelID,
             Name,
             CatalogDescription,
             Instructions,
             rowguid,
             ModifiedDate
 from Production.ProductModel";

        protected override ProductModelModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductModelModel();
             result.ProductModelID = (int)(dataReader["ProductModelID"]);
             result.Name = (string)(dataReader["Name"]);
             result.CatalogDescription = (System.Xml.XmlDocument)(dataReader["CatalogDescription"] is DBNull ? null : dataReader["CatalogDescription"]);
             result.Instructions = (System.Xml.XmlDocument)(dataReader["Instructions"] is DBNull ? null : dataReader["Instructions"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Production.ProductModel
(
Name,
CatalogDescription,
Instructions,
rowguid,
ModifiedDate
)
output 
inserted.ProductModelID

VALUES
(
@Name,
@CatalogDescription,
@Instructions,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductModelModel inserted)
        {
            inserted.ProductModelID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductModelModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@CatalogDescription", inserted.CatalogDescription);
            sqlCommand.Parameters.AddWithValue("@Instructions", inserted.Instructions);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Production.ProductModel
Set
    Name=@Name,
    CatalogDescription=@CatalogDescription,
    Instructions=@Instructions,
    rowguid=@rowguid,
    ModifiedDate=@ModifiedDate

Where
ProductModelID=@ProductModelID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductModelModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@CatalogDescription", updated.CatalogDescription);
            sqlCommand.Parameters.AddWithValue("@Instructions", updated.Instructions);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductModelModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", updated.ProductModelID);
        }

        public override string DeleteQuery =>
@"delete from
    Production.ProductModel
where
ProductModelID=@ProductModelID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductModelModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", deleted.ProductModelID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductModelID=@ProductModelID 
";

        public override void MapPrimaryParameters(ProductModelModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductModelID", key.ProductModelID);

        }

    }
}
