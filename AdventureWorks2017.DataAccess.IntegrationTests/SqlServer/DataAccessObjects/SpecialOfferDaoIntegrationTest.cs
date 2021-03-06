
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
    public class SpecialOfferDaoIntegrationTests
    {
        private SpecialOfferDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SpecialOfferDao();
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
            SpecialOfferModel inserted = new SpecialOfferModel();
            inserted.Description = TestSession.Random.RandomString(255);
            inserted.DiscountPct = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Type = TestSession.Random.RandomString(50);
            inserted.Category = TestSession.Random.RandomString(50);
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.MinQty = TestSession.Random.Next();
            inserted.MaxQty = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new SpecialOfferModelPrimaryKey()
            {
                SpecialOfferID = inserted.SpecialOfferID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SpecialOfferID,selectedAfterInsert.SpecialOfferID);
            Assert.AreEqual(inserted.Description,selectedAfterInsert.Description);
            Assert.AreEqual(inserted.DiscountPct,selectedAfterInsert.DiscountPct);
            Assert.AreEqual(inserted.Type,selectedAfterInsert.Type);
            Assert.AreEqual(inserted.Category,selectedAfterInsert.Category);
            Assert.AreEqual(inserted.StartDate,selectedAfterInsert.StartDate);
            Assert.AreEqual(inserted.EndDate,selectedAfterInsert.EndDate);
            Assert.AreEqual(inserted.MinQty,selectedAfterInsert.MinQty);
            Assert.AreEqual(inserted.MaxQty,selectedAfterInsert.MaxQty);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Description = TestSession.Random.RandomString(255);
            inserted.DiscountPct = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Type = TestSession.Random.RandomString(50);
            inserted.Category = TestSession.Random.RandomString(50);
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.MinQty = TestSession.Random.Next();
            inserted.MaxQty = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new SpecialOfferModelPrimaryKey()
            {
                SpecialOfferID = inserted.SpecialOfferID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SpecialOfferID, selectedAfterUpdate.SpecialOfferID);
            Assert.AreEqual(inserted.Description, selectedAfterUpdate.Description);
            Assert.AreEqual(inserted.DiscountPct, selectedAfterUpdate.DiscountPct);
            Assert.AreEqual(inserted.Type, selectedAfterUpdate.Type);
            Assert.AreEqual(inserted.Category, selectedAfterUpdate.Category);
            Assert.AreEqual(inserted.StartDate, selectedAfterUpdate.StartDate);
            Assert.AreEqual(inserted.EndDate, selectedAfterUpdate.EndDate);
            Assert.AreEqual(inserted.MinQty, selectedAfterUpdate.MinQty);
            Assert.AreEqual(inserted.MaxQty, selectedAfterUpdate.MaxQty);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new SpecialOfferModelPrimaryKey()
            {
                SpecialOfferID = inserted.SpecialOfferID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}