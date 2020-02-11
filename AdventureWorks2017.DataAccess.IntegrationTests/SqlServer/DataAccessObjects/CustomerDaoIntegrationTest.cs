
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
    public class CustomerDaoIntegrationTests
    {
        private CustomerDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new CustomerDao();
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
            CustomerModel inserted = new CustomerModel();
            inserted.PersonID = TestSession.Random.Next();
            inserted.StoreID = TestSession.Random.Next();
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.AccountNumber = TestSession.Random.RandomString(10);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new CustomerModelPrimaryKey()
            {
                CustomerID = inserted.CustomerID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.CustomerID,selectedAfterInsert.CustomerID);
            Assert.AreEqual(inserted.PersonID,selectedAfterInsert.PersonID);
            Assert.AreEqual(inserted.StoreID,selectedAfterInsert.StoreID);
            Assert.AreEqual(inserted.TerritoryID,selectedAfterInsert.TerritoryID);
            Assert.AreEqual(inserted.AccountNumber,selectedAfterInsert.AccountNumber);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.PersonID = TestSession.Random.Next();
            inserted.StoreID = TestSession.Random.Next();
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.AccountNumber = TestSession.Random.RandomString(10);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new CustomerModelPrimaryKey()
            {
                CustomerID = inserted.CustomerID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.CustomerID, selectedAfterUpdate.CustomerID);
            Assert.AreEqual(inserted.PersonID, selectedAfterUpdate.PersonID);
            Assert.AreEqual(inserted.StoreID, selectedAfterUpdate.StoreID);
            Assert.AreEqual(inserted.TerritoryID, selectedAfterUpdate.TerritoryID);
            Assert.AreEqual(inserted.AccountNumber, selectedAfterUpdate.AccountNumber);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new CustomerModelPrimaryKey()
            {
                CustomerID = inserted.CustomerID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}