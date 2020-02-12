
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
    public class SalesOrderHeaderDaoIntegrationTests
    {
        private SalesOrderHeaderDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesOrderHeaderDao();
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
            SalesOrderHeaderModel inserted = new SalesOrderHeaderModel();
            inserted.RevisionNumber = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.OrderDate = TestSession.Random.RandomDateTime();
            inserted.DueDate = TestSession.Random.RandomDateTime();
            inserted.ShipDate = TestSession.Random.RandomDateTime();
            inserted.Status = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.OnlineOrderFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.SalesOrderNumber = TestSession.Random.RandomString(50);
            inserted.PurchaseOrderNumber = TestSession.Random.RandomString(50);
            inserted.AccountNumber = TestSession.Random.RandomString(30);
            inserted.CustomerID = TestSession.Random.Next();
            inserted.SalesPersonID = TestSession.Random.Next();
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.BillToAddressID = TestSession.Random.Next();
            inserted.ShipToAddressID = TestSession.Random.Next();
            inserted.ShipMethodID = TestSession.Random.Next();
            inserted.CreditCardID = TestSession.Random.Next();
            inserted.CreditCardApprovalCode = TestSession.Random.RandomString(15);
            inserted.CurrencyRateID = TestSession.Random.Next();
            inserted.SubTotal = TestSession.Random.RandomDecimal();
            inserted.TaxAmt = TestSession.Random.RandomDecimal();
            inserted.Freight = TestSession.Random.RandomDecimal();
            inserted.TotalDue = TestSession.Random.RandomDecimal();
            inserted.Comment = TestSession.Random.RandomString(256);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new SalesOrderHeaderModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SalesOrderID,selectedAfterInsert.SalesOrderID);
            Assert.AreEqual(inserted.RevisionNumber,selectedAfterInsert.RevisionNumber);
            Assert.AreEqual(inserted.OrderDate,selectedAfterInsert.OrderDate);
            Assert.AreEqual(inserted.DueDate,selectedAfterInsert.DueDate);
            Assert.AreEqual(inserted.ShipDate,selectedAfterInsert.ShipDate);
            Assert.AreEqual(inserted.Status,selectedAfterInsert.Status);
            Assert.AreEqual(inserted.OnlineOrderFlag,selectedAfterInsert.OnlineOrderFlag);
            Assert.AreEqual(inserted.SalesOrderNumber,selectedAfterInsert.SalesOrderNumber);
            Assert.AreEqual(inserted.PurchaseOrderNumber,selectedAfterInsert.PurchaseOrderNumber);
            Assert.AreEqual(inserted.AccountNumber,selectedAfterInsert.AccountNumber);
            Assert.AreEqual(inserted.CustomerID,selectedAfterInsert.CustomerID);
            Assert.AreEqual(inserted.SalesPersonID,selectedAfterInsert.SalesPersonID);
            Assert.AreEqual(inserted.TerritoryID,selectedAfterInsert.TerritoryID);
            Assert.AreEqual(inserted.BillToAddressID,selectedAfterInsert.BillToAddressID);
            Assert.AreEqual(inserted.ShipToAddressID,selectedAfterInsert.ShipToAddressID);
            Assert.AreEqual(inserted.ShipMethodID,selectedAfterInsert.ShipMethodID);
            Assert.AreEqual(inserted.CreditCardID,selectedAfterInsert.CreditCardID);
            Assert.AreEqual(inserted.CreditCardApprovalCode,selectedAfterInsert.CreditCardApprovalCode);
            Assert.AreEqual(inserted.CurrencyRateID,selectedAfterInsert.CurrencyRateID);
            Assert.AreEqual(inserted.SubTotal,selectedAfterInsert.SubTotal);
            Assert.AreEqual(inserted.TaxAmt,selectedAfterInsert.TaxAmt);
            Assert.AreEqual(inserted.Freight,selectedAfterInsert.Freight);
            Assert.AreEqual(inserted.TotalDue,selectedAfterInsert.TotalDue);
            Assert.AreEqual(inserted.Comment,selectedAfterInsert.Comment);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.RevisionNumber = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.OrderDate = TestSession.Random.RandomDateTime();
            inserted.DueDate = TestSession.Random.RandomDateTime();
            inserted.ShipDate = TestSession.Random.RandomDateTime();
            inserted.Status = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.OnlineOrderFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.SalesOrderNumber = TestSession.Random.RandomString(50);
            inserted.PurchaseOrderNumber = TestSession.Random.RandomString(50);
            inserted.AccountNumber = TestSession.Random.RandomString(30);
            inserted.CustomerID = TestSession.Random.Next();
            inserted.SalesPersonID = TestSession.Random.Next();
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.BillToAddressID = TestSession.Random.Next();
            inserted.ShipToAddressID = TestSession.Random.Next();
            inserted.ShipMethodID = TestSession.Random.Next();
            inserted.CreditCardID = TestSession.Random.Next();
            inserted.CreditCardApprovalCode = TestSession.Random.RandomString(15);
            inserted.CurrencyRateID = TestSession.Random.Next();
            inserted.SubTotal = TestSession.Random.RandomDecimal();
            inserted.TaxAmt = TestSession.Random.RandomDecimal();
            inserted.Freight = TestSession.Random.RandomDecimal();
            inserted.TotalDue = TestSession.Random.RandomDecimal();
            inserted.Comment = TestSession.Random.RandomString(256);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new SalesOrderHeaderModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SalesOrderID, selectedAfterUpdate.SalesOrderID);
            Assert.AreEqual(inserted.RevisionNumber, selectedAfterUpdate.RevisionNumber);
            Assert.AreEqual(inserted.OrderDate, selectedAfterUpdate.OrderDate);
            Assert.AreEqual(inserted.DueDate, selectedAfterUpdate.DueDate);
            Assert.AreEqual(inserted.ShipDate, selectedAfterUpdate.ShipDate);
            Assert.AreEqual(inserted.Status, selectedAfterUpdate.Status);
            Assert.AreEqual(inserted.OnlineOrderFlag, selectedAfterUpdate.OnlineOrderFlag);
            Assert.AreEqual(inserted.SalesOrderNumber, selectedAfterUpdate.SalesOrderNumber);
            Assert.AreEqual(inserted.PurchaseOrderNumber, selectedAfterUpdate.PurchaseOrderNumber);
            Assert.AreEqual(inserted.AccountNumber, selectedAfterUpdate.AccountNumber);
            Assert.AreEqual(inserted.CustomerID, selectedAfterUpdate.CustomerID);
            Assert.AreEqual(inserted.SalesPersonID, selectedAfterUpdate.SalesPersonID);
            Assert.AreEqual(inserted.TerritoryID, selectedAfterUpdate.TerritoryID);
            Assert.AreEqual(inserted.BillToAddressID, selectedAfterUpdate.BillToAddressID);
            Assert.AreEqual(inserted.ShipToAddressID, selectedAfterUpdate.ShipToAddressID);
            Assert.AreEqual(inserted.ShipMethodID, selectedAfterUpdate.ShipMethodID);
            Assert.AreEqual(inserted.CreditCardID, selectedAfterUpdate.CreditCardID);
            Assert.AreEqual(inserted.CreditCardApprovalCode, selectedAfterUpdate.CreditCardApprovalCode);
            Assert.AreEqual(inserted.CurrencyRateID, selectedAfterUpdate.CurrencyRateID);
            Assert.AreEqual(inserted.SubTotal, selectedAfterUpdate.SubTotal);
            Assert.AreEqual(inserted.TaxAmt, selectedAfterUpdate.TaxAmt);
            Assert.AreEqual(inserted.Freight, selectedAfterUpdate.Freight);
            Assert.AreEqual(inserted.TotalDue, selectedAfterUpdate.TotalDue);
            Assert.AreEqual(inserted.Comment, selectedAfterUpdate.Comment);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new SalesOrderHeaderModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}