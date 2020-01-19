using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class EmployeeDao : AbstractDao<EmployeeModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             NationalIDNumber,
             LoginID,
             OrganizationNode,
             OrganizationLevel,
             JobTitle,
             BirthDate,
             MaritalStatus,
             Gender,
             HireDate,
             SalariedFlag,
             VacationHours,
             SickLeaveHours,
             CurrentFlag,
             rowguid,
             ModifiedDate
 from Employee";

        protected override EmployeeModel ToModel(SqlDataReader dataReader)
        {
            var result = new EmployeeModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.NationalIDNumber = (string)(dataReader["NationalIDNumber"]);
             result.LoginID = (string)(dataReader["LoginID"]);
             result.OrganizationNode = (string)(dataReader["OrganizationNode"] is DBNull ? null : dataReader["OrganizationNode"]);
             result.OrganizationLevel = (short)(dataReader["OrganizationLevel"] is DBNull ? null : dataReader["OrganizationLevel"]);
             result.JobTitle = (string)(dataReader["JobTitle"]);
             result.BirthDate = (DateTime)(dataReader["BirthDate"]);
             result.MaritalStatus = (string)(dataReader["MaritalStatus"]);
             result.Gender = (string)(dataReader["Gender"]);
             result.HireDate = (DateTime)(dataReader["HireDate"]);
             result.SalariedFlag = (bool)(dataReader["SalariedFlag"]);
             result.VacationHours = (short)(dataReader["VacationHours"]);
             result.SickLeaveHours = (short)(dataReader["SickLeaveHours"]);
             result.CurrentFlag = (bool)(dataReader["CurrentFlag"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Employee
(
BusinessEntityID,
NationalIDNumber,
LoginID,
OrganizationNode,
OrganizationLevel,
JobTitle,
BirthDate,
MaritalStatus,
Gender,
HireDate,
SalariedFlag,
VacationHours,
SickLeaveHours,
CurrentFlag,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@NationalIDNumber,
@LoginID,
@OrganizationNode,
@OrganizationLevel,
@JobTitle,
@BirthDate,
@MaritalStatus,
@Gender,
@HireDate,
@SalariedFlag,
@VacationHours,
@SickLeaveHours,
@CurrentFlag,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, EmployeeModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, EmployeeModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@NationalIDNumber", inserted.NationalIDNumber);
            sqlCommand.Parameters.AddWithValue("@LoginID", inserted.LoginID);
            sqlCommand.Parameters.AddWithValue("@OrganizationNode", inserted.OrganizationNode);
            sqlCommand.Parameters.AddWithValue("@OrganizationLevel", inserted.OrganizationLevel);
            sqlCommand.Parameters.AddWithValue("@JobTitle", inserted.JobTitle);
            sqlCommand.Parameters.AddWithValue("@BirthDate", inserted.BirthDate);
            sqlCommand.Parameters.AddWithValue("@MaritalStatus", inserted.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Gender", inserted.Gender);
            sqlCommand.Parameters.AddWithValue("@HireDate", inserted.HireDate);
            sqlCommand.Parameters.AddWithValue("@SalariedFlag", inserted.SalariedFlag);
            sqlCommand.Parameters.AddWithValue("@VacationHours", inserted.VacationHours);
            sqlCommand.Parameters.AddWithValue("@SickLeaveHours", inserted.SickLeaveHours);
            sqlCommand.Parameters.AddWithValue("@CurrentFlag", inserted.CurrentFlag);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Employee
Set
    JobTitle=@JobTitle,
    BirthDate=@BirthDate,
    MaritalStatus=@MaritalStatus,
    Gender=@Gender,
    HireDate=@HireDate,
    SalariedFlag=@SalariedFlag,
    VacationHours=@VacationHours,
    SickLeaveHours=@SickLeaveHours,
    CurrentFlag=@CurrentFlag,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
NationalIDNumber=@NationalIDNumber  AND 
LoginID=@LoginID  AND 
OrganizationNode=@OrganizationNode  AND 
OrganizationLevel=@OrganizationLevel  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, EmployeeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@JobTitle", updated.JobTitle);
            sqlCommand.Parameters.AddWithValue("@BirthDate", updated.BirthDate);
            sqlCommand.Parameters.AddWithValue("@MaritalStatus", updated.MaritalStatus);
            sqlCommand.Parameters.AddWithValue("@Gender", updated.Gender);
            sqlCommand.Parameters.AddWithValue("@HireDate", updated.HireDate);
            sqlCommand.Parameters.AddWithValue("@SalariedFlag", updated.SalariedFlag);
            sqlCommand.Parameters.AddWithValue("@VacationHours", updated.VacationHours);
            sqlCommand.Parameters.AddWithValue("@SickLeaveHours", updated.SickLeaveHours);
            sqlCommand.Parameters.AddWithValue("@CurrentFlag", updated.CurrentFlag);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, EmployeeModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@NationalIDNumber", updated.NationalIDNumber);
            sqlCommand.Parameters.AddWithValue("@LoginID", updated.LoginID);
            sqlCommand.Parameters.AddWithValue("@OrganizationNode", updated.OrganizationNode);
            sqlCommand.Parameters.AddWithValue("@OrganizationLevel", updated.OrganizationLevel);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    Employee
where
BusinessEntityID=@BusinessEntityID  AND 
NationalIDNumber=@NationalIDNumber  AND 
LoginID=@LoginID  AND 
OrganizationNode=@OrganizationNode  AND 
OrganizationLevel=@OrganizationLevel  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, EmployeeModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@NationalIDNumber", deleted.NationalIDNumber);
            sqlCommand.Parameters.AddWithValue("@LoginID", deleted.LoginID);
            sqlCommand.Parameters.AddWithValue("@OrganizationNode", deleted.OrganizationNode);
            sqlCommand.Parameters.AddWithValue("@OrganizationLevel", deleted.OrganizationLevel);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
