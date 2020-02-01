
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
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ProductProductPhotoDao();
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
            ProductProductPhotoModel inserted = new ProductProductPhotoModel();
            inserted.ProductID = TestSession.Random.Next();
            inserted.ProductPhotoID = TestSession.Random.Next();
            inserted.Primary = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ProductProductPhotoModelPrimaryKey()
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

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ProductProductPhotoModelPrimaryKey()
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
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ProductProductPhotoModelPrimaryKey()
            {
                ProductID = inserted.ProductID,
                ProductPhotoID = inserted.ProductPhotoID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}