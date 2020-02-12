
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
    public class PersonPhoneDaoIntegrationTests
    {
        private PersonPhoneDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new PersonPhoneDao();
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
            PersonPhoneModel inserted = new PersonPhoneModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.PhoneNumber = TestSession.Random.RandomString(25);
            inserted.PhoneNumberTypeID = TestSession.Random.Next();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new PersonPhoneModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PhoneNumber = inserted.PhoneNumber,
                PhoneNumberTypeID = inserted.PhoneNumberTypeID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.PhoneNumber,selectedAfterInsert.PhoneNumber);
            Assert.AreEqual(inserted.PhoneNumberTypeID,selectedAfterInsert.PhoneNumberTypeID);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new PersonPhoneModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PhoneNumber = inserted.PhoneNumber,
                PhoneNumberTypeID = inserted.PhoneNumberTypeID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.PhoneNumber, selectedAfterUpdate.PhoneNumber);
            Assert.AreEqual(inserted.PhoneNumberTypeID, selectedAfterUpdate.PhoneNumberTypeID);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new PersonPhoneModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PhoneNumber = inserted.PhoneNumber,
                PhoneNumberTypeID = inserted.PhoneNumberTypeID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}