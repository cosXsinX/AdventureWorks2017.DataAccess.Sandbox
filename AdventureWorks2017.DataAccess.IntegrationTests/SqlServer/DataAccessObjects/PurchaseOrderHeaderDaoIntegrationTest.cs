
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
    public class PurchaseOrderHeaderDaoIntegrationTests
    {
        private PurchaseOrderHeaderDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new PurchaseOrderHeaderDao();
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
            PurchaseOrderHeaderModel inserted = new PurchaseOrderHeaderModel();
            inserted.RevisionNumber = Convert.ToByte(TestSession.Random.RandomString(3));
            inserted.Status = Convert.ToByte(TestSession.Random.RandomString(3));
            inserted.EmployeeID = TestSession.Random.Next();
            inserted.VendorID = TestSession.Random.Next();
            inserted.ShipMethodID = TestSession.Random.Next();
            inserted.OrderDate = TestSession.Random.RandomDateTime();
            inserted.ShipDate = TestSession.Random.RandomDateTime();
            inserted.SubTotal = TestSession.Random.RandomDecimal();
            inserted.TaxAmt = TestSession.Random.RandomDecimal();
            inserted.Freight = TestSession.Random.RandomDecimal();
            inserted.TotalDue = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new PurchaseOrderHeaderModelPrimaryKey()
            {
                PurchaseOrderID = inserted.PurchaseOrderID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.PurchaseOrderID,selectedAfterInsert.PurchaseOrderID);
            Assert.AreEqual(inserted.RevisionNumber,selectedAfterInsert.RevisionNumber);
            Assert.AreEqual(inserted.Status,selectedAfterInsert.Status);
            Assert.AreEqual(inserted.EmployeeID,selectedAfterInsert.EmployeeID);
            Assert.AreEqual(inserted.VendorID,selectedAfterInsert.VendorID);
            Assert.AreEqual(inserted.ShipMethodID,selectedAfterInsert.ShipMethodID);
            Assert.AreEqual(inserted.OrderDate,selectedAfterInsert.OrderDate);
            Assert.AreEqual(inserted.ShipDate,selectedAfterInsert.ShipDate);
            Assert.AreEqual(inserted.SubTotal,selectedAfterInsert.SubTotal);
            Assert.AreEqual(inserted.TaxAmt,selectedAfterInsert.TaxAmt);
            Assert.AreEqual(inserted.Freight,selectedAfterInsert.Freight);
            Assert.AreEqual(inserted.TotalDue,selectedAfterInsert.TotalDue);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.RevisionNumber = Convert.ToByte(TestSession.Random.RandomString(3));
            inserted.Status = Convert.ToByte(TestSession.Random.RandomString(3));
            inserted.EmployeeID = TestSession.Random.Next();
            inserted.VendorID = TestSession.Random.Next();
            inserted.ShipMethodID = TestSession.Random.Next();
            inserted.OrderDate = TestSession.Random.RandomDateTime();
            inserted.ShipDate = TestSession.Random.RandomDateTime();
            inserted.SubTotal = TestSession.Random.RandomDecimal();
            inserted.TaxAmt = TestSession.Random.RandomDecimal();
            inserted.Freight = TestSession.Random.RandomDecimal();
            inserted.TotalDue = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new PurchaseOrderHeaderModelPrimaryKey()
            {
                PurchaseOrderID = inserted.PurchaseOrderID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.PurchaseOrderID, selectedAfterUpdate.PurchaseOrderID);
            Assert.AreEqual(inserted.RevisionNumber, selectedAfterUpdate.RevisionNumber);
            Assert.AreEqual(inserted.Status, selectedAfterUpdate.Status);
            Assert.AreEqual(inserted.EmployeeID, selectedAfterUpdate.EmployeeID);
            Assert.AreEqual(inserted.VendorID, selectedAfterUpdate.VendorID);
            Assert.AreEqual(inserted.ShipMethodID, selectedAfterUpdate.ShipMethodID);
            Assert.AreEqual(inserted.OrderDate, selectedAfterUpdate.OrderDate);
            Assert.AreEqual(inserted.ShipDate, selectedAfterUpdate.ShipDate);
            Assert.AreEqual(inserted.SubTotal, selectedAfterUpdate.SubTotal);
            Assert.AreEqual(inserted.TaxAmt, selectedAfterUpdate.TaxAmt);
            Assert.AreEqual(inserted.Freight, selectedAfterUpdate.Freight);
            Assert.AreEqual(inserted.TotalDue, selectedAfterUpdate.TotalDue);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new PurchaseOrderHeaderModelPrimaryKey()
            {
                PurchaseOrderID = inserted.PurchaseOrderID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}