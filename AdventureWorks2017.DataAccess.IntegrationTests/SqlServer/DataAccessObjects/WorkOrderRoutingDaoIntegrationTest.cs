
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
    public class WorkOrderRoutingDaoIntegrationTests
    {
        private WorkOrderRoutingDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new WorkOrderRoutingDao();
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
            WorkOrderRoutingModel inserted = new WorkOrderRoutingModel();
            inserted.WorkOrderID = TestSession.Random.Next();
            inserted.ProductID = TestSession.Random.Next();
            inserted.OperationSequence = TestSession.Random.RandomShort();
            inserted.LocationID = TestSession.Random.RandomShort();
            inserted.ScheduledStartDate = TestSession.Random.RandomDateTime();
            inserted.ScheduledEndDate = TestSession.Random.RandomDateTime();
            inserted.ActualStartDate = TestSession.Random.RandomDateTime();
            inserted.ActualEndDate = TestSession.Random.RandomDateTime();
            inserted.ActualResourceHrs = TestSession.Random.RandomDecimal();
            inserted.PlannedCost = TestSession.Random.RandomDecimal();
            inserted.ActualCost = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new WorkOrderRoutingModelPrimaryKey()
            {
                WorkOrderID = inserted.WorkOrderID,
                ProductID = inserted.ProductID,
                OperationSequence = inserted.OperationSequence,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.WorkOrderID,selectedAfterInsert.WorkOrderID);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.OperationSequence,selectedAfterInsert.OperationSequence);
            Assert.AreEqual(inserted.LocationID,selectedAfterInsert.LocationID);
            Assert.AreEqual(inserted.ScheduledStartDate,selectedAfterInsert.ScheduledStartDate);
            Assert.AreEqual(inserted.ScheduledEndDate,selectedAfterInsert.ScheduledEndDate);
            Assert.AreEqual(inserted.ActualStartDate,selectedAfterInsert.ActualStartDate);
            Assert.AreEqual(inserted.ActualEndDate,selectedAfterInsert.ActualEndDate);
            Assert.AreEqual(inserted.ActualResourceHrs,selectedAfterInsert.ActualResourceHrs);
            Assert.AreEqual(inserted.PlannedCost,selectedAfterInsert.PlannedCost);
            Assert.AreEqual(inserted.ActualCost,selectedAfterInsert.ActualCost);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.LocationID = TestSession.Random.RandomShort();
            inserted.ScheduledStartDate = TestSession.Random.RandomDateTime();
            inserted.ScheduledEndDate = TestSession.Random.RandomDateTime();
            inserted.ActualStartDate = TestSession.Random.RandomDateTime();
            inserted.ActualEndDate = TestSession.Random.RandomDateTime();
            inserted.ActualResourceHrs = TestSession.Random.RandomDecimal();
            inserted.PlannedCost = TestSession.Random.RandomDecimal();
            inserted.ActualCost = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new WorkOrderRoutingModelPrimaryKey()
            {
                WorkOrderID = inserted.WorkOrderID,
                ProductID = inserted.ProductID,
                OperationSequence = inserted.OperationSequence,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.WorkOrderID, selectedAfterUpdate.WorkOrderID);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.OperationSequence, selectedAfterUpdate.OperationSequence);
            Assert.AreEqual(inserted.LocationID, selectedAfterUpdate.LocationID);
            Assert.AreEqual(inserted.ScheduledStartDate, selectedAfterUpdate.ScheduledStartDate);
            Assert.AreEqual(inserted.ScheduledEndDate, selectedAfterUpdate.ScheduledEndDate);
            Assert.AreEqual(inserted.ActualStartDate, selectedAfterUpdate.ActualStartDate);
            Assert.AreEqual(inserted.ActualEndDate, selectedAfterUpdate.ActualEndDate);
            Assert.AreEqual(inserted.ActualResourceHrs, selectedAfterUpdate.ActualResourceHrs);
            Assert.AreEqual(inserted.PlannedCost, selectedAfterUpdate.PlannedCost);
            Assert.AreEqual(inserted.ActualCost, selectedAfterUpdate.ActualCost);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new WorkOrderRoutingModelPrimaryKey()
            {
                WorkOrderID = inserted.WorkOrderID,
                ProductID = inserted.ProductID,
                OperationSequence = inserted.OperationSequence,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}