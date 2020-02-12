
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
    public class EmployeeDaoIntegrationTests
    {
        private EmployeeDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new EmployeeDao();
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
            EmployeeModel inserted = new EmployeeModel();
            inserted.BusinessEntityID = TestSession.Random.Next();
            inserted.NationalIDNumber = TestSession.Random.RandomString(15);
            inserted.LoginID = TestSession.Random.RandomString(256);
            inserted.OrganizationNode = Microsoft.SqlServer.Types.SqlHierarchyId.Null; //TODO define how to generate random hierarchy id in test session;
            inserted.OrganizationLevel = TestSession.Random.RandomShort();
            inserted.JobTitle = TestSession.Random.RandomString(50);
            inserted.BirthDate = TestSession.Random.RandomDateTime();
            inserted.MaritalStatus = TestSession.Random.RandomString(1);
            inserted.Gender = TestSession.Random.RandomString(1);
            inserted.HireDate = TestSession.Random.RandomDateTime();
            inserted.SalariedFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.VacationHours = TestSession.Random.RandomShort();
            inserted.SickLeaveHours = TestSession.Random.RandomShort();
            inserted.CurrentFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new EmployeeModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.BusinessEntityID,selectedAfterInsert.BusinessEntityID);
            Assert.AreEqual(inserted.NationalIDNumber,selectedAfterInsert.NationalIDNumber);
            Assert.AreEqual(inserted.LoginID,selectedAfterInsert.LoginID);
            Assert.AreEqual(inserted.OrganizationNode,selectedAfterInsert.OrganizationNode);
            Assert.AreEqual(inserted.OrganizationLevel,selectedAfterInsert.OrganizationLevel);
            Assert.AreEqual(inserted.JobTitle,selectedAfterInsert.JobTitle);
            Assert.AreEqual(inserted.BirthDate,selectedAfterInsert.BirthDate);
            Assert.AreEqual(inserted.MaritalStatus,selectedAfterInsert.MaritalStatus);
            Assert.AreEqual(inserted.Gender,selectedAfterInsert.Gender);
            Assert.AreEqual(inserted.HireDate,selectedAfterInsert.HireDate);
            Assert.AreEqual(inserted.SalariedFlag,selectedAfterInsert.SalariedFlag);
            Assert.AreEqual(inserted.VacationHours,selectedAfterInsert.VacationHours);
            Assert.AreEqual(inserted.SickLeaveHours,selectedAfterInsert.SickLeaveHours);
            Assert.AreEqual(inserted.CurrentFlag,selectedAfterInsert.CurrentFlag);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.NationalIDNumber = TestSession.Random.RandomString(15);
            inserted.LoginID = TestSession.Random.RandomString(256);
            inserted.OrganizationNode = Microsoft.SqlServer.Types.SqlHierarchyId.Null; //TODO define how to generate random hierarchy id in test session;
            inserted.OrganizationLevel = TestSession.Random.RandomShort();
            inserted.JobTitle = TestSession.Random.RandomString(50);
            inserted.BirthDate = TestSession.Random.RandomDateTime();
            inserted.MaritalStatus = TestSession.Random.RandomString(1);
            inserted.Gender = TestSession.Random.RandomString(1);
            inserted.HireDate = TestSession.Random.RandomDateTime();
            inserted.SalariedFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.VacationHours = TestSession.Random.RandomShort();
            inserted.SickLeaveHours = TestSession.Random.RandomShort();
            inserted.CurrentFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new EmployeeModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.BusinessEntityID, selectedAfterUpdate.BusinessEntityID);
            Assert.AreEqual(inserted.NationalIDNumber, selectedAfterUpdate.NationalIDNumber);
            Assert.AreEqual(inserted.LoginID, selectedAfterUpdate.LoginID);
            Assert.AreEqual(inserted.OrganizationNode, selectedAfterUpdate.OrganizationNode);
            Assert.AreEqual(inserted.OrganizationLevel, selectedAfterUpdate.OrganizationLevel);
            Assert.AreEqual(inserted.JobTitle, selectedAfterUpdate.JobTitle);
            Assert.AreEqual(inserted.BirthDate, selectedAfterUpdate.BirthDate);
            Assert.AreEqual(inserted.MaritalStatus, selectedAfterUpdate.MaritalStatus);
            Assert.AreEqual(inserted.Gender, selectedAfterUpdate.Gender);
            Assert.AreEqual(inserted.HireDate, selectedAfterUpdate.HireDate);
            Assert.AreEqual(inserted.SalariedFlag, selectedAfterUpdate.SalariedFlag);
            Assert.AreEqual(inserted.VacationHours, selectedAfterUpdate.VacationHours);
            Assert.AreEqual(inserted.SickLeaveHours, selectedAfterUpdate.SickLeaveHours);
            Assert.AreEqual(inserted.CurrentFlag, selectedAfterUpdate.CurrentFlag);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new EmployeeModelPrimaryKey()
            {
                BusinessEntityID = inserted.BusinessEntityID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}