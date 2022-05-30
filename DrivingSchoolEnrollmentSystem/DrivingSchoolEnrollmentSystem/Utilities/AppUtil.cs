using System;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DrivingSchoolEnrollmentSystem.Utilities
{
    public class AppUtil
    {
        public SqlCommand CMD = null;
        DataSet DS = null;
        public SqlConnection conn = null;

        private DataTable dataTable = null;

        public readonly IConfiguration _configuration;

        public SqlConnection dbConnectionOpen(string connectionString)
        {
            conn = new SqlConnection();

            try
            {
                string connString = connectionString;
                conn = new SqlConnection(connString);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return conn;
        }

        public SqlConnection dbPrimaryConnectionOpen()
        {
            conn = new SqlConnection();

            try
            {
                string connString = _configuration.GetConnectionString("ConnectionString");

                conn = new SqlConnection(connString);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return conn;
        }

        public void dbConnectionClose()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch
            {

            }
        }

        //[START][EDIT] <H2_JTaruc || 06-08-16 || >
        //open db connection
        private SqlConnection openConnection()
        {
            conn = new SqlConnection();

            try
            {
                string connString = _configuration.GetConnectionString("ConnectionString");

                conn = new SqlConnection(connString);

                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return conn;
        }
        //[END][EDIT] <H2_JTaruc || 06-08-16 || >

        public DataSet SelectAllDataset(StringBuilder _query)
        {
            try
            {
                using (SqlCommand myCommand = new SqlCommand(_query.ToString(), openConnection()))
                {
                    myCommand.ExecuteNonQuery();
                    using (SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand))
                    {
                        using (DS = new DataSet())
                        {
                            myAdapter.Fill(DS);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            return DS;
        }

        //execute select query without parameters
        public DataTable SelectAllDatatable(StringBuilder _query)
        {
            try
            {
                using (SqlCommand myCommand = new SqlCommand(_query.ToString(), openConnection()))
                {
                    myCommand.ExecuteNonQuery();
                    using (SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            myAdapter.Fill(ds);
                            dataTable = ds.Tables[0];
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            return dataTable;
        }

        //execute select query with parameters
        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            try
            {
                using (SqlCommand myCommand = new SqlCommand(_query, openConnection()))
                {
                    myCommand.Parameters.AddRange(sqlParameter);
                    myCommand.ExecuteNonQuery();
                    using (SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            myAdapter.Fill(ds);
                            dataTable = ds.Tables[0];
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            return dataTable;
        }

        //execute insert query
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            try
            {
                using (SqlCommand myCommand = new SqlCommand(_query, openConnection()))
                {
                    myCommand.Parameters.AddRange(sqlParameter);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            return true;
        }

        //execute update query
        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            try
            {
                using (SqlCommand myCommand = new SqlCommand(_query, openConnection()))
                {
                    myCommand.Parameters.AddRange(sqlParameter);
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            return true;
        }
    }
}
