
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
    public class ProductCategoryDaoIntegrationTests
    {
        private ProductCategoryDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductCategoryDao();
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
            ProductCategoryModel inserted = new ProductCategoryModel();
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductCategoryModelPrimaryKey()
            {
                ProductCategoryID = inserted.ProductCategoryID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductCategoryID,selectedAfterInsert.ProductCategoryID);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductCategoryModelPrimaryKey()
            {
                ProductCategoryID = inserted.ProductCategoryID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductCategoryID, selectedAfterUpdate.ProductCategoryID);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductCategoryModelPrimaryKey()
            {
                ProductCategoryID = inserted.ProductCategoryID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}