
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
    public class ProductCostHistoryDaoIntegrationTests
    {
        private ProductCostHistoryDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductCostHistoryDao();
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
            ProductCostHistoryModel inserted = new ProductCostHistoryModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.StandardCost = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductCostHistoryModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                StartDate = inserted.StartDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.StartDate,selectedAfterInsert.StartDate);
            Assert.AreEqual(inserted.EndDate,selectedAfterInsert.EndDate);
            Assert.AreEqual(inserted.StandardCost,selectedAfterInsert.StandardCost);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.StandardCost = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductCostHistoryModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                StartDate = inserted.StartDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.StartDate, selectedAfterUpdate.StartDate);
            Assert.AreEqual(inserted.EndDate, selectedAfterUpdate.EndDate);
            Assert.AreEqual(inserted.StandardCost, selectedAfterUpdate.StandardCost);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductCostHistoryModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                StartDate = inserted.StartDate,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}