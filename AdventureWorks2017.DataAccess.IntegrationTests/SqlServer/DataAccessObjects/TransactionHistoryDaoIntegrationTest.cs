
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
    public class TransactionHistoryDaoIntegrationTests
    {
        private TransactionHistoryDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new TransactionHistoryDao();
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
            TransactionHistoryModel inserted = new TransactionHistoryModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.ReferenceOrderID = TestSession.Random.Next();
            inserted.ReferenceOrderLineID = TestSession.Random.Next();
            inserted.TransactionDate = TestSession.Random.RandomDateTime();
            inserted.TransactionType = TestSession.Random.RandomString(2);
            inserted.Quantity = TestSession.Random.Next();
            inserted.ActualCost = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new TransactionHistoryModelPrimaryKey()
            {
                TransactionID = inserted.TransactionID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.TransactionID,selectedAfterInsert.TransactionID);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.ReferenceOrderID,selectedAfterInsert.ReferenceOrderID);
            Assert.AreEqual(inserted.ReferenceOrderLineID,selectedAfterInsert.ReferenceOrderLineID);
            Assert.AreEqual(inserted.TransactionDate,selectedAfterInsert.TransactionDate);
            Assert.AreEqual(inserted.TransactionType,selectedAfterInsert.TransactionType);
            Assert.AreEqual(inserted.Quantity,selectedAfterInsert.Quantity);
            Assert.AreEqual(inserted.ActualCost,selectedAfterInsert.ActualCost);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ProductID = TestSession.Random.Next();
            inserted.ReferenceOrderID = TestSession.Random.Next();
            inserted.ReferenceOrderLineID = TestSession.Random.Next();
            inserted.TransactionDate = TestSession.Random.RandomDateTime();
            inserted.TransactionType = TestSession.Random.RandomString(2);
            inserted.Quantity = TestSession.Random.Next();
            inserted.ActualCost = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new TransactionHistoryModelPrimaryKey()
            {
                TransactionID = inserted.TransactionID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.TransactionID, selectedAfterUpdate.TransactionID);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.ReferenceOrderID, selectedAfterUpdate.ReferenceOrderID);
            Assert.AreEqual(inserted.ReferenceOrderLineID, selectedAfterUpdate.ReferenceOrderLineID);
            Assert.AreEqual(inserted.TransactionDate, selectedAfterUpdate.TransactionDate);
            Assert.AreEqual(inserted.TransactionType, selectedAfterUpdate.TransactionType);
            Assert.AreEqual(inserted.Quantity, selectedAfterUpdate.Quantity);
            Assert.AreEqual(inserted.ActualCost, selectedAfterUpdate.ActualCost);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new TransactionHistoryModelPrimaryKey()
            {
                TransactionID = inserted.TransactionID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}