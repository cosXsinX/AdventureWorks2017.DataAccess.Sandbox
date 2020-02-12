
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
    public class ProductModelDaoIntegrationTests
    {
        private ProductModelDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductModelDao();
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
            ProductModelModel inserted = new ProductModelModel();
            inserted.Name = TestSession.Random.RandomString(50);
            inserted.CatalogDescription = null; //TODO define how to generate random xml;
            inserted.Instructions = null; //TODO define how to generate random xml;
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new ProductModelModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductModelID,selectedAfterInsert.ProductModelID);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.CatalogDescription,selectedAfterInsert.CatalogDescription);
            Assert.AreEqual(inserted.Instructions,selectedAfterInsert.Instructions);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Name = TestSession.Random.RandomString(50);
            inserted.CatalogDescription = null; //TODO define how to generate random xml;
            inserted.Instructions = null; //TODO define how to generate random xml;
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new ProductModelModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductModelID, selectedAfterUpdate.ProductModelID);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.CatalogDescription, selectedAfterUpdate.CatalogDescription);
            Assert.AreEqual(inserted.Instructions, selectedAfterUpdate.Instructions);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new ProductModelModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}