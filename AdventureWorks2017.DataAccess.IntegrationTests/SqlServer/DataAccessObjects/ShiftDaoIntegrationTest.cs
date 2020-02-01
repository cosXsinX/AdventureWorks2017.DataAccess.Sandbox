
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
    public class ShiftDaoIntegrationTests
    {
        private ShiftDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ShiftDao();
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
            ShiftModel inserted = new ShiftModel();
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.StartTime = new TimeSpan(0, 0, 0,TestSession.Random.Next(86400));
            inserted.EndTime = new TimeSpan(0, 0, 0,TestSession.Random.Next(86400));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ShiftModelPrimaryKey()
            {
                ShiftID = inserted.ShiftID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ShiftID,selectedAfterInsert.ShiftID);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.StartTime,selectedAfterInsert.StartTime);
            Assert.AreEqual(inserted.EndTime,selectedAfterInsert.EndTime);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.StartTime = new TimeSpan(0, 0, 0,TestSession.Random.Next(86400));
            inserted.EndTime = new TimeSpan(0, 0, 0,TestSession.Random.Next(86400));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ShiftModelPrimaryKey()
            {
                ShiftID = inserted.ShiftID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ShiftID, selectedAfterUpdate.ShiftID);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.StartTime, selectedAfterUpdate.StartTime);
            Assert.AreEqual(inserted.EndTime, selectedAfterUpdate.EndTime);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ShiftModelPrimaryKey()
            {
                ShiftID = inserted.ShiftID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}