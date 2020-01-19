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

        private SqlGeographyBuilder _sqlGeographyBuilder;

        [OneTimeSetUp]
        public void Setup()
        {
            _tested = new AddressDao();
            _connection = TestSession.SqlConnection;
            _sqlGeographyBuilder = new SqlGeographyBuilder();
        }

        [Test]
        public void IntegrationTest()
        {
            AddressModel inserted = new AddressModel();
            inserted.AddressID = TestSession.Random.Next();
            inserted.AddressLine1 = TestSession.Random.RandomString(200);
            inserted.AddressLine2 = TestSession.Random.RandomString(200);
            inserted.City = TestSession.Random.RandomString(200);
            inserted.StateProvinceID = TestSession.Random.Next();
            inserted.PostalCode = TestSession.Random.RandomString(200);
            inserted.SpatialLocation = BuildRandomGeographyPoint();
            inserted.rowguid = Guid.NewGuid();
            inserted.ModifiedDate = DateTime.Today;
            _tested.Insert(_connection,new[] { inserted });
        }

        private SqlGeography BuildRandomGeographyPoint()
        {
            var result =  SqlGeography.Point(TestSession.Random.Next(0, 180) - 90, TestSession.Random.Next(0, 360) - 180,4326);
            return result;
        }
    }
}