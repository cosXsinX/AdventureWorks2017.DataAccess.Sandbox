
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
    public class PurchaseOrderDetailDaoIntegrationTests
    {
        private PurchaseOrderDetailDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new PurchaseOrderDetailDao();
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
            PurchaseOrderDetailModel inserted = new PurchaseOrderDetailModel();
            inserted.PurchaseOrderID = TestSession.Random.Next();
            inserted.DueDate = TestSession.Random.RandomDateTime();
            inserted.OrderQty = TestSession.Random.RandomShort();
            inserted.ProductID = TestSession.Random.Next();
            inserted.UnitPrice = TestSession.Random.RandomDecimal();
            inserted.LineTotal = TestSession.Random.RandomDecimal();
            inserted.ReceivedQty = TestSession.Random.RandomDecimal();
            inserted.RejectedQty = TestSession.Random.RandomDecimal();
            inserted.StockedQty = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new PurchaseOrderDetailModelPrimaryKey()
            {
                PurchaseOrderID = inserted.PurchaseOrderID,
                PurchaseOrderDetailID = inserted.PurchaseOrderDetailID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.PurchaseOrderID,selectedAfterInsert.PurchaseOrderID);
            Assert.AreEqual(inserted.PurchaseOrderDetailID,selectedAfterInsert.PurchaseOrderDetailID);
            Assert.AreEqual(inserted.DueDate,selectedAfterInsert.DueDate);
            Assert.AreEqual(inserted.OrderQty,selectedAfterInsert.OrderQty);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.UnitPrice,selectedAfterInsert.UnitPrice);
            Assert.AreEqual(inserted.LineTotal,selectedAfterInsert.LineTotal);
            Assert.AreEqual(inserted.ReceivedQty,selectedAfterInsert.ReceivedQty);
            Assert.AreEqual(inserted.RejectedQty,selectedAfterInsert.RejectedQty);
            Assert.AreEqual(inserted.StockedQty,selectedAfterInsert.StockedQty);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.DueDate = TestSession.Random.RandomDateTime();
            inserted.OrderQty = TestSession.Random.RandomShort();
            inserted.ProductID = TestSession.Random.Next();
            inserted.UnitPrice = TestSession.Random.RandomDecimal();
            inserted.LineTotal = TestSession.Random.RandomDecimal();
            inserted.ReceivedQty = TestSession.Random.RandomDecimal();
            inserted.RejectedQty = TestSession.Random.RandomDecimal();
            inserted.StockedQty = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new PurchaseOrderDetailModelPrimaryKey()
            {
                PurchaseOrderID = inserted.PurchaseOrderID,
                PurchaseOrderDetailID = inserted.PurchaseOrderDetailID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.PurchaseOrderID, selectedAfterUpdate.PurchaseOrderID);
            Assert.AreEqual(inserted.PurchaseOrderDetailID, selectedAfterUpdate.PurchaseOrderDetailID);
            Assert.AreEqual(inserted.DueDate, selectedAfterUpdate.DueDate);
            Assert.AreEqual(inserted.OrderQty, selectedAfterUpdate.OrderQty);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.UnitPrice, selectedAfterUpdate.UnitPrice);
            Assert.AreEqual(inserted.LineTotal, selectedAfterUpdate.LineTotal);
            Assert.AreEqual(inserted.ReceivedQty, selectedAfterUpdate.ReceivedQty);
            Assert.AreEqual(inserted.RejectedQty, selectedAfterUpdate.RejectedQty);
            Assert.AreEqual(inserted.StockedQty, selectedAfterUpdate.StockedQty);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new PurchaseOrderDetailModelPrimaryKey()
            {
                PurchaseOrderID = inserted.PurchaseOrderID,
                PurchaseOrderDetailID = inserted.PurchaseOrderDetailID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}