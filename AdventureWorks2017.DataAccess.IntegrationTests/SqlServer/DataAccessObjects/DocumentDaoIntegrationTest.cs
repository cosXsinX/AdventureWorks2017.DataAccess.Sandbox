
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
    public class DocumentDaoIntegrationTests
    {
        private DocumentDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new DocumentDao();
        }

        //TODO execute when there is no indexes
        [Test]
        public void GetAllIntegrationTest()
        {
            var _connection = TestSession.GetConnection();
            _connection.Open();
            var selecteds = _tested.GetAll(_connection);
            Assert.IsNotNull(selecteds);
            _connection.Close();
        }

        [Test]
        public void IntegrationTest()
        {
            var _connection = TestSession.GetConnection();
            _connection.Open();
            #region good insertion and select by id test
            DocumentModel inserted = new DocumentModel();
            inserted.DocumentNode = Microsoft.SqlServer.Types.SqlHierarchyId.Null; //TODO define how to generate random hierarchy id in test session;
            inserted.DocumentLevel = TestSession.Random.RandomShort();
            inserted.Title = TestSession.Random.RandomString(100);
            inserted.Owner = TestSession.Random.Next();
            inserted.FolderFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.FileName = TestSession.Random.RandomString(800);
            inserted.FileExtension = TestSession.Random.RandomString(16);
            inserted.Revision = TestSession.Random.RandomString(10);
            inserted.ChangeNumber = TestSession.Random.Next();
            inserted.Status = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.DocumentSummary = TestSession.Random.RandomString(-1);
            inserted.Document = TestSession.Random.RandomBytes();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Insert(_connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(_connection, new DocumentModelPrimaryKey()
            {
                DocumentNode = inserted.DocumentNode,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.DocumentNode,selectedAfterInsert.DocumentNode);
            Assert.AreEqual(inserted.DocumentLevel,selectedAfterInsert.DocumentLevel);
            Assert.AreEqual(inserted.Title,selectedAfterInsert.Title);
            Assert.AreEqual(inserted.Owner,selectedAfterInsert.Owner);
            Assert.AreEqual(inserted.FolderFlag,selectedAfterInsert.FolderFlag);
            Assert.AreEqual(inserted.FileName,selectedAfterInsert.FileName);
            Assert.AreEqual(inserted.FileExtension,selectedAfterInsert.FileExtension);
            Assert.AreEqual(inserted.Revision,selectedAfterInsert.Revision);
            Assert.AreEqual(inserted.ChangeNumber,selectedAfterInsert.ChangeNumber);
            Assert.AreEqual(inserted.Status,selectedAfterInsert.Status);
            Assert.AreEqual(inserted.DocumentSummary,selectedAfterInsert.DocumentSummary);
            Assert.AreEqual(inserted.Document,selectedAfterInsert.Document);
            Assert.AreEqual(inserted.rowguid,selectedAfterInsert.rowguid);
            Assert.AreEqual(inserted.ModifiedDate,selectedAfterInsert.ModifiedDate);

            #endregion

            #region update and select by id test
            inserted.DocumentLevel = TestSession.Random.RandomShort();
            inserted.Title = TestSession.Random.RandomString(100);
            inserted.Owner = TestSession.Random.Next();
            inserted.FolderFlag = Convert.ToBoolean(TestSession.Random.Next(1));
            inserted.FileName = TestSession.Random.RandomString(800);
            inserted.FileExtension = TestSession.Random.RandomString(16);
            inserted.Revision = TestSession.Random.RandomString(10);
            inserted.ChangeNumber = TestSession.Random.Next();
            inserted.Status = Convert.ToByte(TestSession.Random.RandomString(1));
            inserted.DocumentSummary = TestSession.Random.RandomString(-1);
            inserted.Document = TestSession.Random.RandomBytes();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = TestSession.Random.RandomDateTime();

            _tested.Update(_connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(_connection, new DocumentModelPrimaryKey()
            {
                DocumentNode = inserted.DocumentNode,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.DocumentNode, selectedAfterUpdate.DocumentNode);
            Assert.AreEqual(inserted.DocumentLevel, selectedAfterUpdate.DocumentLevel);
            Assert.AreEqual(inserted.Title, selectedAfterUpdate.Title);
            Assert.AreEqual(inserted.Owner, selectedAfterUpdate.Owner);
            Assert.AreEqual(inserted.FolderFlag, selectedAfterUpdate.FolderFlag);
            Assert.AreEqual(inserted.FileName, selectedAfterUpdate.FileName);
            Assert.AreEqual(inserted.FileExtension, selectedAfterUpdate.FileExtension);
            Assert.AreEqual(inserted.Revision, selectedAfterUpdate.Revision);
            Assert.AreEqual(inserted.ChangeNumber, selectedAfterUpdate.ChangeNumber);
            Assert.AreEqual(inserted.Status, selectedAfterUpdate.Status);
            Assert.AreEqual(inserted.DocumentSummary, selectedAfterUpdate.DocumentSummary);
            Assert.AreEqual(inserted.Document, selectedAfterUpdate.Document);
            Assert.AreEqual(inserted.rowguid, selectedAfterUpdate.rowguid);
            Assert.AreEqual(inserted.ModifiedDate, selectedAfterUpdate.ModifiedDate);

            #endregion

            #region delete test
            _tested.Delete(_connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(_connection, new DocumentModelPrimaryKey()
            {
                DocumentNode = inserted.DocumentNode,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            _connection.Close();
        }
    }
}