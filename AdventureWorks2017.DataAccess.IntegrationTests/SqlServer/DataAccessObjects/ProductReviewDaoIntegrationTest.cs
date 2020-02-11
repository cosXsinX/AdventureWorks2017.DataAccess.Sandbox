
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
    public class ProductReviewDaoIntegrationTests
    {
        private ProductReviewDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductReviewDao();
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
            ProductReviewModel inserted = new ProductReviewModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.ReviewerName = TestSession.Random.RandomString(100);
            inserted.ReviewDate = TestSession.Random.RandomDateTime();
            inserted.EmailAddress = TestSession.Random.RandomString(100);
            inserted.Rating = TestSession.Random.Next();
            inserted.Comments = TestSession.Random.RandomString(7700);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductReviewModelPrimaryKey()
            {
                ProductReviewID = inserted.ProductReviewID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductReviewID,selectedAfterInsert.ProductReviewID);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.ReviewerName,selectedAfterInsert.ReviewerName);
            Assert.AreEqual(inserted.ReviewDate,selectedAfterInsert.ReviewDate);
            Assert.AreEqual(inserted.EmailAddress,selectedAfterInsert.EmailAddress);
            Assert.AreEqual(inserted.Rating,selectedAfterInsert.Rating);
            Assert.AreEqual(inserted.Comments,selectedAfterInsert.Comments);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ProductID = TestSession.Random.Next();
            inserted.ReviewerName = TestSession.Random.RandomString(100);
            inserted.ReviewDate = TestSession.Random.RandomDateTime();
            inserted.EmailAddress = TestSession.Random.RandomString(100);
            inserted.Rating = TestSession.Random.Next();
            inserted.Comments = TestSession.Random.RandomString(7700);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductReviewModelPrimaryKey()
            {
                ProductReviewID = inserted.ProductReviewID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductReviewID, selectedAfterUpdate.ProductReviewID);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.ReviewerName, selectedAfterUpdate.ReviewerName);
            Assert.AreEqual(inserted.ReviewDate, selectedAfterUpdate.ReviewDate);
            Assert.AreEqual(inserted.EmailAddress, selectedAfterUpdate.EmailAddress);
            Assert.AreEqual(inserted.Rating, selectedAfterUpdate.Rating);
            Assert.AreEqual(inserted.Comments, selectedAfterUpdate.Comments);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductReviewModelPrimaryKey()
            {
                ProductReviewID = inserted.ProductReviewID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}