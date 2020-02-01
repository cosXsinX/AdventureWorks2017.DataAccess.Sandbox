
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
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new SalesTaxRateDao();
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
            SalesTaxRateModel inserted = new SalesTaxRateModel();
            inserted.StateProvinceID = TestSession.Random.Next();
            inserted.TaxType = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.TaxRate = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new SalesTaxRateModelPrimaryKey()
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

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new SalesTaxRateModelPrimaryKey()
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
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new SalesTaxRateModelPrimaryKey()
            {
                SalesTaxRateID = inserted.SalesTaxRateID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}