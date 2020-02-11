
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
    public class SalesTerritoryDaoIntegrationTests
    {
        private SalesTerritoryDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesTerritoryDao();
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
            SalesTerritoryModel inserted = new SalesTerritoryModel();
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.CountryRegionCode = TestSession.Random.RandomString(6);
            inserted.Group = TestSession.Random.RandomString(100);
            inserted.SalesYTD = TestSession.Random.RandomDecimal();
            inserted.SalesLastYear = TestSession.Random.RandomDecimal();
            inserted.CostYTD = TestSession.Random.RandomDecimal();
            inserted.CostLastYear = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new SalesTerritoryModelPrimaryKey()
            {
                TerritoryID = inserted.TerritoryID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.TerritoryID,selectedAfterInsert.TerritoryID);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.CountryRegionCode,selectedAfterInsert.CountryRegionCode);
            Assert.AreEqual(inserted.Group,selectedAfterInsert.Group);
            Assert.AreEqual(inserted.SalesYTD,selectedAfterInsert.SalesYTD);
            Assert.AreEqual(inserted.SalesLastYear,selectedAfterInsert.SalesLastYear);
            Assert.AreEqual(inserted.CostYTD,selectedAfterInsert.CostYTD);
            Assert.AreEqual(inserted.CostLastYear,selectedAfterInsert.CostLastYear);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.CountryRegionCode = TestSession.Random.RandomString(6);
            inserted.Group = TestSession.Random.RandomString(100);
            inserted.SalesYTD = TestSession.Random.RandomDecimal();
            inserted.SalesLastYear = TestSession.Random.RandomDecimal();
            inserted.CostYTD = TestSession.Random.RandomDecimal();
            inserted.CostLastYear = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new SalesTerritoryModelPrimaryKey()
            {
                TerritoryID = inserted.TerritoryID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.TerritoryID, selectedAfterUpdate.TerritoryID);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.CountryRegionCode, selectedAfterUpdate.CountryRegionCode);
            Assert.AreEqual(inserted.Group, selectedAfterUpdate.Group);
            Assert.AreEqual(inserted.SalesYTD, selectedAfterUpdate.SalesYTD);
            Assert.AreEqual(inserted.SalesLastYear, selectedAfterUpdate.SalesLastYear);
            Assert.AreEqual(inserted.CostYTD, selectedAfterUpdate.CostYTD);
            Assert.AreEqual(inserted.CostLastYear, selectedAfterUpdate.CostLastYear);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new SalesTerritoryModelPrimaryKey()
            {
                TerritoryID = inserted.TerritoryID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}