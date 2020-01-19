using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class DepartmentDao : AbstractDaoWithPrimaryKey<DepartmentModel,DepartmentModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             DepartmentID,
             Name,
             GroupName,
             ModifiedDate
 from HumanResources.Department";

        protected override DepartmentModel ToModel(SqlDataReader dataReader)
        {
            var result = new DepartmentModel();
             result.DepartmentID = (short)(dataReader["DepartmentID"]);
             result.Name = (string)(dataReader["Name"]);
             result.GroupName = (string)(dataReader["GroupName"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into HumanResources.Department
(
Name,
GroupName,
ModifiedDate
)
output 
inserted.DepartmentID

VALUES
(
@Name,
@GroupName,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, DepartmentModel inserted)
        {
            inserted.DepartmentID = (short)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, DepartmentModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@GroupName", inserted.GroupName);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update HumanResources.Department
Set
    Name=@Name,
    GroupName=@GroupName,
    ModifiedDate=@ModifiedDate

Where
DepartmentID=@DepartmentID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, DepartmentModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@GroupName", updated.GroupName);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, DepartmentModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@DepartmentID", updated.DepartmentID);
        }

        public override string DeleteQuery =>
@"delete from
    HumanResources.Department
where
DepartmentID=@DepartmentID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, DepartmentModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@DepartmentID", deleted.DepartmentID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"DepartmentID=@DepartmentID 
";

        public override void MapPrimaryParameters(DepartmentModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@DepartmentID", key.DepartmentID);

        }

    }
}
