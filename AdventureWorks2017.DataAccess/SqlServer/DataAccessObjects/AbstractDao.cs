using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public abstract class AbstractDao<T>
    {
        public List<T> GetAll(SqlConnection openedSqlConnection)
        {
            List<T> result = new List<T>();
            using (SqlCommand command = new SqlCommand(SelectQuery, openedSqlConnection))
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

        

        public abstract string SelectQuery {get;}

        protected abstract T ToModel(SqlDataReader dataReader);

        public abstract string InsertQuery { get; }

        public abstract void InsertionParameterMapping(SqlCommand sqlCommand, T inserted);

        public abstract void InsertionGeneratedAutoIdMapping(object id, T inserted);

        public SqlCommand ToInsertCommand(SqlConnection sqlConnection,T inserted)
        {
            SqlCommand cmd = new SqlCommand(InsertQuery, sqlConnection);
            cmd.CommandType = CommandType.Text;
            InsertionParameterMapping(cmd, inserted);
            return cmd;
        }

        public void Insert(SqlConnection sqlConnection,T[] inserteds)
        {
            var insertionCommands = inserteds.Select(inserted => Tuple.Create(ToInsertCommand(sqlConnection, inserted),inserted));
            var executedCommands = insertionCommands.Select(m => Tuple.Create(m.Item1.ExecuteScalar(),m.Item2,m.Item1)).ToList();
            executedCommands.ForEach(m => InsertionGeneratedAutoIdMapping(m.Item1, m.Item2));
            executedCommands.ForEach(m => m.Item3.DisposeAsync());
        }

        public abstract string UpdateQuery { get; }

        public abstract void UpdateParameterMapping(SqlCommand sqlCommand, T updated);

        public abstract void UpdateWhereParameterMapping(SqlCommand sqlCommand, T updated);

        public SqlCommand ToUpdateCommand(SqlConnection sqlConnection, T updated)
        {
            var cmd = new SqlCommand(UpdateQuery, sqlConnection);
            cmd.CommandType = CommandType.Text;
            UpdateParameterMapping(cmd, updated);
            UpdateWhereParameterMapping(cmd, updated);
            return cmd;
        }
        public void Update(SqlConnection sqlConnection, T[] updateds)
        {
            var updateCommands = updateds.Select(updated => Tuple.Create(ToUpdateCommand(sqlConnection, updated),updated)).ToList();
            var executedCommands = updateCommands.Select(m => Tuple.Create(m.Item2,m.Item1, m.Item1.ExecuteNonQuery())).ToList();
            executedCommands.ForEach(m => m.Item2.DisposeAsync());
        }

        public abstract string DeleteQuery { get; }
        public void Delete(SqlConnection sqlConnection, T[] deleteds)
        {
            var deleteComands = deleteds.Select(deleted => Tuple.Create(ToDeleteCommand(sqlConnection, deleted), deleted));
            var executedCommands = deleteComands.Select(m => Tuple.Create(m.Item2, m.Item1, m.Item1.ExecuteNonQuery())).ToList();
            executedCommands.ForEach(m => m.Item2.DisposeAsync());
        }

        public abstract void DeleteWhereParameterMapping(SqlCommand sqlCommand, T deleted);


        public SqlCommand ToDeleteCommand(SqlConnection sqlConnection, T deleted)
        {
            var cmd = new SqlCommand(DeleteQuery, sqlConnection);
            cmd.CommandType = CommandType.Text;
            DeleteWhereParameterMapping(cmd, deleted);
            return cmd;
        }
    }
}
