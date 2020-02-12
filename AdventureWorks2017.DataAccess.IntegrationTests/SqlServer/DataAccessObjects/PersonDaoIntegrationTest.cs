
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
    public class PersonDaoIntegrationTests
    {
        private PersonDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new PersonDao();
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
            PersonModel inserted = new PersonModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.PersonType = TestSession.Random.RandomString(4);
            inserted.NameStyle = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.Title = TestSession.Random.RandomString(16);
            inserted.FirstName = TestSession.Random.RandomString(100);
            inserted.MiddleName = TestSession.Random.RandomString(100);
            inserted.LastName = TestSession.Random.RandomString(100);
            inserted.Suffix = TestSession.Random.RandomString(20);
            inserted.EmailPromotion = TestSession.Random.Next();
            inserted.AdditionalContactInfo = null; //TODO define how to generate random xml;
            inserted.Demographics = null; //TODO define how to generate random xml;
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new PersonModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.PersonType,selectedAfterInsert.PersonType);
            Assert.AreEqual(inserted.NameStyle,selectedAfterInsert.NameStyle);
            Assert.AreEqual(inserted.Title,selectedAfterInsert.Title);
            Assert.AreEqual(inserted.FirstName,selectedAfterInsert.FirstName);
            Assert.AreEqual(inserted.MiddleName,selectedAfterInsert.MiddleName);
            Assert.AreEqual(inserted.LastName,selectedAfterInsert.LastName);
            Assert.AreEqual(inserted.Suffix,selectedAfterInsert.Suffix);
            Assert.AreEqual(inserted.EmailPromotion,selectedAfterInsert.EmailPromotion);
            Assert.AreEqual(inserted.AdditionalContactInfo,selectedAfterInsert.AdditionalContactInfo);
            Assert.AreEqual(inserted.Demographics,selectedAfterInsert.Demographics);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.PersonType = TestSession.Random.RandomString(4);
            inserted.NameStyle = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.Title = TestSession.Random.RandomString(16);
            inserted.FirstName = TestSession.Random.RandomString(100);
            inserted.MiddleName = TestSession.Random.RandomString(100);
            inserted.LastName = TestSession.Random.RandomString(100);
            inserted.Suffix = TestSession.Random.RandomString(20);
            inserted.EmailPromotion = TestSession.Random.Next();
            inserted.AdditionalContactInfo = null; //TODO define how to generate random xml;
            inserted.Demographics = null; //TODO define how to generate random xml;
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new PersonModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.PersonType, selectedAfterUpdate.PersonType);
            Assert.AreEqual(inserted.NameStyle, selectedAfterUpdate.NameStyle);
            Assert.AreEqual(inserted.Title, selectedAfterUpdate.Title);
            Assert.AreEqual(inserted.FirstName, selectedAfterUpdate.FirstName);
            Assert.AreEqual(inserted.MiddleName, selectedAfterUpdate.MiddleName);
            Assert.AreEqual(inserted.LastName, selectedAfterUpdate.LastName);
            Assert.AreEqual(inserted.Suffix, selectedAfterUpdate.Suffix);
            Assert.AreEqual(inserted.EmailPromotion, selectedAfterUpdate.EmailPromotion);
            Assert.AreEqual(inserted.AdditionalContactInfo, selectedAfterUpdate.AdditionalContactInfo);
            Assert.AreEqual(inserted.Demographics, selectedAfterUpdate.Demographics);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new PersonModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}