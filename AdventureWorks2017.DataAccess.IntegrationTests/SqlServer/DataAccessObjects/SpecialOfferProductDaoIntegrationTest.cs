
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
    public class SpecialOfferProductDaoIntegrationTests
    {
        private SpecialOfferProductDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SpecialOfferProductDao();
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
            SpecialOfferProductModel inserted = new SpecialOfferProductModel();
            inserted.SpecialOfferID = TestSession.Random.Next();
            inserted.ProductID = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new SpecialOfferProductModelPrimaryKey()
            {
                SpecialOfferID = inserted.SpecialOfferID,
                ProductID = inserted.ProductID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SpecialOfferID,selectedAfterInsert.SpecialOfferID);
            Assert.AreEqual(inserted.ProductID,selectedAfterInsert.ProductID);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new SpecialOfferProductModelPrimaryKey()
            {
                SpecialOfferID = inserted.SpecialOfferID,
                ProductID = inserted.ProductID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SpecialOfferID, selectedAfterUpdate.SpecialOfferID);
            Assert.AreEqual(inserted.ProductID, selectedAfterUpdate.ProductID);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new SpecialOfferProductModelPrimaryKey()
            {
                SpecialOfferID = inserted.SpecialOfferID,
                ProductID = inserted.ProductID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}