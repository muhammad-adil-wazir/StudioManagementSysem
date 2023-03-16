using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMS.Common
{
    public class DataBaseAccess
    {
        public static string DbWems = "PR_WEMS";
        public static string DBSMS = "SMSDB";
        public static DataSet ExecuteSP(string dbName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection cn = GetConnection(dbName))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = storedProcName;
                        // assign parameters passed in to the command
                        foreach (var procParameter in procParameters)
                        {
                            cmd.Parameters.Add(procParameter.Value);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ds;
        }
        public static DataSet ExecuteQuery(string dbName, string query, Dictionary<string, SqlParameter> procParameters)
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection cn = GetConnection(dbName))
                {
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        // assign parameters passed in to the command
                        foreach (var procParameter in procParameters)
                        {
                            cmd.Parameters.Add(procParameter.Value);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ds;
        }

        public static int ExecuteCommand(string dbName, string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            int rc;
            using (SqlConnection cn = GetConnection(dbName))
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    // assign parameters passed in to the command
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    rc = cmd.ExecuteNonQuery();
                }
            }
            return rc;
        }
        public static SqlConnection GetConnection(string dbName = "PR_WEMS")
        {
           
            string cnstr = ConfigurationManager.ConnectionStrings["SMSDBContext"].ConnectionString;
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }
    }
}