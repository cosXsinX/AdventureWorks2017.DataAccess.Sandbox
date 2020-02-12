
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
    public class SalesTaxRateDaoIntegrationTests
    {
        private SalesTaxRateDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesTaxRateDao();
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
            SalesTaxRateModel inserted = new SalesTaxRateModel();
            inserted.StateProvinceID = TestSession.Random.Next();
            inserted.TaxType = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.TaxRate = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new SalesTaxRateModelPrimaryKey()
            {
                SalesTaxRateID = inserted.SalesTaxRateID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.SalesTaxRateID,selectedAfterInsert.SalesTaxRateID);
            Assert.AreEqual(inserted.StateProvinceID,selectedAfterInsert.StateProvinceID);
            Assert.AreEqual(inserted.TaxType,selectedAfterInsert.TaxType);
            Assert.AreEqual(inserted.TaxRate,selectedAfterInsert.TaxRate);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.StateProvinceID = TestSession.Random.Next();
            inserted.TaxType = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.TaxRate = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new SalesTaxRateModelPrimaryKey()
            {
                SalesTaxRateID = inserted.SalesTaxRateID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.SalesTaxRateID, selectedAfterUpdate.SalesTaxRateID);
            Assert.AreEqual(inserted.StateProvinceID, selectedAfterUpdate.StateProvinceID);
            Assert.AreEqual(inserted.TaxType, selectedAfterUpdate.TaxType);
            Assert.AreEqual(inserted.TaxRate, selectedAfterUpdate.TaxRate);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new SalesTaxRateModelPrimaryKey()
            {
                SalesTaxRateID = inserted.SalesTaxRateID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}