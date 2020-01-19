using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public abstract class AbstractDaoWithPrimaryKey<T, K> : AbstractDao<T> where K : struct
    {

        public string SelectByPrimaryQuery => string.Concat(SelectQuery, " WHERE ", ByPrimaryWhereConditionWithArgs);
        public abstract string ByPrimaryWhereConditionWithArgs { get; }
        public abstract void MapPrimaryParameters(K key,SqlCommand command);

        private SqlCommand BuildSelectSqlCommandWithParameters(K key, SqlConnection openedSqlConnection)
        {
            var command = new SqlCommand(SelectByPrimaryQuery, openedSqlConnection);
            MapPrimaryParameters(key,command);
            return command;
        }

        public List<T> GetByPrimaryKey(SqlConnection openedSqlConnection, K Key)
        {
            List<T> result = new List<T>();
            using (SqlCommand command = BuildSelectSqlCommandWithParameters(Key,openedSqlConnection))
            {
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var model = ToModel(dataReader);
                    result.Add(model);
                }
                dataReader.Close();
            }
            return result;
        }
    }
}
