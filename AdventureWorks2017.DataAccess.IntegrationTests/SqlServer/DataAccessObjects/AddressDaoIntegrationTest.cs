
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
    public class AddressDaoIntegrationTests
    {
        private AddressDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new AddressDao();
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
            AddressModel inserted = new AddressModel();
            inserted.AddressLine1 = TestSession.Random.RandomString(120);
            inserted.AddressLine2 = TestSession.Random.RandomString(120);
            inserted.City = TestSession.Random.RandomString(60);
            inserted.StateProvinceID = TestSession.Random.Next();
            inserted.PostalCode = TestSession.Random.RandomString(30);
            inserted.SpatialLocation = TestSession.Random.RandomSqlGeography();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new AddressModelPrimaryKey()
            {
                AddressID = inserted.AddressID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.AddressID,selectedAfterInsert.AddressID);
            Assert.AreEqual(inserted.AddressLine1,selectedAfterInsert.AddressLine1);
            Assert.AreEqual(inserted.AddressLine2,selectedAfterInsert.AddressLine2);
            Assert.AreEqual(inserted.City,selectedAfterInsert.City);
            Assert.AreEqual(inserted.StateProvinceID,selectedAfterInsert.StateProvinceID);
            Assert.AreEqual(inserted.PostalCode,selectedAfterInsert.PostalCode);
            Assert.AreEqual(inserted.SpatialLocation,selectedAfterInsert.SpatialLocation);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.AddressLine1 = TestSession.Random.RandomString(120);
            inserted.AddressLine2 = TestSession.Random.RandomString(120);
            inserted.City = TestSession.Random.RandomString(60);
            inserted.StateProvinceID = TestSession.Random.Next();
            inserted.PostalCode = TestSession.Random.RandomString(30);
            inserted.SpatialLocation = TestSession.Random.RandomSqlGeography();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new AddressModelPrimaryKey()
            {
                AddressID = inserted.AddressID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.AddressID, selectedAfterUpdate.AddressID);
            Assert.AreEqual(inserted.AddressLine1, selectedAfterUpdate.AddressLine1);
            Assert.AreEqual(inserted.AddressLine2, selectedAfterUpdate.AddressLine2);
            Assert.AreEqual(inserted.City, selectedAfterUpdate.City);
            Assert.AreEqual(inserted.StateProvinceID, selectedAfterUpdate.StateProvinceID);
            Assert.AreEqual(inserted.PostalCode, selectedAfterUpdate.PostalCode);
            Assert.AreEqual(inserted.SpatialLocation, selectedAfterUpdate.SpatialLocation);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new AddressModelPrimaryKey()
            {
                AddressID = inserted.AddressID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion


            _connection.Close();
        }
    }
}