
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
    public class ProductVendorDaoIntegrationTests
    {
        private ProductVendorDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductVendorDao();
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
            ProductVendorModel inserted = new ProductVendorModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.AverageLeadTime = TestSession.Random.Next();
            inserted.StandardPrice = TestSession.Random.RandomDecimal();
            inserted.LastReceiptCost = TestSession.Random.RandomDecimal();
            inserted.LastReceiptDate = TestSession.Random.RandomDateTime();
            inserted.MinOrderQty = TestSession.Random.Next();
            inserted.MaxOrderQty = TestSession.Random.Next();
            inserted.OnOrderQty = TestSession.Random.Next();
            inserted.UnitMeasureCode = TestSession.Random.RandomString(6);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductVendorModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.AverageLeadTime,selectedAfterInsert.AverageLeadTime);
            Assert.AreEqual(inserted.StandardPrice,selectedAfterInsert.StandardPrice);
            Assert.AreEqual(inserted.LastReceiptCost,selectedAfterInsert.LastReceiptCost);
            Assert.AreEqual(inserted.LastReceiptDate,selectedAfterInsert.LastReceiptDate);
            Assert.AreEqual(inserted.MinOrderQty,selectedAfterInsert.MinOrderQty);
            Assert.AreEqual(inserted.MaxOrderQty,selectedAfterInsert.MaxOrderQty);
            Assert.AreEqual(inserted.OnOrderQty,selectedAfterInsert.OnOrderQty);
            Assert.AreEqual(inserted.UnitMeasureCode,selectedAfterInsert.UnitMeasureCode);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.AverageLeadTime = TestSession.Random.Next();
            inserted.StandardPrice = TestSession.Random.RandomDecimal();
            inserted.LastReceiptCost = TestSession.Random.RandomDecimal();
            inserted.LastReceiptDate = TestSession.Random.RandomDateTime();
            inserted.MinOrderQty = TestSession.Random.Next();
            inserted.MaxOrderQty = TestSession.Random.Next();
            inserted.OnOrderQty = TestSession.Random.Next();
            inserted.UnitMeasureCode = TestSession.Random.RandomString(6);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductVendorModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.AverageLeadTime, selectedAfterUpdate.AverageLeadTime);
            Assert.AreEqual(inserted.StandardPrice, selectedAfterUpdate.StandardPrice);
            Assert.AreEqual(inserted.LastReceiptCost, selectedAfterUpdate.LastReceiptCost);
            Assert.AreEqual(inserted.LastReceiptDate, selectedAfterUpdate.LastReceiptDate);
            Assert.AreEqual(inserted.MinOrderQty, selectedAfterUpdate.MinOrderQty);
            Assert.AreEqual(inserted.MaxOrderQty, selectedAfterUpdate.MaxOrderQty);
            Assert.AreEqual(inserted.OnOrderQty, selectedAfterUpdate.OnOrderQty);
            Assert.AreEqual(inserted.UnitMeasureCode, selectedAfterUpdate.UnitMeasureCode);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductVendorModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                BusinessEntityID = inserted.BusinessEntityID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}