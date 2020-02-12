
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
    public class ProductPhotoDaoIntegrationTests
    {
        private ProductPhotoDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductPhotoDao();
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
            ProductPhotoModel inserted = new ProductPhotoModel();
            inserted.ThumbNailPhoto = TestSession.Random.RandomBytes();
            inserted.ThumbnailPhotoFileName = TestSession.Random.RandomString(100);
            inserted.LargePhoto = TestSession.Random.RandomBytes();
            inserted.LargePhotoFileName = TestSession.Random.RandomString(100);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new ProductPhotoModelPrimaryKey()
            {
                ProductPhotoID = inserted.ProductPhotoID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductPhotoID,selectedAfterInsert.ProductPhotoID);
            Assert.AreEqual(inserted.ThumbNailPhoto,selectedAfterInsert.ThumbNailPhoto);
            Assert.AreEqual(inserted.ThumbnailPhotoFileName,selectedAfterInsert.ThumbnailPhotoFileName);
            Assert.AreEqual(inserted.LargePhoto,selectedAfterInsert.LargePhoto);
            Assert.AreEqual(inserted.LargePhotoFileName,selectedAfterInsert.LargePhotoFileName);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ThumbNailPhoto = TestSession.Random.RandomBytes();
            inserted.ThumbnailPhotoFileName = TestSession.Random.RandomString(100);
            inserted.LargePhoto = TestSession.Random.RandomBytes();
            inserted.LargePhotoFileName = TestSession.Random.RandomString(100);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new ProductPhotoModelPrimaryKey()
            {
                ProductPhotoID = inserted.ProductPhotoID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductPhotoID, selectedAfterUpdate.ProductPhotoID);
            Assert.AreEqual(inserted.ThumbNailPhoto, selectedAfterUpdate.ThumbNailPhoto);
            Assert.AreEqual(inserted.ThumbnailPhotoFileName, selectedAfterUpdate.ThumbnailPhotoFileName);
            Assert.AreEqual(inserted.LargePhoto, selectedAfterUpdate.LargePhoto);
            Assert.AreEqual(inserted.LargePhotoFileName, selectedAfterUpdate.LargePhotoFileName);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new ProductPhotoModelPrimaryKey()
            {
                ProductPhotoID = inserted.ProductPhotoID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}