
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
    public class ProductModelIllustrationDaoIntegrationTests
    {
        private ProductModelIllustrationDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductModelIllustrationDao();
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
            ProductModelIllustrationModel inserted = new ProductModelIllustrationModel();
            inserted.ProductModelID = TestSession.Random.Next();
            inserted.IllustrationID = TestSession.Random.Next();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductModelIllustrationModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
                IllustrationID = inserted.IllustrationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductModelID,selectedAfterInsert.ProductModelID);
            Assert.AreEqual(inserted.IllustrationID,selectedAfterInsert.IllustrationID);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductModelIllustrationModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
                IllustrationID = inserted.IllustrationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductModelID, selectedAfterUpdate.ProductModelID);
            Assert.AreEqual(inserted.IllustrationID, selectedAfterUpdate.IllustrationID);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductModelIllustrationModelPrimaryKey()
            {
                ProductModelID = inserted.ProductModelID,
                IllustrationID = inserted.IllustrationID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}