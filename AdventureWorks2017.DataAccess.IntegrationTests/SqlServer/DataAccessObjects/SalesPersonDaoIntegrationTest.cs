
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
    public class SalesPersonDaoIntegrationTests
    {
        private SalesPersonDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesPersonDao();
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
            SalesPersonModel inserted = new SalesPersonModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.SalesQuota = TestSession.Random.RandomDecimal();
            inserted.Bonus = TestSession.Random.RandomDecimal();
            inserted.CommissionPct = Convert.ToDecimal(TestSession.Random.Next());
            inserted.SalesYTD = TestSession.Random.RandomDecimal();
            inserted.SalesLastYear = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new SalesPersonModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.TerritoryID,selectedAfterInsert.TerritoryID);
            Assert.AreEqual(inserted.SalesQuota,selectedAfterInsert.SalesQuota);
            Assert.AreEqual(inserted.Bonus,selectedAfterInsert.Bonus);
            Assert.AreEqual(inserted.CommissionPct,selectedAfterInsert.CommissionPct);
            Assert.AreEqual(inserted.SalesYTD,selectedAfterInsert.SalesYTD);
            Assert.AreEqual(inserted.SalesLastYear,selectedAfterInsert.SalesLastYear);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.SalesQuota = TestSession.Random.RandomDecimal();
            inserted.Bonus = TestSession.Random.RandomDecimal();
            inserted.CommissionPct = Convert.ToDecimal(TestSession.Random.Next());
            inserted.SalesYTD = TestSession.Random.RandomDecimal();
            inserted.SalesLastYear = TestSession.Random.RandomDecimal();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new SalesPersonModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.TerritoryID, selectedAfterUpdate.TerritoryID);
            Assert.AreEqual(inserted.SalesQuota, selectedAfterUpdate.SalesQuota);
            Assert.AreEqual(inserted.Bonus, selectedAfterUpdate.Bonus);
            Assert.AreEqual(inserted.CommissionPct, selectedAfterUpdate.CommissionPct);
            Assert.AreEqual(inserted.SalesYTD, selectedAfterUpdate.SalesYTD);
            Assert.AreEqual(inserted.SalesLastYear, selectedAfterUpdate.SalesLastYear);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new SalesPersonModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}