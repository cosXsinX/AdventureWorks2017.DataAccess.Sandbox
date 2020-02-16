
using AdventureWorks2017.DataAccess.IntegrationTests.SqlServer.DataAccessObjects;
using AdventureWorks2017.Models;
using AdventureWorks2017.SqlServer.DataAccessObjects;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Linq;
using AdventureWorks2017.DataAccess.IntegrationTests.SqlServer.DataAccessObjects;
using System.Xml;

namespace AdventureWorks2017.DataAccess.IntegrationTests
{
    [TestFixture]
    public class DatabaseLogDaoIntegrationTests
    {
        private DatabaseLogDao _tested;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new DatabaseLogDao();
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
            DatabaseLogModel inserted = new DatabaseLogModel();
            inserted.PostTime = TestSession.Random.RandomDateTime();
            inserted.DatabaseUser = TestSession.Random.RandomString(128);
            inserted.Event = TestSession.Random.RandomString(128);
            inserted.Schema = TestSession.Random.RandomString(128);
            inserted.Object = TestSession.Random.RandomString(128);
            inserted.TSQL = TestSession.Random.RandomString(-1);
            var xml = new XmlDocument();
            xml.LoadXml(@"<EVENT_INSTANCE><EventType>CREATE_TABLE</EventType><PostTime>2017-10-27T14:33:01.373</PostTime><SPID>56</SPID><ServerName>BARBKESS24\MSSQL2017RTM</ServerName><LoginName>REDMOND\barbkess</LoginName><UserName>dbo</UserName><DatabaseName>AdventureWorks2017</DatabaseName><SchemaName>dbo</SchemaName><ObjectName>ErrorLog</ObjectName><ObjectType>TABLE</ObjectType><TSQLCommand><SetOptions ANSI_NULLS=""ON"" ANSI_NULL_DEFAULT=""ON"" ANSI_PADDING=""ON"" QUOTED_IDENTIFIER=""ON"" ENCRYPTED=""FALSE"" /><CommandText>CREATE TABLE [dbo].[ErrorLog](
    [ErrorLogID][int] IDENTITY(1, 1) NOT NULL,
    [ErrorTime][datetime] NOT NULL CONSTRAINT[DF_ErrorLog_ErrorTime] DEFAULT(GETDATE()),
    [UserName][sysname] NOT NULL,
    [ErrorNumber][int] NOT NULL,
    [ErrorSeverity][int] NULL,
    [ErrorState][int] NULL,
    [ErrorProcedure][nvarchar](126) NULL,
    [ErrorLine][int] NULL,
    [ErrorMessage][nvarchar](4000) NOT NULL
) ON[PRIMARY] </CommandText></TSQLCommand></EVENT_INSTANCE>");
            inserted.XmlEvent = xml;

            _tested.Insert(connection,new[] { inserted });

            var selectedAfterInsertion = _tested.GetByPrimaryKey(connection, new DatabaseLogModelPrimaryKey()
            {
                DatabaseLogID = inserted.DatabaseLogID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterInsertion);
            var selectedAfterInsert = selectedAfterInsertion.Single();
            Assert.AreEqual(inserted.DatabaseLogID,selectedAfterInsert.DatabaseLogID);
            Assert.AreEqual(inserted.PostTime,selectedAfterInsert.PostTime);
            Assert.AreEqual(inserted.DatabaseUser,selectedAfterInsert.DatabaseUser);
            Assert.AreEqual(inserted.Event,selectedAfterInsert.Event);
            Assert.AreEqual(inserted.Schema,selectedAfterInsert.Schema);
            Assert.AreEqual(inserted.Object,selectedAfterInsert.Object);
            Assert.AreEqual(inserted.TSQL,selectedAfterInsert.TSQL);
            Assert.AreEqual(inserted.XmlEvent.ToString(),selectedAfterInsert.XmlEvent.ToString());

            #endregion

            #region update and select by id test
            inserted.PostTime = TestSession.Random.RandomDateTime();
            inserted.DatabaseUser = TestSession.Random.RandomString(128);
            inserted.Event = TestSession.Random.RandomString(128);
            inserted.Schema = TestSession.Random.RandomString(128);
            inserted.Object = TestSession.Random.RandomString(128);
            inserted.TSQL = TestSession.Random.RandomString(-1);
            var updatedXml = new XmlDocument();
            updatedXml.LoadXml(@"<EVENT_INSTANCE><EventType>DROP_TABLE</EventType><PostTime>2017-10-27T14:33:01.373</PostTime><SPID>56</SPID><ServerName>BARBKESS24\MSSQL2017RTM</ServerName><LoginName>REDMOND\barbkess</LoginName><UserName>dbo</UserName><DatabaseName>AdventureWorks2017</DatabaseName><SchemaName>dbo</SchemaName><ObjectName>ErrorLog</ObjectName><ObjectType>TABLE</ObjectType><TSQLCommand><SetOptions ANSI_NULLS=""ON"" ANSI_NULL_DEFAULT=""ON"" ANSI_PADDING=""ON"" QUOTED_IDENTIFIER=""ON"" ENCRYPTED=""FALSE"" /><CommandText>CREATE TABLE [dbo].[ErrorLog](
    [ErrorLogID][int] IDENTITY(1, 1) NOT NULL,
    [ErrorTime][datetime] NOT NULL CONSTRAINT[DF_ErrorLog_ErrorTime] DEFAULT(GETDATE()),
    [UserName][sysname] NOT NULL,
    [ErrorNumber][int] NOT NULL,
    [ErrorSeverity][int] NULL,
    [ErrorState][int] NULL,
    [ErrorProcedure][nvarchar](126) NULL,
    [ErrorLine][int] NULL,
    [ErrorMessage][nvarchar](4000) NOT NULL
) ON[PRIMARY] </CommandText></TSQLCommand></EVENT_INSTANCE>");
            inserted.XmlEvent = updatedXml;

            _tested.Update(connection, new[] { inserted });

            var selectedAfterUpdateAddresss = _tested.GetByPrimaryKey(connection, new DatabaseLogModelPrimaryKey()
            {
                DatabaseLogID = inserted.DatabaseLogID,
            });

            CollectionAssert.IsNotEmpty(selectedAfterUpdateAddresss);
            var selectedAfterUpdate = selectedAfterUpdateAddresss.Single();
            Assert.AreEqual(inserted.DatabaseLogID, selectedAfterUpdate.DatabaseLogID);
            Assert.AreEqual(inserted.PostTime, selectedAfterUpdate.PostTime);
            Assert.AreEqual(inserted.DatabaseUser, selectedAfterUpdate.DatabaseUser);
            Assert.AreEqual(inserted.Event, selectedAfterUpdate.Event);
            Assert.AreEqual(inserted.Schema, selectedAfterUpdate.Schema);
            Assert.AreEqual(inserted.Object, selectedAfterUpdate.Object);
            Assert.AreEqual(inserted.TSQL, selectedAfterUpdate.TSQL);
            Assert.AreEqual(inserted.XmlEvent.ToString(), selectedAfterUpdate.XmlEvent.ToString());

            #endregion

            #region delete test
            _tested.Delete(connection, new[] { inserted });
            var selectedAfterDeleteAddresss = _tested.GetByPrimaryKey(connection, new DatabaseLogModelPrimaryKey()
            {
                DatabaseLogID = inserted.DatabaseLogID,
            });
            CollectionAssert.IsEmpty(selectedAfterDeleteAddresss);
            #endregion
            connection.Close();
        }
    }
}