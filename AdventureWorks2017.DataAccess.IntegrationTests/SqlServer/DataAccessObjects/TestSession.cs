using Microsoft.SqlServer.Types;
using NUnit.Framework;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AdventureWorks2017.DataAccess.IntegrationTests
{

    [SetUpFixture]
    public class TestSession
    {
        public const string ConnectionString = "Data Source=DESKTOP-JNFJSV9\\SQLEXPRESS01;Initial Catalog=AdventureWorks2017;Integrated Security=True;";


        public static SessionRandom Random { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Random = new SessionRandom();
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        public static SqlConnection GetConnection()
        {
            var SqlConnection = new SqlConnection(ConnectionString);
            return SqlConnection;
        }

        public class SessionRandom : Random
        {
            public short RandomShort()
            {
                return Convert.ToInt16(Next(short.MinValue +1,short.MaxValue - 1));
            }
        
            public string RandomString(int length)
            {
                if(length <= 0)
                {
                    length = 10; //When length is not defined => silent management => bad !!!
                }
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                return new string(Enumerable.Repeat(chars, length).Select(s => s[Next(s.Length)]).ToArray());
            }

            public byte[] RandomBytes()
            {
                byte[] generated = new byte[10];
                NextBytes(generated);
                return generated;
            }

            public byte RandomByte()
            {
                byte[] generated = new byte[1];
                NextBytes(generated);
                return generated[0];
            }

            private int NextInt32()
            {
                unchecked
                {
                    int firstBits = Next(0, 1 << 4) << 28;
                    int lastBits = Next(0, 1 << 28);
                    return firstBits | lastBits;
                }
            }


            public decimal RandomDecimal()
            {
                byte scale = (byte)Next(29);
                bool sign = Next(2) == 1;
                return new decimal(NextInt32(),
                                   NextInt32(),
                                   NextInt32(),
                                   sign,
                                   scale);
            }

            public DateTime RandomDateTime()
            {
                var generated = DateTime.Today
                    .AddDays(Next(20))
                    .AddDays(-Next(20))
                    .AddHours(Next(20))
                    .AddSeconds(Next(10000000));
                return generated;
            }

            public SqlGeography RandomSqlGeography()
            {
                return SqlGeography.Point(Random.Next(10), Random.Next(10), 4326);
            }

            public TimeSpan RandomTimeSpan()
            {
                return new TimeSpan(0, 0, 0, TestSession.Random.Next(86400));
            }

            public DateTimeOffset RandomDateTimeOffset()
            {
                return DateTimeOffset.Now.AddDays(Next(200));
            }
            
        }
    }
}
