
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
    public class ErrorLogDaoIntegrationTests
    {
        private ErrorLogDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new ErrorLogDao();
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
            ErrorLogModel inserted = new ErrorLogModel();
            inserted.ErrorTime = TestSession.Random.RandomDateTime();
            inserted.UserName = TestSession.Random.RandomString(256);
            inserted.ErrorNumber = TestSession.Random.Next();
            inserted.ErrorSeverity = TestSession.Random.Next();
            inserted.ErrorState = TestSession.Random.Next();
            inserted.ErrorProcedure = TestSession.Random.RandomString(252);
            inserted.ErrorLine = TestSession.Random.Next();
            inserted.ErrorMessage = TestSession.Random.RandomString(8000);

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new ErrorLogModelPrimaryKey()
            {
                ErrorLogID = inserted.ErrorLogID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.ErrorLogID,selectedAfterInsert.ErrorLogID);
            Assert.AreEqual(inserted.ErrorTime,selectedAfterInsert.ErrorTime);
            Assert.AreEqual(inserted.UserName,selectedAfterInsert.UserName);
            Assert.AreEqual(inserted.ErrorNumber,selectedAfterInsert.ErrorNumber);
            Assert.AreEqual(inserted.ErrorSeverity,selectedAfterInsert.ErrorSeverity);
            Assert.AreEqual(inserted.ErrorState,selectedAfterInsert.ErrorState);
            Assert.AreEqual(inserted.ErrorProcedure,selectedAfterInsert.ErrorProcedure);
            Assert.AreEqual(inserted.ErrorLine,selectedAfterInsert.ErrorLine);
            Assert.AreEqual(inserted.ErrorMessage,selectedAfterInsert.ErrorMessage);

            #endregion

            #region update and select by id test
            inserted.ErrorTime = TestSession.Random.RandomDateTime();
            inserted.UserName = TestSession.Random.RandomString(256);
            inserted.ErrorNumber = TestSession.Random.Next();
            inserted.ErrorSeverity = TestSession.Random.Next();
            inserted.ErrorState = TestSession.Random.Next();
            inserted.ErrorProcedure = TestSession.Random.RandomString(252);
            inserted.ErrorLine = TestSession.Random.Next();
            inserted.ErrorMessage = TestSession.Random.RandomString(8000);

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new ErrorLogModelPrimaryKey()
            {
                ErrorLogID = inserted.ErrorLogID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.ErrorLogID, selectedAfterUpdate.ErrorLogID);
            Assert.AreEqual(inserted.ErrorTime, selectedAfterUpdate.ErrorTime);
            Assert.AreEqual(inserted.UserName, selectedAfterUpdate.UserName);
            Assert.AreEqual(inserted.ErrorNumber, selectedAfterUpdate.ErrorNumber);
            Assert.AreEqual(inserted.ErrorSeverity, selectedAfterUpdate.ErrorSeverity);
            Assert.AreEqual(inserted.ErrorState, selectedAfterUpdate.ErrorState);
            Assert.AreEqual(inserted.ErrorProcedure, selectedAfterUpdate.ErrorProcedure);
            Assert.AreEqual(inserted.ErrorLine, selectedAfterUpdate.ErrorLine);
            Assert.AreEqual(inserted.ErrorMessage, selectedAfterUpdate.ErrorMessage);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new ErrorLogModelPrimaryKey()
            {
                ErrorLogID = inserted.ErrorLogID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}