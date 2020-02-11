
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
    public class SalesPersonQuotaHistoryDaoIntegrationTests
    {
        private SalesPersonQuotaHistoryDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesPersonQuotaHistoryDao();
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
            SalesPersonQuotaHistoryModel inserted = new SalesPersonQuotaHistoryModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.QuotaDate = TestSession.Random.RandomDateTime();
            inserted.SalesQuota = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new SalesPersonQuotaHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                QuotaDate = inserted.QuotaDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.QuotaDate,selectedAfterInsert.QuotaDate);
            Assert.AreEqual(inserted.SalesQuota,selectedAfterInsert.SalesQuota);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.SalesQuota = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new SalesPersonQuotaHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                QuotaDate = inserted.QuotaDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.QuotaDate, selectedAfterUpdate.QuotaDate);
            Assert.AreEqual(inserted.SalesQuota, selectedAfterUpdate.SalesQuota);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new SalesPersonQuotaHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                QuotaDate = inserted.QuotaDate,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}