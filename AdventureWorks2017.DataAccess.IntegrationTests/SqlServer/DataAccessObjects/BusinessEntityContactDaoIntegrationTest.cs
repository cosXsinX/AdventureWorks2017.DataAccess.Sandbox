
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
    public class BusinessEntityContactDaoIntegrationTests
    {
        private BusinessEntityContactDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new BusinessEntityContactDao();
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
            BusinessEntityContactModel inserted = new BusinessEntityContactModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.PersonID = TestSession.Random.Next();
            inserted.ContactTypeID = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new BusinessEntityContactModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PersonID = inserted.PersonID,
                ContactTypeID = inserted.ContactTypeID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.PersonID,selectedAfterInsert.PersonID);
            Assert.AreEqual(inserted.ContactTypeID,selectedAfterInsert.ContactTypeID);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new BusinessEntityContactModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PersonID = inserted.PersonID,
                ContactTypeID = inserted.ContactTypeID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.PersonID, selectedAfterUpdate.PersonID);
            Assert.AreEqual(inserted.ContactTypeID, selectedAfterUpdate.ContactTypeID);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new BusinessEntityContactModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                PersonID = inserted.PersonID,
                ContactTypeID = inserted.ContactTypeID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}