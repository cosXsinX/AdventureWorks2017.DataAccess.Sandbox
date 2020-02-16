
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
    public class BillOfMaterialsDaoIntegrationTests
    {
        private BillOfMaterialsDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new BillOfMaterialsDao();
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
            BillOfMaterialsModel inserted = new BillOfMaterialsModel();
            inserted.ProductAssemblyID = TestSession.Random.Next();
            inserted.ComponentID = TestSession.Random.Next();
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.UnitMeasureCode = TestSession.Random.RandomString(3);
            inserted.BOMLevel = TestSession.Random.RandomShort();
            inserted.PerAssemblyQty = TestSession.Random.RandomDecimal(3,1);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new BillOfMaterialsModelPrimaryKey()
            {
                BillOfMaterialsID = inserted.BillOfMaterialsID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BillOfMaterialsID,selectedAfterInsert.BillOfMaterialsID);
            Assert.AreEqual(inserted.ProductAssemblyID,selectedAfterInsert.ProductAssemblyID);
            Assert.AreEqual(inserted.ComponentID,selectedAfterInsert.ComponentID);
            Assert.AreEqual(inserted.StartDate,selectedAfterInsert.StartDate);
            Assert.AreEqual(inserted.EndDate,selectedAfterInsert.EndDate);
            Assert.AreEqual(inserted.UnitMeasureCode,selectedAfterInsert.UnitMeasureCode);
            Assert.AreEqual(inserted.BOMLevel,selectedAfterInsert.BOMLevel);
            Assert.AreEqual(inserted.PerAssemblyQty,selectedAfterInsert.PerAssemblyQty);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.ProductAssemblyID = TestSession.Random.Next();
            inserted.ComponentID = TestSession.Random.Next();
            inserted.StartDate = TestSession.Random.RandomDateTime();
            inserted.EndDate = TestSession.Random.RandomDateTime();
            inserted.UnitMeasureCode = TestSession.Random.RandomString(3);
            inserted.BOMLevel = TestSession.Random.RandomShort();
            inserted.PerAssemblyQty = TestSession.Random.RandomDecimal(3,1);
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new BillOfMaterialsModelPrimaryKey()
            {
                BillOfMaterialsID = inserted.BillOfMaterialsID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BillOfMaterialsID, selectedAfterUpdate.BillOfMaterialsID);
            Assert.AreEqual(inserted.ProductAssemblyID, selectedAfterUpdate.ProductAssemblyID);
            Assert.AreEqual(inserted.ComponentID, selectedAfterUpdate.ComponentID);
            Assert.AreEqual(inserted.StartDate, selectedAfterUpdate.StartDate);
            Assert.AreEqual(inserted.EndDate, selectedAfterUpdate.EndDate);
            Assert.AreEqual(inserted.UnitMeasureCode, selectedAfterUpdate.UnitMeasureCode);
            Assert.AreEqual(inserted.BOMLevel, selectedAfterUpdate.BOMLevel);
            Assert.AreEqual(inserted.PerAssemblyQty, selectedAfterUpdate.PerAssemblyQty);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new BillOfMaterialsModelPrimaryKey()
            {
                BillOfMaterialsID = inserted.BillOfMaterialsID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}