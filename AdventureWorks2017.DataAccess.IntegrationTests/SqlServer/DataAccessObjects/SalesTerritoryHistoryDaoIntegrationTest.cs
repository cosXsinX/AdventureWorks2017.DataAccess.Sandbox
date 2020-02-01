
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
    public class SalesTerritoryHistoryDaoIntegrationTests
    {
        private SalesTerritoryHistoryDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesTerritoryHistoryDao();
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
            SalesTerritoryHistoryModel inserted = new SalesTerritoryHistoryModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new SalesTerritoryHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                TerritoryID = inserted.TerritoryID,
                StartDate = inserted.StartDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.TerritoryID,selectedAfterInsert.TerritoryID);
            Assert.AreEqual(inserted.StartDate,selectedAfterInsert.StartDate);
            Assert.AreEqual(inserted.EndDate,selectedAfterInsert.EndDate);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new SalesTerritoryHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                TerritoryID = inserted.TerritoryID,
                StartDate = inserted.StartDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.TerritoryID, selectedAfterUpdate.TerritoryID);
            Assert.AreEqual(inserted.StartDate, selectedAfterUpdate.StartDate);
            Assert.AreEqual(inserted.EndDate, selectedAfterUpdate.EndDate);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new SalesTerritoryHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                TerritoryID = inserted.TerritoryID,
                StartDate = inserted.StartDate,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}