
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
    public class ProductModelProductDescriptionCultureDaoIntegrationTests
    {
        private ProductModelProductDescriptionCultureDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductModelProductDescriptionCultureDao();
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
            ProductModelProductDescriptionCultureModel inserted = new ProductModelProductDescriptionCultureModel();
            inserted.ProductModelID = TestSession.Random.Next();
            inserted.ProductDescriptionID = TestSession.Random.Next();
            inserted.CultureID = TestSession.Random.RandomString(12);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductModelProductDescriptionCultureModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
                ProductDescriptionID = inserted.ProductDescriptionID,
                CultureID = inserted.CultureID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductModelID,selectedAfterInsert.ProductModelID);
            Assert.AreEqual(inserted.ProductDescriptionID,selectedAfterInsert.ProductDescriptionID);
            Assert.AreEqual(inserted.CultureID,selectedAfterInsert.CultureID);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductModelProductDescriptionCultureModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
                ProductDescriptionID = inserted.ProductDescriptionID,
                CultureID = inserted.CultureID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductModelID, selectedAfterUpdate.ProductModelID);
            Assert.AreEqual(inserted.ProductDescriptionID, selectedAfterUpdate.ProductDescriptionID);
            Assert.AreEqual(inserted.CultureID, selectedAfterUpdate.CultureID);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductModelProductDescriptionCultureModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
                ProductDescriptionID = inserted.ProductDescriptionID,
                CultureID = inserted.CultureID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}