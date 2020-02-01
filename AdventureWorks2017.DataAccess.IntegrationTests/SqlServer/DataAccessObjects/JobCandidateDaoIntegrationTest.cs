
using AdventureWorks2017.DataAccess.IntegrationTests.SqlServer.DataAccessObjects;
using AdventureWorks2017.Models;
using AdventureWorks2017.SqlServer.DataAccessObjects;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Linq;
using AdventureWorks2017.DataAccess.IntegrationTests.SqlServer.DataAccessObjects;

namespace AdventureWorks2017.DataAccess.IntegrationTests
{
    [TestFixture]
    public class JobCandidateDaoIntegrationTests
    {
        private JobCandidateDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new JobCandidateDao();
            _connection = TestSession.SqlConnection;
        }

        //TODO execute when there is no indexes
        [Test]
        public void GetAllIntegrationTest()
        {
            var selecteds = _tested.GetAll(_connection);
            Assert.IsNotNull(selecteds);
        }

        [Test]
        public void IntegrationTest()
        {
            #region good insertion and select by id test
            JobCandidateModel inserted = new JobCandidateModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.Resume = null; //TODO define how to generate random xml;
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new JobCandidateModelPrimaryKey()
            {
                JobCandidateID = inserted.JobCandidateID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.JobCandidateID,selectedAfterInsert.JobCandidateID);
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.Resume,selectedAfterInsert.Resume);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.Resume = null; //TODO define how to generate random xml;
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new JobCandidateModelPrimaryKey()
            {
                JobCandidateID = inserted.JobCandidateID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.JobCandidateID, selectedAfterUpdate.JobCandidateID);
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.Resume, selectedAfterUpdate.Resume);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new JobCandidateModelPrimaryKey()
            {
                JobCandidateID = inserted.JobCandidateID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}