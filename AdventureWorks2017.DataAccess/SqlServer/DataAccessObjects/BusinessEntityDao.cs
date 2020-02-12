
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class BusinessEntityDao : AbstractDaoWithPrimaryKey<BusinessEntityModel,BusinessEntityModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [BusinessEntityID],
             [rowguid],
             [ModifiedDate]
 from [Person].[BusinessEntity]";

        protected override BusinessEntityModel ToModel(SqlDataReader dataReader)
        {
            var result = new BusinessEntityModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Person].[BusinessEntity]
(
[rowguid],
[ModifiedDate]
)
output 
inserted.[BusinessEntityID]

VALUES
(
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, BusinessEntityModel inserted)
        {
            inserted.BusinessEntityID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, BusinessEntityModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Person].[BusinessEntity]
Set
    [rowguid]=@rowguid,
    [ModifiedDate]=@ModifiedDate

Where
[BusinessEntityID]=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, BusinessEntityModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    [Person].[BusinessEntity]
where
[BusinessEntityID]=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, BusinessEntityModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BusinessEntityID=@BusinessEntityID 
";

        public override void MapPrimaryParameters(BusinessEntityModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", key.BusinessEntityID);

        }

    }
}
