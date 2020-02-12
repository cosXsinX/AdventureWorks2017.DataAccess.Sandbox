
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
    public class WorkOrderDaoIntegrationTests
    {
        private WorkOrderDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new WorkOrderDao();
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
            WorkOrderModel inserted = new WorkOrderModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.OrderQty = TestSession.Random.Next();
            inserted.StockedQty = TestSession.Random.Next();
            inserted.ScrappedQty = TestSession.Random.RandomShort();
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.DueDate = TestSession.Random.RandomDateTime();
            inserted.ScrapReasonID = TestSession.Random.RandomShort();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new WorkOrderModelPrimaryKey()
            {
                WorkOrderID = inserted.WorkOrderID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.WorkOrderID,selectedAfterInsert.WorkOrderID);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.OrderQty,selectedAfterInsert.OrderQty);
            Assert.AreEqual(inserted.StockedQty,selectedAfterInsert.StockedQty);
            Assert.AreEqual(inserted.ScrappedQty,selectedAfterInsert.ScrappedQty);
            Assert.AreEqual(inserted.StartDate,selectedAfterInsert.StartDate);
            Assert.AreEqual(inserted.EndDate,selectedAfterInsert.EndDate);
            Assert.AreEqual(inserted.DueDate,selectedAfterInsert.DueDate);
            Assert.AreEqual(inserted.ScrapReasonID,selectedAfterInsert.ScrapReasonID);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ProductID = TestSession.Random.Next();
            inserted.OrderQty = TestSession.Random.Next();
            inserted.StockedQty = TestSession.Random.Next();
            inserted.ScrappedQty = TestSession.Random.RandomShort();
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.DueDate = TestSession.Random.RandomDateTime();
            inserted.ScrapReasonID = TestSession.Random.RandomShort();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new WorkOrderModelPrimaryKey()
            {
                WorkOrderID = inserted.WorkOrderID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.WorkOrderID, selectedAfterUpdate.WorkOrderID);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.OrderQty, selectedAfterUpdate.OrderQty);
            Assert.AreEqual(inserted.StockedQty, selectedAfterUpdate.StockedQty);
            Assert.AreEqual(inserted.ScrappedQty, selectedAfterUpdate.ScrappedQty);
            Assert.AreEqual(inserted.StartDate, selectedAfterUpdate.StartDate);
            Assert.AreEqual(inserted.EndDate, selectedAfterUpdate.EndDate);
            Assert.AreEqual(inserted.DueDate, selectedAfterUpdate.DueDate);
            Assert.AreEqual(inserted.ScrapReasonID, selectedAfterUpdate.ScrapReasonID);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new WorkOrderModelPrimaryKey()
            {
                WorkOrderID = inserted.WorkOrderID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}