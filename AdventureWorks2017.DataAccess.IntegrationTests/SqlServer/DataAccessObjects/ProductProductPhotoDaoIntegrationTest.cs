
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
    public class ProductProductPhotoDaoIntegrationTests
    {
        private ProductProductPhotoDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductProductPhotoDao();
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
            ProductProductPhotoModel inserted = new ProductProductPhotoModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.ProductPhotoID = TestSession.Random.Next();
            inserted.Primary = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new ProductProductPhotoModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                ProductPhotoID = inserted.ProductPhotoID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.ProductPhotoID,selectedAfterInsert.ProductPhotoID);
            Assert.AreEqual(inserted.Primary,selectedAfterInsert.Primary);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Primary = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new ProductProductPhotoModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                ProductPhotoID = inserted.ProductPhotoID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.ProductPhotoID, selectedAfterUpdate.ProductPhotoID);
            Assert.AreEqual(inserted.Primary, selectedAfterUpdate.Primary);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new ProductProductPhotoModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                ProductPhotoID = inserted.ProductPhotoID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}