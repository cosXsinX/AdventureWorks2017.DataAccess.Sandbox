
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
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new PersonPhoneDao();
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
            PersonPhoneModel inserted = new PersonPhoneModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.PhoneNumber = TestSession.Random.RandomString(50);
            inserted.PhoneNumberTypeID = TestSession.Random.Next();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new PersonPhoneModelPrimaryKey()
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

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new PersonPhoneModelPrimaryKey()
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
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new PersonPhoneModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PhoneNumber = inserted.PhoneNumber,
                PhoneNumberTypeID = inserted.PhoneNumberTypeID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
        }
    }
}