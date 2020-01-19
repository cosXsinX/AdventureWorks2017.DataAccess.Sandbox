using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdventureWorks2017.DataAccess.IntegrationTests
{

    [SetUpFixture]
    public class TestSession : IDisposable
    {
        public string ConnectionString = "Data Source=DESKTOP-JNFJSV9\\SQLEXPRESS01;Initial Catalog=AdventureWorks2017;Integrated Security=True;";


        public static SqlConnection SqlConnection { get; private set; }
        public static SessionRandom Random { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Random = new SessionRandom();

            SqlConnection = new SqlConnection(ConnectionString);
            SqlConnection.Open();
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        public void Dispose()
        {
            if (SqlConnection != null && SqlConnection.State != System.Data.ConnectionState.Closed) SqlConnection.Close();
        }

        public class SessionRandom : Random
        {
            public string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                return new string(Enumerable.Repeat(chars, length).Select(s => s[Next(s.Length)]).ToArray());
            }
        }
    }
}
