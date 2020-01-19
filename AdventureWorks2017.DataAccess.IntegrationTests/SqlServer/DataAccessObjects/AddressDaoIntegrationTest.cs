using AdventureWorks2017.DataAccess.IntegrationTests.SqlServer.DataAccessObjects;
using AdventureWorks2017.Models;
using AdventureWorks2017.SqlServer.DataAccessObjects;
using Microsoft.SqlServer.Types;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AdventureWorks2017.DataAccess.IntegrationTests
{
    [TestFixture]
    public class AddressDaoIntegrationTests
    {
        private AddressDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new AddressDao();
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
            AddressModel inserted = new AddressModel();
            inserted.AddressID = TestSession.Random.Next();
            inserted.AddressLine1 = TestSession.Random.RandomString(60);
            inserted.AddressLine2 = TestSession.Random.RandomString(60);
            inserted.City = TestSession.Random.RandomString(30);
            inserted.StateProvinceID = 108;
            inserted.PostalCode = TestSession.Random.RandomString(15);
            inserted.SpatialLocation = TestHelper.BuildRandomGeographyPoint();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = DateTime.Today;

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertionAddresss = _tested.GetByPrimaryKey(_connection, new AddressModelPrimaryKey()
            {
                AddressID = inserted.AddressID
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertionAddresss);
            var selectedAfterInsert = selectedAfterInsertionAddresss.Single();
            Assert.AreEqual(inserted.AddressID,selectedAfterInsert.AddressID);
            Assert.AreEqual(inserted.AddressLine1, selectedAfterInsert.AddressLine1);
            Assert.AreEqual(inserted.AddressLine2, selectedAfterInsert.AddressLine2);
            Assert.AreEqual(inserted.City, selectedAfterInsert.City);
            Assert.AreEqual(inserted.StateProvinceID, selectedAfterInsert.StateProvinceID);
            Assert.AreEqual(inserted.PostalCode, selectedAfterInsert.PostalCode);
            //Assert.AreEqual(inserted.SpatialLocation, selectedAfterInsert.SpatialLocation);
            Assert.AreEqual(inserted.rowguid, selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterInsert.ModifiedDate);
            #endregion

            #region update and select by id test
            inserted.AddressLine1 = TestSession.Random.RandomString(60);
            inserted.AddressLine2 = TestSession.Random.RandomString(60);
            inserted.City = TestSession.Random.RandomString(30);
            inserted.StateProvinceID = 108;
            inserted.PostalCode = TestSession.Random.RandomString(15);
            inserted.SpatialLocation = TestHelper.BuildRandomGeographyPoint();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = DateTime.Today;

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new AddressModelPrimaryKey()
            {
                AddressID = inserted.AddressID
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.AddressID, selectedAfterUpdate.AddressID);
            Assert.AreEqual(inserted.AddressLine1, selectedAfterUpdate.AddressLine1);
            Assert.AreEqual(inserted.AddressLine2, selectedAfterUpdate.AddressLine2);
            Assert.AreEqual(inserted.City, selectedAfterUpdate.City);
            Assert.AreEqual(inserted.StateProvinceID, selectedAfterUpdate.StateProvinceID);
            Assert.AreEqual(inserted.PostalCode, selectedAfterUpdate.PostalCode);
            //Assert.AreEqual(inserted.SpatialLocation, selectedAfterUpdate.SpatialLocation);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);
            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new AddressModelPrimaryKey()
            {
                AddressID = inserted.AddressID
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}