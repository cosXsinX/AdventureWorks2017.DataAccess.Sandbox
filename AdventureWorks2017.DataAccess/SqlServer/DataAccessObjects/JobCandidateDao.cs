using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class JobCandidateDao : AbstractDaoWithPrimaryKey<JobCandidateModel,JobCandidateModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             JobCandidateID,
             BusinessEntityID,
             Resume,
             ModifiedDate
 from HumanResources.JobCandidate";

        protected override JobCandidateModel ToModel(SqlDataReader dataReader)
        {
            var result = new JobCandidateModel();
             result.JobCandidateID = (int)(dataReader["JobCandidateID"]);
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"] is DBNull ? null : dataReader["BusinessEntityID"]);
             result.Resume = (System.Xml.XmlDocument)(dataReader["Resume"] is DBNull ? null : dataReader["Resume"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into HumanResources.JobCandidate
(
BusinessEntityID,
Resume,
ModifiedDate
)
output 
inserted.JobCandidateID

VALUES
(
@BusinessEntityID,
@Resume,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, JobCandidateModel inserted)
        {
            inserted.JobCandidateID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, JobCandidateModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@Resume", inserted.Resume);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update HumanResources.JobCandidate
Set
    BusinessEntityID=@BusinessEntityID,
    Resume=@Resume,
    ModifiedDate=@ModifiedDate

Where
JobCandidateID=@JobCandidateID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, JobCandidateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@Resume", updated.Resume);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, JobCandidateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@JobCandidateID", updated.JobCandidateID);
        }

        public override string DeleteQuery =>
@"delete from
    HumanResources.JobCandidate
where
JobCandidateID=@JobCandidateID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, JobCandidateModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@JobCandidateID", deleted.JobCandidateID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"JobCandidateID=@JobCandidateID 
";

        public override void MapPrimaryParameters(JobCandidateModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@JobCandidateID", key.JobCandidateID);

        }

    }
}
