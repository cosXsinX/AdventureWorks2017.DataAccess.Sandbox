
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
    public class ShoppingCartItemDaoIntegrationTests
    {
        private ShoppingCartItemDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ShoppingCartItemDao();
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
            ShoppingCartItemModel inserted = new ShoppingCartItemModel();
            inserted.ShoppingCartID = TestSession.Random.RandomString(100);
            inserted.Quantity = TestSession.Random.Next();
            inserted.ProductID = TestSession.Random.Next();
            inserted.DateCreated = TestSession.Random.RandomDateTime();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new ShoppingCartItemModelPrimaryKey()
            {
                ShoppingCartItemID = inserted.ShoppingCartItemID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ShoppingCartItemID,selectedAfterInsert.ShoppingCartItemID);
            Assert.AreEqual(inserted.ShoppingCartID,selectedAfterInsert.ShoppingCartID);
            Assert.AreEqual(inserted.Quantity,selectedAfterInsert.Quantity);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.DateCreated,selectedAfterInsert.DateCreated);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ShoppingCartID = TestSession.Random.RandomString(100);
            inserted.Quantity = TestSession.Random.Next();
            inserted.ProductID = TestSession.Random.Next();
            inserted.DateCreated = TestSession.Random.RandomDateTime();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new ShoppingCartItemModelPrimaryKey()
            {
                ShoppingCartItemID = inserted.ShoppingCartItemID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ShoppingCartItemID, selectedAfterUpdate.ShoppingCartItemID);
            Assert.AreEqual(inserted.ShoppingCartID, selectedAfterUpdate.ShoppingCartID);
            Assert.AreEqual(inserted.Quantity, selectedAfterUpdate.Quantity);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.DateCreated, selectedAfterUpdate.DateCreated);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new ShoppingCartItemModelPrimaryKey()
            {
                ShoppingCartItemID = inserted.ShoppingCartItemID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}