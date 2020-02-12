
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
    public class VendorDaoIntegrationTests
    {
        private VendorDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new VendorDao();
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
            VendorModel inserted = new VendorModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.AccountNumber = TestSession.Random.RandomString(30);
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.CreditRating = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.PreferredVendorStatus = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.ActiveFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.PurchasingWebServiceURL = TestSession.Random.RandomString(2048);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new VendorModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.AccountNumber,selectedAfterInsert.AccountNumber);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.CreditRating,selectedAfterInsert.CreditRating);
            Assert.AreEqual(inserted.PreferredVendorStatus,selectedAfterInsert.PreferredVendorStatus);
            Assert.AreEqual(inserted.ActiveFlag,selectedAfterInsert.ActiveFlag);
            Assert.AreEqual(inserted.PurchasingWebServiceURL,selectedAfterInsert.PurchasingWebServiceURL);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.AccountNumber = TestSession.Random.RandomString(30);
            inserted.Name = TestSession.Random.RandomString(100);
            inserted.CreditRating = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.PreferredVendorStatus = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.ActiveFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.PurchasingWebServiceURL = TestSession.Random.RandomString(2048);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new VendorModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.AccountNumber, selectedAfterUpdate.AccountNumber);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.CreditRating, selectedAfterUpdate.CreditRating);
            Assert.AreEqual(inserted.PreferredVendorStatus, selectedAfterUpdate.PreferredVendorStatus);
            Assert.AreEqual(inserted.ActiveFlag, selectedAfterUpdate.ActiveFlag);
            Assert.AreEqual(inserted.PurchasingWebServiceURL, selectedAfterUpdate.PurchasingWebServiceURL);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new VendorModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}