
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
    public class ProductInventoryDaoIntegrationTests
    {
        private ProductInventoryDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductInventoryDao();
        }

        //TODO execute when there is no indexes
        [Test]
        public void GetAllIntegrationTest()
        {
            var connection = TestSession.GetConnection();
            connection.Open();
            var selecteds = _tested.GetAll(connection);
            Assert.IsNotNull(selecteds);
            connection.Close();
        }

        [Test]
        public void IntegrationTest()
        {
            var connection = TestSession.GetConnection();
            connection.Open();
            #region good insertion and select by id test
            ProductInventoryModel inserted = new ProductInventoryModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.LocationID = TestSession.Random.RandomShort();
            inserted.Shelf = TestSession.Random.RandomString(20);
            inserted.Bin = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.Quantity = TestSession.Random.RandomShort();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new ProductInventoryModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                LocationID = inserted.LocationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.LocationID,selectedAfterInsert.LocationID);
            Assert.AreEqual(inserted.Shelf,selectedAfterInsert.Shelf);
            Assert.AreEqual(inserted.Bin,selectedAfterInsert.Bin);
            Assert.AreEqual(inserted.Quantity,selectedAfterInsert.Quantity);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Shelf = TestSession.Random.RandomString(20);
            inserted.Bin = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.Quantity = TestSession.Random.RandomShort();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new ProductInventoryModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                LocationID = inserted.LocationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.LocationID, selectedAfterUpdate.LocationID);
            Assert.AreEqual(inserted.Shelf, selectedAfterUpdate.Shelf);
            Assert.AreEqual(inserted.Bin, selectedAfterUpdate.Bin);
            Assert.AreEqual(inserted.Quantity, selectedAfterUpdate.Quantity);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new ProductInventoryModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                LocationID = inserted.LocationID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}