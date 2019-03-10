using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Exeptions;

namespace DAL
{
    //TODO: NEED PARAM ARRAY DBParams
    //
    public class DbParam : IDbDataParameter
    {

        //public static void UseParams(params int[] list)
        //{
        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        Console.Write(list[i] + " ");
        //    }
        //    Console.WriteLine();
        //}
        


        #region "Private Members"

        private SqlParameter _sqlParameter;
        
        #endregion

        public DbParam(string parameterName, object value)
        {
            _sqlParameter = new SqlParameter();
            if (_sqlParameter != null)
            {
                _sqlParameter.ParameterName = parameterName;
                _sqlParameter.Value = value;
            }
        }

        public DbParam(string parameterName, object value, DbType dbType)
        {
            _sqlParameter = new SqlParameter();
            if (_sqlParameter != null)
            {
                _sqlParameter.ParameterName = parameterName;
                _sqlParameter.Value = value;
                _sqlParameter.DbType = dbType;
            }
        }

        public DbParam(string parameterName, ParameterDirection parameterDirection)
        {
            _sqlParameter = new SqlParameter();
            if (_sqlParameter != null)
            {
                _sqlParameter.ParameterName = parameterName;
                _sqlParameter.Direction = parameterDirection;
            }
        }
        public DbParam(string parameterName, DbType dbType, ParameterDirection parameterDirection)
        {
            _sqlParameter = new SqlParameter();
            if (_sqlParameter != null)
            {
                _sqlParameter.ParameterName = parameterName;
                _sqlParameter.DbType = dbType;
                _sqlParameter.Direction = parameterDirection;
            }
        }


        public DbParam(string parameterName, object value, DbType dbType, ParameterDirection parameterDirection)
        {
            _sqlParameter = new SqlParameter();
            if (_sqlParameter != null)
            {
                _sqlParameter.ParameterName = parameterName;
                _sqlParameter.Value = value;
                _sqlParameter.DbType = dbType;
                _sqlParameter.Direction = parameterDirection;
            }
        }


        public DbParam(string parameterName, object value, ParameterDirection parameterDirection)
        {
            _sqlParameter = new SqlParameter();
            if (_sqlParameter != null)
            {
                _sqlParameter.ParameterName = parameterName;
                _sqlParameter.Value = value;
                _sqlParameter.Direction = parameterDirection;
            }
        }

        public DbType DbType
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.DbType;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.DbType = value;
                }
            }
        }

        public ParameterDirection Direction
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.Direction;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.Direction = value;
                }
            }
        }

        public bool IsNullable
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.IsNullable;
            }
        }

        public string ParameterName
        {
            get
            {
                if (_sqlParameter == null)
                {
                    return "";
                }
                return _sqlParameter.ParameterName;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.ParameterName = value;
                }
            }
        }

        public string SourceColumn
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.SourceColumn;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.SourceColumn = value;
                }
            }
        }

        public DataRowVersion SourceVersion
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.SourceVersion;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.SourceVersion = value;
                }
            }
        }

        public object Value
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.Value;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.Value = value;
                }
            }
        }


        public byte Precision
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.Precision;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.Precision = value;
                }
            }
        }

        public byte Scale
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.Scale;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.Scale = value;
                }
            }
        }

        public int Size
        {
            get
            {
                if (_sqlParameter == null)
                {
                    throw new NotInstantiatedException();
                }
                return _sqlParameter.Size;
            }
            set
            {
                if (_sqlParameter != null)
                {
                    _sqlParameter.Size = value;
                }
            }
        }

        public void Dispose()
        {
            _sqlParameter = null;
        }



        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
