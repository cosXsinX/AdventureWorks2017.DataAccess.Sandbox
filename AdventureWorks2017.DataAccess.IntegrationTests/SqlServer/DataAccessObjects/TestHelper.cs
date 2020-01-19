using Microsoft.SqlServer.Types;

namespace AdventureWorks2017.DataAccess.IntegrationTests.SqlServer.DataAccessObjects
{
    public class TestHelper
    {
        public static SqlGeography BuildRandomGeographyPoint()
        {
            var result = SqlGeography.Point(TestSession.Random.Next(0, 180) - 90, TestSession.Random.Next(0, 360) - 180, 4326);
            return result;
        }
    }
}
