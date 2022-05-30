using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchoolEnrollmentSystem.Utilities
{
    public class SQLHelper
    {
        private CommandType _commandType = CommandType.Text;
        private string _commandText = string.Empty;
        private List<Models.SqlParameter> _sqlParameters = new List<Models.SqlParameter>();
        private string _connectionString = string.Empty;

        /// <summary>
        /// Adds new parameter.
        /// </summary>
        /// <param name="ParameterName">String value of the Parameter CourseName.</param>
        /// <param name="Value">Object value of the Parameter Value.</param>
        public void AddParameter(string ParameterName, object Value)
        {
            _sqlParameters.Add(new Models.SqlParameter { ParameterName = ParameterName, ParameterValue = Value });
        }

        /// <summary>
        /// Gets or sets a value indicating how the 
        /// System.Data.SqlClient.SqlCommand.CommandText 
        /// property is to be interpreted.
        /// </summary>
        public CommandType APCommandType
        {
            get { return _commandType; }
            set { _commandType = value; }
        }

        public string ConnString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// Gets or sets the Transact-SQL statement, 
        /// table name or stored procedure to execute at the data source.
        /// </summary>
        public String APCommandText
        {
            get { return _commandText; }
            set { _commandText = value; }
        }

        /// <summary>
        /// Opens SQL Connection.
        /// </summary>
        /// <returns>Opened SQL Connection.</returns>
        public SqlConnection OpenConn()
        {
            //add function to decrypt connection string here

            AppUtil apUtil = new AppUtil();
            return apUtil.dbConnectionOpen(ConnString);
        }

        public SqlConnection OpenConnToPrimaryDB()
        {
            AppUtil apUtil = new AppUtil();
            return apUtil.dbPrimaryConnectionOpen();
        }

        /// <summary>
        /// Executes SQL Query and returns affected rows. 
        /// Set APCommandType based on the SQL Command Type needed.
        /// </summary>
        /// <param name="sqlCommand">SQL Command value.</param>
        /// <param name="sqlParameter">SQL Parameter value (not required).</param>
        /// <returns>DataTable containing result set.</returns>
        public DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection openConn = OpenConn())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {
                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlAdapter.SelectCommand = sqlCommand;
                        sqlAdapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Executes SQL Query and returns affected rows. 
        /// Set APCommandType based on the SQL Command Type needed.
        /// </summary>
        /// <param name="sqlCommand">SQL Command value.</param>
        /// <param name="sqlParameter">SQL Parameter value (not required).</param>
        /// <returns>DataSet containing result set.</returns>
        public DataSet GetDataSet()
        {
            using (SqlConnection openConn = OpenConn())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {
                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = sqlCommand;

                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            return ds;
                        }

                    }
                }
            }
        }

        public DataSet GetDataSetOnPrimaryDB()
        {
            using (SqlConnection openConn = OpenConnToPrimaryDB())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {
                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = sqlCommand;

                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            return ds;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Executes SQL Query and returns affected rows. 
        /// Set APCommandType based on the SQL Command Type needed.
        /// </summary>
        /// <param name="sqlCommand">SQL Command value.</param>
        /// <param name="sqlParameter">SQL Parameter value (not required).</param>
        /// <returns>Boolean status if the execution was done.</returns>
        public int ExecuteNonQuery()
        {
            int result = 0;

            using (SqlConnection openConn = OpenConn())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {
                    
                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;
                    result = sqlCommand.ExecuteNonQuery();
                }
            }
            
            return result;
        }

        public int ExecuteNonQueryOnPrimaryDB()
        {
            int result = 0;

            using (SqlConnection openConn = OpenConnToPrimaryDB())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {

                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;
                    result = sqlCommand.ExecuteNonQuery();
                }
            }

            return result;
        }

        /// <summary>
        /// Executes SQL Query and returns affected rows. 
        /// Set APCommandType based on the SQL Command Type needed.
        /// </summary>
        /// <param name="sqlCommand">SQL Command value.</param>
        /// <param name="sqlParameter">SQL Parameter value (not required).</param>
        /// <returns>Boolean status if the execution was done.</returns>
        public object ExecuteScalar()
        {
            object result = null;

            using (SqlConnection openConn = OpenConn())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {

                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;
                    result = sqlCommand.ExecuteScalar();
                }
            }

            return result;
        }

        public object ExecuteScalarOnPrimaryDB()
        {
            object result = null;

            using (SqlConnection openConn = OpenConnToPrimaryDB())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {

                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;
                    result = sqlCommand.ExecuteScalar();
                }
            }

            return result;
        }

        //[START][ADD] <H2_jtaruc || 05-27-16 || Added codes SQLDataReader >
        /// <summary>
        /// Executes SQL Query and returns affected rows. 
        /// Set APCommandType based on the SQL Command Type needed.
        /// </summary>
        /// <param name="sqlCommand">SQL Command value.</param>
        /// <param name="sqlParameter">SQL Parameter value (not required).</param>
        /// <returns>Boolean status if the execution was done.</returns>
        public SqlDataReader ExecuteReader()
        {
            SqlDataReader result = null;

            using (SqlConnection openConn = OpenConn())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {

                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;
                    result = sqlCommand.ExecuteReader();
                }
            }

            return result;
        }
        //[END][ADD] <H2_jtaruc || 05-27-16 || Added codes SQLDataReader >


        public List<String> GetStringList()
        {
            List<string> result = new List<string>();

            using (SqlConnection openConn = OpenConn())
            {
                using (SqlCommand sqlCommand = CreateCommand())
                {

                    sqlCommand.Connection = openConn;
                    sqlCommand.CommandTimeout = 0;

                    using (SqlDataReader DR = sqlCommand.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            result.Add(DR[0].ToString());
                        }

                    }
                }
            }

            return result;
        }
        /// <summary>
        /// Creates SQL Command with Parameters. 
        /// Set APCommandType based on the SQL Command Type needed.
        /// </summary>
        /// <param name="commandText">String containing SQL query.</param>
        /// <param name="sqlParameter">List of SqlParameters for the command.</param>
        /// <returns>Created Command.</returns>
        private SqlCommand CreateCommand()
        {
            SqlCommand sqlCommand = new SqlCommand(APCommandText);

            try
            {
                sqlCommand.CommandType = APCommandType;

                foreach (Models.SqlParameter param in _sqlParameters)
                {
                    sqlCommand.Parameters.AddWithValue(param.ParameterName, param.ParameterValue);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return sqlCommand;
        }
    }
}
