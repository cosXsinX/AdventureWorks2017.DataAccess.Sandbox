
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
    public class SalesOrderDetailDaoIntegrationTests
    {
        private SalesOrderDetailDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesOrderDetailDao();
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
            SalesOrderDetailModel inserted = new SalesOrderDetailModel();
            inserted.SalesOrderID = TestSession.Random.Next();
            inserted.CarrierTrackingNumber = TestSession.Random.RandomString(50);
            inserted.OrderQty = TestSession.Random.RandomShort();
            inserted.ProductID = TestSession.Random.Next();
            inserted.SpecialOfferID = TestSession.Random.Next();
            inserted.UnitPrice = TestSession.Random.RandomDecimal();
            inserted.UnitPriceDiscount = TestSession.Random.RandomDecimal();
            inserted.LineTotal = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new SalesOrderDetailModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
                SalesOrderDetailID = inserted.SalesOrderDetailID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SalesOrderID,selectedAfterInsert.SalesOrderID);
            Assert.AreEqual(inserted.SalesOrderDetailID,selectedAfterInsert.SalesOrderDetailID);
            Assert.AreEqual(inserted.CarrierTrackingNumber,selectedAfterInsert.CarrierTrackingNumber);
            Assert.AreEqual(inserted.OrderQty,selectedAfterInsert.OrderQty);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.SpecialOfferID,selectedAfterInsert.SpecialOfferID);
            Assert.AreEqual(inserted.UnitPrice,selectedAfterInsert.UnitPrice);
            Assert.AreEqual(inserted.UnitPriceDiscount,selectedAfterInsert.UnitPriceDiscount);
            Assert.AreEqual(inserted.LineTotal,selectedAfterInsert.LineTotal);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.CarrierTrackingNumber = TestSession.Random.RandomString(50);
            inserted.OrderQty = TestSession.Random.RandomShort();
            inserted.ProductID = TestSession.Random.Next();
            inserted.SpecialOfferID = TestSession.Random.Next();
            inserted.UnitPrice = TestSession.Random.RandomDecimal();
            inserted.UnitPriceDiscount = TestSession.Random.RandomDecimal();
            inserted.LineTotal = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new SalesOrderDetailModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
                SalesOrderDetailID = inserted.SalesOrderDetailID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SalesOrderID, selectedAfterUpdate.SalesOrderID);
            Assert.AreEqual(inserted.SalesOrderDetailID, selectedAfterUpdate.SalesOrderDetailID);
            Assert.AreEqual(inserted.CarrierTrackingNumber, selectedAfterUpdate.CarrierTrackingNumber);
            Assert.AreEqual(inserted.OrderQty, selectedAfterUpdate.OrderQty);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.SpecialOfferID, selectedAfterUpdate.SpecialOfferID);
            Assert.AreEqual(inserted.UnitPrice, selectedAfterUpdate.UnitPrice);
            Assert.AreEqual(inserted.UnitPriceDiscount, selectedAfterUpdate.UnitPriceDiscount);
            Assert.AreEqual(inserted.LineTotal, selectedAfterUpdate.LineTotal);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new SalesOrderDetailModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
                SalesOrderDetailID = inserted.SalesOrderDetailID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}