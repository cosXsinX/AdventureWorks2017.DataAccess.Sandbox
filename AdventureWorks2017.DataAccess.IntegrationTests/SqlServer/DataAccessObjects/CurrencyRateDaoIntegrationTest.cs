
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
    public class CurrencyRateDaoIntegrationTests
    {
        private CurrencyRateDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new CurrencyRateDao();
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
            CurrencyRateModel inserted = new CurrencyRateModel();
            inserted.CurrencyRateDate = TestSession.Random.RandomDateTime();
            inserted.FromCurrencyCode = TestSession.Random.RandomString(6);
            inserted.ToCurrencyCode = TestSession.Random.RandomString(6);
            inserted.AverageRate = TestSession.Random.RandomDecimal();
            inserted.EndOfDayRate = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new CurrencyRateModelPrimaryKey()
            {
                CurrencyRateID = inserted.CurrencyRateID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.CurrencyRateID,selectedAfterInsert.CurrencyRateID);
            Assert.AreEqual(inserted.CurrencyRateDate,selectedAfterInsert.CurrencyRateDate);
            Assert.AreEqual(inserted.FromCurrencyCode,selectedAfterInsert.FromCurrencyCode);
            Assert.AreEqual(inserted.ToCurrencyCode,selectedAfterInsert.ToCurrencyCode);
            Assert.AreEqual(inserted.AverageRate,selectedAfterInsert.AverageRate);
            Assert.AreEqual(inserted.EndOfDayRate,selectedAfterInsert.EndOfDayRate);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.CurrencyRateDate = TestSession.Random.RandomDateTime();
            inserted.FromCurrencyCode = TestSession.Random.RandomString(6);
            inserted.ToCurrencyCode = TestSession.Random.RandomString(6);
            inserted.AverageRate = TestSession.Random.RandomDecimal();
            inserted.EndOfDayRate = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new CurrencyRateModelPrimaryKey()
            {
                CurrencyRateID = inserted.CurrencyRateID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.CurrencyRateID, selectedAfterUpdate.CurrencyRateID);
            Assert.AreEqual(inserted.CurrencyRateDate, selectedAfterUpdate.CurrencyRateDate);
            Assert.AreEqual(inserted.FromCurrencyCode, selectedAfterUpdate.FromCurrencyCode);
            Assert.AreEqual(inserted.ToCurrencyCode, selectedAfterUpdate.ToCurrencyCode);
            Assert.AreEqual(inserted.AverageRate, selectedAfterUpdate.AverageRate);
            Assert.AreEqual(inserted.EndOfDayRate, selectedAfterUpdate.EndOfDayRate);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new CurrencyRateModelPrimaryKey()
            {
                CurrencyRateID = inserted.CurrencyRateID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}