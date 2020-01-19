using AdventureWorks2017.Models;
using AdventureWorks2017.SqlServer.DataAccessObjects;
using Microsoft.SqlServer.Types;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace AdventureWorks2017.DataAccess.IntegrationTests
{
    [TestFixture]
    public class AddressDaoIntegrationTests
    {
        private AddressDao _tested;
        public SqlConnection _connection;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new AddressDao();
            _connection = TestSession.SqlConnection;
        }

        //TODO execute when there is no indexes
        [Test]
        public void GetAllIntegrationTest()
        {
            var selecteds = _tested.GetAll(_connection);
            Assert.IsNotNull(selecteds);
        }

        [Test]
        public void IntegrationTest()
        {
            AddressModel inserted = new AddressModel();
            inserted.AddressID = TestSession.Random.Next();
            inserted.AddressLine1 = TestSession.Random.RandomString(60);
            inserted.AddressLine2 = TestSession.Random.RandomString(60);
            inserted.City = TestSession.Random.RandomString(30);
            inserted.StateProvinceID = 108;
            inserted.PostalCode = TestSession.Random.RandomString(15);
            inserted.SpatialLocation = BuildRandomGeographyPoint();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = DateTime.Today;

            _tested.Insert(_connection,new[] { inserted });
            //TODO implement here by primary key select query

        }

        private SqlGeography BuildRandomGeographyPoint()
        {
            var result =  SqlGeography.Point(TestSession.Random.Next(0, 180) - 90, TestSession.Random.Next(0, 360) - 180,4326);
            return result;
        }
    }
}