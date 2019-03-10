using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Exeptions;

namespace DAL
{
    public class DBCommand
    {
        #region "Private Members"
        private SqlCommand _sqlCommand;
        private List<DbParam> _params;
        private SqlConnection _connection;
        #endregion

        public DBCommand(string connection)
        {
            SqlCommand = new SqlCommand();
            _connection = new SqlConnection();
            _connection.ConnectionString = connection;
            SqlCommand.Connection = _connection;
            _connection.Open();
            _params = new List<DbParam>();
        }
        public DBCommand(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                throw new Exception();
            }
            SqlCommand = new SqlCommand();
            _connection = connection;
            SqlCommand.Connection = _connection;
            _params = new List<DbParam>();
        }
        

        public DBCommand(SqlConnection connection, CommandType commandType, params DbParam[] parameters)
        {

            if (connection.State != ConnectionState.Open)
            {
                throw new Exception();
            }
            SqlCommand = new SqlCommand();
            _connection = connection;
            SqlCommand.Connection = _connection;
            SqlCommand.CommandType = commandType;
            _params = parameters.ToList();
        }

        public DBCommand(string connection, CommandType commandType, params DbParam[] parameters)
        {
            SqlCommand = new SqlCommand();
            _connection = new SqlConnection();
            _connection.ConnectionString = connection;
            SqlCommand.Connection = _connection;
            SqlCommand.CommandType = commandType;

            _params = parameters.ToList();
        }

        public DBCommand(string connection, params DbParam[] parameters)
        {
            SqlCommand = new SqlCommand();
            _connection = new SqlConnection();
            _connection.ConnectionString = connection;
            SqlCommand.Connection = _connection;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            _params = parameters.ToList();
        }

        public DBCommand(string connection, string commandText, params DbParam[] parameters)
        {
            SqlCommand = new SqlCommand();
            _connection = new SqlConnection();
            _connection.ConnectionString = connection;
            SqlCommand.Connection = _connection;
            SqlCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand.CommandText = commandText;

            _params = parameters.ToList();
        }

        private void PreProcessParameters()
        {
            SqlCommand.CommandType = this.CommandType;
            SqlCommand.Parameters.Clear();
            foreach (DbParam param in _params)
            {
                //TODO: USINGS HERE HELLO
                //TODO: AND ALSO SQL PARAM OH MY
                SqlParameter sqlParam = new SqlParameter(param.ParameterName, param.DbType);
                sqlParam.Direction = param.Direction;
                
                sqlParam.Scale = param.Scale;
                sqlParam.Precision = param.Precision;

                if (param.Direction != ParameterDirection.Output)
                {
                    sqlParam.Value = param.Value;
                }
                
                SqlCommand.Parameters.Add(sqlParam);
            }
        }

        private void PostProcessParameters()
        {
            List<DbParam> newParams = new List<DbParam>();

            foreach (SqlParameter p in SqlCommand.Parameters)
            {
                DbParam dbp = new DbParam(p.ParameterName, p.Value);

                dbp.DbType = p.DbType;
                dbp.Direction = p.Direction;
                dbp.Scale = p.Scale;
                dbp.Precision = p.Precision;
                newParams.Add(dbp);
            }
            _params = newParams;
        }

        public void Cancel()
        {
            SqlCommand.Cancel();
        }

        public string CommandText
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return SqlCommand.CommandText;
            }
            set
            {
                if (SqlCommand != null)
                {
                    SqlCommand.CommandText = value;
                }
            }
        }

        public int CommandTimeout
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return SqlCommand.CommandTimeout;
            }
            set
            {
                if (SqlCommand != null)
                {
                    SqlCommand.CommandTimeout = value;
                }
            }
        }

        public CommandType CommandType
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return SqlCommand.CommandType;
            }
            set
            {
                if (SqlCommand != null)
                {
                    SqlCommand.CommandType = value;
                }
            }
        }

        public SqlConnection Connection
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return SqlCommand.Connection;
            }
            set
            {
                if (SqlCommand != null)
                {
                    SqlCommand.Connection = value;
                }
            }
        }

        public IDbDataParameter CreateParameter()
        {
            return SqlCommand.CreateParameter();
        }

        public int ExecuteNonQuery()
         {
            int result;
            PreProcessParameters();
            result = SqlCommand.ExecuteNonQuery();
            _params.Clear();
            PostProcessParameters();

            return result;
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            PreProcessParameters();
            return SqlCommand.ExecuteReader(behavior);
        }

        public IDataReader ExecuteReader()
        {
            PreProcessParameters();
            return SqlCommand.ExecuteReader();
        }

        public object ExecuteScalar()
        {
            PreProcessParameters();
            return SqlCommand.ExecuteScalar();
        }

        public List<DbParam> Parameters
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return _params;
            }
        }

        public void Prepare()
        {
            SqlCommand.Prepare();
        }

        public SqlTransaction Transaction
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return SqlCommand.Transaction;
            }
            set
            {
                if (SqlCommand != null)
                {
                    SqlCommand.Transaction = value;
                }
            }
        }

        public UpdateRowSource UpdatedRowSource
        {
            get
            {
                if (SqlCommand == null)
                {
                    throw new CommandNotInstantiatedException();
                }
                return SqlCommand.UpdatedRowSource;
            }
            set
            {
                if (SqlCommand != null)
                {
                    SqlCommand.UpdatedRowSource = value;
                }
            }
        }

        public SqlCommand SqlCommand
        {
            get { return _sqlCommand; }
            set { _sqlCommand = value; }
        }


        public void Dispose()
        {
            SqlCommand.Dispose();
        }
    }
}
