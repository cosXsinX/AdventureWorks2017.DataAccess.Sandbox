using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class JobCandidateDao : AbstractDao<JobCandidateModel>
    {
        public override string SelectQuery => @"select 
             JobCandidateID,
             BusinessEntityID,
             Resume,
             ModifiedDate
 from JobCandidate";

        protected override JobCandidateModel ToModel(SqlDataReader dataReader)
        {
            var result = new JobCandidateModel();
             result.JobCandidateID = (int)(dataReader["JobCandidateID"]);
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"] is DBNull ? null : dataReader["BusinessEntityID"]);
             result.Resume = (System.Xml.XmlDocument)(dataReader["Resume"] is DBNull ? null : dataReader["Resume"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into JobCandidate
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
            @"Update JobCandidate
Set
    Resume=@Resume,
    ModifiedDate=@ModifiedDate

Where
JobCandidateID=@JobCandidateID  AND 
BusinessEntityID=@BusinessEntityID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, JobCandidateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Resume", updated.Resume);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, JobCandidateModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@JobCandidateID", updated.JobCandidateID);
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
        }

        public override string DeleteQuery =>
@"delete from
    JobCandidate
where
JobCandidateID=@JobCandidateID  AND 
BusinessEntityID=@BusinessEntityID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, JobCandidateModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@JobCandidateID", deleted.JobCandidateID);
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
        }
    }
}
