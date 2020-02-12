
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
    public class ProductDaoIntegrationTests
    {
        private ProductDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductDao();
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
            ProductModel inserted = new ProductModel();
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.ProductNumber = TestSession.Random.RandomString(50);
            inserted.MakeFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.FinishedGoodsFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.Color = TestSession.Random.RandomString(30);
            inserted.SafetyStockLevel = TestSession.Random.RandomShort();
            inserted.ReorderPoint = TestSession.Random.RandomShort();
            inserted.StandardCost = TestSession.Random.RandomDecimal();
            inserted.ListPrice = TestSession.Random.RandomDecimal();
            inserted.Size = TestSession.Random.RandomString(10);
            inserted.SizeUnitMeasureCode = TestSession.Random.RandomString(6);
            inserted.WeightUnitMeasureCode = TestSession.Random.RandomString(6);
            inserted.Weight = TestSession.Random.RandomDecimal();
            inserted.DaysToManufacture = TestSession.Random.Next();
            inserted.ProductLine = TestSession.Random.RandomString(4);
            inserted.Class = TestSession.Random.RandomString(4);
            inserted.Style = TestSession.Random.RandomString(4);
            inserted.ProductSubcategoryID = TestSession.Random.Next();
            inserted.ProductModelID = TestSession.Random.Next();
            inserted.SellStartDate = TestSession.Random.RandomDateTime();
            inserted.SellEndDate = TestSession.Random.RandomDateTime();
            inserted.DiscontinuedDate = TestSession.Random.RandomDateTime();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new ProductModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.ProductNumber,selectedAfterInsert.ProductNumber);
            Assert.AreEqual(inserted.MakeFlag,selectedAfterInsert.MakeFlag);
            Assert.AreEqual(inserted.FinishedGoodsFlag,selectedAfterInsert.FinishedGoodsFlag);
            Assert.AreEqual(inserted.Color,selectedAfterInsert.Color);
            Assert.AreEqual(inserted.SafetyStockLevel,selectedAfterInsert.SafetyStockLevel);
            Assert.AreEqual(inserted.ReorderPoint,selectedAfterInsert.ReorderPoint);
            Assert.AreEqual(inserted.StandardCost,selectedAfterInsert.StandardCost);
            Assert.AreEqual(inserted.ListPrice,selectedAfterInsert.ListPrice);
            Assert.AreEqual(inserted.Size,selectedAfterInsert.Size);
            Assert.AreEqual(inserted.SizeUnitMeasureCode,selectedAfterInsert.SizeUnitMeasureCode);
            Assert.AreEqual(inserted.WeightUnitMeasureCode,selectedAfterInsert.WeightUnitMeasureCode);
            Assert.AreEqual(inserted.Weight,selectedAfterInsert.Weight);
            Assert.AreEqual(inserted.DaysToManufacture,selectedAfterInsert.DaysToManufacture);
            Assert.AreEqual(inserted.ProductLine,selectedAfterInsert.ProductLine);
            Assert.AreEqual(inserted.Class,selectedAfterInsert.Class);
            Assert.AreEqual(inserted.Style,selectedAfterInsert.Style);
            Assert.AreEqual(inserted.ProductSubcategoryID,selectedAfterInsert.ProductSubcategoryID);
            Assert.AreEqual(inserted.ProductModelID,selectedAfterInsert.ProductModelID);
            Assert.AreEqual(inserted.SellStartDate,selectedAfterInsert.SellStartDate);
            Assert.AreEqual(inserted.SellEndDate,selectedAfterInsert.SellEndDate);
            Assert.AreEqual(inserted.DiscontinuedDate,selectedAfterInsert.DiscontinuedDate);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.ProductNumber = TestSession.Random.RandomString(50);
            inserted.MakeFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.FinishedGoodsFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.Color = TestSession.Random.RandomString(30);
            inserted.SafetyStockLevel = TestSession.Random.RandomShort();
            inserted.ReorderPoint = TestSession.Random.RandomShort();
            inserted.StandardCost = TestSession.Random.RandomDecimal();
            inserted.ListPrice = TestSession.Random.RandomDecimal();
            inserted.Size = TestSession.Random.RandomString(10);
            inserted.SizeUnitMeasureCode = TestSession.Random.RandomString(6);
            inserted.WeightUnitMeasureCode = TestSession.Random.RandomString(6);
            inserted.Weight = TestSession.Random.RandomDecimal();
            inserted.DaysToManufacture = TestSession.Random.Next();
            inserted.ProductLine = TestSession.Random.RandomString(4);
            inserted.Class = TestSession.Random.RandomString(4);
            inserted.Style = TestSession.Random.RandomString(4);
            inserted.ProductSubcategoryID = TestSession.Random.Next();
            inserted.ProductModelID = TestSession.Random.Next();
            inserted.SellStartDate = TestSession.Random.RandomDateTime();
            inserted.SellEndDate = TestSession.Random.RandomDateTime();
            inserted.DiscontinuedDate = TestSession.Random.RandomDateTime();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new ProductModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.ProductNumber, selectedAfterUpdate.ProductNumber);
            Assert.AreEqual(inserted.MakeFlag, selectedAfterUpdate.MakeFlag);
            Assert.AreEqual(inserted.FinishedGoodsFlag, selectedAfterUpdate.FinishedGoodsFlag);
            Assert.AreEqual(inserted.Color, selectedAfterUpdate.Color);
            Assert.AreEqual(inserted.SafetyStockLevel, selectedAfterUpdate.SafetyStockLevel);
            Assert.AreEqual(inserted.ReorderPoint, selectedAfterUpdate.ReorderPoint);
            Assert.AreEqual(inserted.StandardCost, selectedAfterUpdate.StandardCost);
            Assert.AreEqual(inserted.ListPrice, selectedAfterUpdate.ListPrice);
            Assert.AreEqual(inserted.Size, selectedAfterUpdate.Size);
            Assert.AreEqual(inserted.SizeUnitMeasureCode, selectedAfterUpdate.SizeUnitMeasureCode);
            Assert.AreEqual(inserted.WeightUnitMeasureCode, selectedAfterUpdate.WeightUnitMeasureCode);
            Assert.AreEqual(inserted.Weight, selectedAfterUpdate.Weight);
            Assert.AreEqual(inserted.DaysToManufacture, selectedAfterUpdate.DaysToManufacture);
            Assert.AreEqual(inserted.ProductLine, selectedAfterUpdate.ProductLine);
            Assert.AreEqual(inserted.Class, selectedAfterUpdate.Class);
            Assert.AreEqual(inserted.Style, selectedAfterUpdate.Style);
            Assert.AreEqual(inserted.ProductSubcategoryID, selectedAfterUpdate.ProductSubcategoryID);
            Assert.AreEqual(inserted.ProductModelID, selectedAfterUpdate.ProductModelID);
            Assert.AreEqual(inserted.SellStartDate, selectedAfterUpdate.SellStartDate);
            Assert.AreEqual(inserted.SellEndDate, selectedAfterUpdate.SellEndDate);
            Assert.AreEqual(inserted.DiscontinuedDate, selectedAfterUpdate.DiscontinuedDate);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new ProductModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}