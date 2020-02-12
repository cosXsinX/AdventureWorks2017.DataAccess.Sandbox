
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
    public class StateProvinceDaoIntegrationTests
    {
        private StateProvinceDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new StateProvinceDao();
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
            StateProvinceModel inserted = new StateProvinceModel();
            inserted.StateProvinceCode = TestSession.Random.RandomString(3);
            inserted.CountryRegionCode = TestSession.Random.RandomString(3);
            inserted.IsOnlyStateProvinceFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.Name = TestSession.Random.RandomString(50);
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new StateProvinceModelPrimaryKey()
            {
                StateProvinceID = inserted.StateProvinceID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.StateProvinceID,selectedAfterInsert.StateProvinceID);
            Assert.AreEqual(inserted.StateProvinceCode,selectedAfterInsert.StateProvinceCode);
            Assert.AreEqual(inserted.CountryRegionCode,selectedAfterInsert.CountryRegionCode);
            Assert.AreEqual(inserted.IsOnlyStateProvinceFlag,selectedAfterInsert.IsOnlyStateProvinceFlag);
            Assert.AreEqual(inserted.Name,selectedAfterInsert.Name);
            Assert.AreEqual(inserted.TerritoryID,selectedAfterInsert.TerritoryID);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.StateProvinceCode = TestSession.Random.RandomString(3);
            inserted.CountryRegionCode = TestSession.Random.RandomString(3);
            inserted.IsOnlyStateProvinceFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.Name = TestSession.Random.RandomString(50);
            inserted.TerritoryID = TestSession.Random.Next();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new StateProvinceModelPrimaryKey()
            {
                StateProvinceID = inserted.StateProvinceID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.StateProvinceID, selectedAfterUpdate.StateProvinceID);
            Assert.AreEqual(inserted.StateProvinceCode, selectedAfterUpdate.StateProvinceCode);
            Assert.AreEqual(inserted.CountryRegionCode, selectedAfterUpdate.CountryRegionCode);
            Assert.AreEqual(inserted.IsOnlyStateProvinceFlag, selectedAfterUpdate.IsOnlyStateProvinceFlag);
            Assert.AreEqual(inserted.Name, selectedAfterUpdate.Name);
            Assert.AreEqual(inserted.TerritoryID, selectedAfterUpdate.TerritoryID);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new StateProvinceModelPrimaryKey()
            {
                StateProvinceID = inserted.StateProvinceID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}