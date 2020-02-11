
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
    public class AWBuildVersionDaoIntegrationTests
    {
        private AWBuildVersionDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new AWBuildVersionDao();
        }

        //TODO execute when there is no indexes
        [Test]
        public void GetAllIntegrationTest()
        {
            var _connection = TestSession.GetConnection();
            _connection.Open();
            var selecteds = _tested.GetAll(_connection);
            Assert.IsNotNull(selecteds);
            _connection.Close();
        }

        [Test]
        public void IntegrationTest()
        {
            var _connection = TestSession.GetConnection();
            _connection.Open();
            #region good insertion and select by id test
            AWBuildVersionModel inserted = new AWBuildVersionModel();
            inserted.DatabaseVersion = TestSession.Random.RandomString(50);
            inserted.VersionDate = TestSession.Random.RandomDateTime();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new AWBuildVersionModelPrimaryKey()
            {
                SystemInformationID = inserted.SystemInformationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SystemInformationID,selectedAfterInsert.SystemInformationID);
            Assert.AreEqual(inserted.DatabaseVersion,selectedAfterInsert.DatabaseVersion);
            Assert.AreEqual(inserted.VersionDate,selectedAfterInsert.VersionDate);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.DatabaseVersion = TestSession.Random.RandomString(50);
            inserted.VersionDate = TestSession.Random.RandomDateTime();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new AWBuildVersionModelPrimaryKey()
            {
                SystemInformationID = inserted.SystemInformationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SystemInformationID, selectedAfterUpdate.SystemInformationID);
            Assert.AreEqual(inserted.DatabaseVersion, selectedAfterUpdate.DatabaseVersion);
            Assert.AreEqual(inserted.VersionDate, selectedAfterUpdate.VersionDate);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new AWBuildVersionModelPrimaryKey()
            {
                SystemInformationID = inserted.SystemInformationID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}