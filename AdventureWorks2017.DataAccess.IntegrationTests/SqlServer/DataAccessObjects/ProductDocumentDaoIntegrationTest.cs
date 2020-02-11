
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
    public class ProductDocumentDaoIntegrationTests
    {
        private ProductDocumentDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductDocumentDao();
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
            ProductDocumentModel inserted = new ProductDocumentModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.DocumentNode = Microsoft.SqlServer.Types.SqlHierarchyId.Null; //TODO define how to generate random hierarchy id in test session;
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductDocumentModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                DocumentNode = inserted.DocumentNode,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.DocumentNode,selectedAfterInsert.DocumentNode);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductDocumentModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                DocumentNode = inserted.DocumentNode,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.DocumentNode, selectedAfterUpdate.DocumentNode);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductDocumentModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                DocumentNode = inserted.DocumentNode,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}