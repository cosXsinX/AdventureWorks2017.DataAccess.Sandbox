
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
    public class LocationDaoIntegrationTests
    {
        private LocationDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new LocationDao();
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
            LocationModel inserted = new LocationModel();
            inserted.Name = TestSession.Random.RandomString(50);
            inserted.CostRate = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Availability = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new LocationModelPrimaryKey()
            {
                LocationID = inserted.LocationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.LocationID,selectedAfterInsert.LocationID);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.CostRate,selectedAfterInsert.CostRate);
            Assert.AreEqual(inserted.Availability,selectedAfterInsert.Availability);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.Name = TestSession.Random.RandomString(50);
            inserted.CostRate = Convert.ToDecimal(TestSession.Random.Next());
            inserted.Availability = TestSession.Random.RandomDecimal();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new LocationModelPrimaryKey()
            {
                LocationID = inserted.LocationID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.LocationID, selectedAfterUpdate.LocationID);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.CostRate, selectedAfterUpdate.CostRate);
            Assert.AreEqual(inserted.Availability, selectedAfterUpdate.Availability);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new LocationModelPrimaryKey()
            {
                LocationID = inserted.LocationID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}