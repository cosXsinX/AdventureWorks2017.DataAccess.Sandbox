
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
    public class EmployeePayHistoryDaoIntegrationTests
    {
        private EmployeePayHistoryDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new EmployeePayHistoryDao();
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
            EmployeePayHistoryModel inserted = new EmployeePayHistoryModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.RateChangeDate = TestSession.Random.RandomDateTime();
            inserted.Rate = TestSession.Random.RandomDecimal(19, 4);
            inserted.PayFrequency = Convert.ToByte(TestSession.Random.Next(255));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new EmployeePayHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                RateChangeDate = inserted.RateChangeDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.RateChangeDate,selectedAfterInsert.RateChangeDate);
            Assert.AreEqual(inserted.Rate,selectedAfterInsert.Rate);
            Assert.AreEqual(inserted.PayFrequency,selectedAfterInsert.PayFrequency);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Rate = TestSession.Random.RandomDecimal(19,4);
            inserted.PayFrequency = Convert.ToByte(TestSession.Random.Next(255));
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new EmployeePayHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                RateChangeDate = inserted.RateChangeDate,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.RateChangeDate, selectedAfterUpdate.RateChangeDate);
            Assert.AreEqual(inserted.Rate, selectedAfterUpdate.Rate);
            Assert.AreEqual(inserted.PayFrequency, selectedAfterUpdate.PayFrequency);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new EmployeePayHistoryModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
                RateChangeDate = inserted.RateChangeDate,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}