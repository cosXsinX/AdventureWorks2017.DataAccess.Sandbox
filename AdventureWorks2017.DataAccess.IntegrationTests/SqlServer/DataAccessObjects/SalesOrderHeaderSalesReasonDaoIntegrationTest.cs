
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
    public class SalesOrderHeaderSalesReasonDaoIntegrationTests
    {
        private SalesOrderHeaderSalesReasonDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesOrderHeaderSalesReasonDao();
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
            SalesOrderHeaderSalesReasonModel inserted = new SalesOrderHeaderSalesReasonModel();
            inserted.SalesOrderID = TestSession.Random.Next();
            inserted.SalesReasonID = TestSession.Random.Next();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new SalesOrderHeaderSalesReasonModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
                SalesReasonID = inserted.SalesReasonID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SalesOrderID,selectedAfterInsert.SalesOrderID);
            Assert.AreEqual(inserted.SalesReasonID,selectedAfterInsert.SalesReasonID);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new SalesOrderHeaderSalesReasonModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
                SalesReasonID = inserted.SalesReasonID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SalesOrderID, selectedAfterUpdate.SalesOrderID);
            Assert.AreEqual(inserted.SalesReasonID, selectedAfterUpdate.SalesReasonID);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new SalesOrderHeaderSalesReasonModelPrimaryKey()
            {
                SalesOrderID = inserted.SalesOrderID,
                SalesReasonID = inserted.SalesReasonID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}