
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
    public class BusinessEntityAddressDaoIntegrationTests
    {
        private BusinessEntityAddressDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new BusinessEntityAddressDao();
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
            BusinessEntityAddressModel inserted = new BusinessEntityAddressModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.AddressID = TestSession.Random.Next();
            inserted.AddressTypeID = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new BusinessEntityAddressModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                AddressID = inserted.AddressID,
                AddressTypeID = inserted.AddressTypeID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.AddressID,selectedAfterInsert.AddressID);
            Assert.AreEqual(inserted.AddressTypeID,selectedAfterInsert.AddressTypeID);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new BusinessEntityAddressModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                AddressID = inserted.AddressID,
                AddressTypeID = inserted.AddressTypeID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.AddressID, selectedAfterUpdate.AddressID);
            Assert.AreEqual(inserted.AddressTypeID, selectedAfterUpdate.AddressTypeID);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new BusinessEntityAddressModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                AddressID = inserted.AddressID,
                AddressTypeID = inserted.AddressTypeID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}