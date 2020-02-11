
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
    public class DatabaseLogDaoIntegrationTests
    {
        private DatabaseLogDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new DatabaseLogDao();
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
            DatabaseLogModel inserted = new DatabaseLogModel();
            inserted.PostTime = TestSession.Random.RandomDateTime();
            inserted.DatabaseUser = TestSession.Random.RandomString(256);
            inserted.Event = TestSession.Random.RandomString(256);
            inserted.Schema = TestSession.Random.RandomString(256);
            inserted.Object = TestSession.Random.RandomString(256);
            inserted.TSQL = TestSession.Random.RandomString(-1);
            inserted.XmlEvent = null; //TODO define how to generate random xml;

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new DatabaseLogModelPrimaryKey()
            {
                DatabaseLogID = inserted.DatabaseLogID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.DatabaseLogID,selectedAfterInsert.DatabaseLogID);
            Assert.AreEqual(inserted.PostTime,selectedAfterInsert.PostTime);
            Assert.AreEqual(inserted.DatabaseUser,selectedAfterInsert.DatabaseUser);
            Assert.AreEqual(inserted.Event,selectedAfterInsert.Event);
            Assert.AreEqual(inserted.Schema,selectedAfterInsert.Schema);
            Assert.AreEqual(inserted.Object,selectedAfterInsert.Object);
            Assert.AreEqual(inserted.TSQL,selectedAfterInsert.TSQL);
            Assert.AreEqual(inserted.XmlEvent,selectedAfterInsert.XmlEvent);

            #endregion

            #region update and select by id test
            inserted.PostTime = TestSession.Random.RandomDateTime();
            inserted.DatabaseUser = TestSession.Random.RandomString(256);
            inserted.Event = TestSession.Random.RandomString(256);
            inserted.Schema = TestSession.Random.RandomString(256);
            inserted.Object = TestSession.Random.RandomString(256);
            inserted.TSQL = TestSession.Random.RandomString(-1);
            inserted.XmlEvent = null; //TODO define how to generate random xml;

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new DatabaseLogModelPrimaryKey()
            {
                DatabaseLogID = inserted.DatabaseLogID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.DatabaseLogID, selectedAfterUpdate.DatabaseLogID);
            Assert.AreEqual(inserted.PostTime, selectedAfterUpdate.PostTime);
            Assert.AreEqual(inserted.DatabaseUser, selectedAfterUpdate.DatabaseUser);
            Assert.AreEqual(inserted.Event, selectedAfterUpdate.Event);
            Assert.AreEqual(inserted.Schema, selectedAfterUpdate.Schema);
            Assert.AreEqual(inserted.Object, selectedAfterUpdate.Object);
            Assert.AreEqual(inserted.TSQL, selectedAfterUpdate.TSQL);
            Assert.AreEqual(inserted.XmlEvent, selectedAfterUpdate.XmlEvent);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new DatabaseLogModelPrimaryKey()
            {
                DatabaseLogID = inserted.DatabaseLogID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}