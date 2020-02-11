
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
    public class CountryRegionCurrencyDaoIntegrationTests
    {
        private CountryRegionCurrencyDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new CountryRegionCurrencyDao();
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
            CountryRegionCurrencyModel inserted = new CountryRegionCurrencyModel();
            inserted.CountryRegionCode = TestSession.Random.RandomString(6);
            inserted.CurrencyCode = TestSession.Random.RandomString(6);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new CountryRegionCurrencyModelPrimaryKey()
            {
                CountryRegionCode = inserted.CountryRegionCode,
                CurrencyCode = inserted.CurrencyCode,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.CountryRegionCode,selectedAfterInsert.CountryRegionCode);
            Assert.AreEqual(inserted.CurrencyCode,selectedAfterInsert.CurrencyCode);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new CountryRegionCurrencyModelPrimaryKey()
            {
                CountryRegionCode = inserted.CountryRegionCode,
                CurrencyCode = inserted.CurrencyCode,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.CountryRegionCode, selectedAfterUpdate.CountryRegionCode);
            Assert.AreEqual(inserted.CurrencyCode, selectedAfterUpdate.CurrencyCode);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new CountryRegionCurrencyModelPrimaryKey()
            {
                CountryRegionCode = inserted.CountryRegionCode,
                CurrencyCode = inserted.CurrencyCode,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}