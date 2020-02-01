
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
    public class CreditCardDaoIntegrationTests
    {
        private CreditCardDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new CreditCardDao();
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
            CreditCardModel inserted = new CreditCardModel();
            inserted.CardType = TestSession.Random.RandomString(100);
            inserted.CardNumber = TestSession.Random.RandomString(50);
            inserted.ExpMonth = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.ExpYear = TestSession.Random.RandomShort();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new CreditCardModelPrimaryKey()
            {
                CreditCardID = inserted.CreditCardID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.CreditCardID,selectedAfterInsert.CreditCardID);
            Assert.AreEqual(inserted.CardType,selectedAfterInsert.CardType);
            Assert.AreEqual(inserted.CardNumber,selectedAfterInsert.CardNumber);
            Assert.AreEqual(inserted.ExpMonth,selectedAfterInsert.ExpMonth);
            Assert.AreEqual(inserted.ExpYear,selectedAfterInsert.ExpYear);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.CardType = TestSession.Random.RandomString(100);
            inserted.CardNumber = TestSession.Random.RandomString(50);
            inserted.ExpMonth = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.ExpYear = TestSession.Random.RandomShort();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new CreditCardModelPrimaryKey()
            {
                CreditCardID = inserted.CreditCardID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.CreditCardID, selectedAfterUpdate.CreditCardID);
            Assert.AreEqual(inserted.CardType, selectedAfterUpdate.CardType);
            Assert.AreEqual(inserted.CardNumber, selectedAfterUpdate.CardNumber);
            Assert.AreEqual(inserted.ExpMonth, selectedAfterUpdate.ExpMonth);
            Assert.AreEqual(inserted.ExpYear, selectedAfterUpdate.ExpYear);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new CreditCardModelPrimaryKey()
            {
                CreditCardID = inserted.CreditCardID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}