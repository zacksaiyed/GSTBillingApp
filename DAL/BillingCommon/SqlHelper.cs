using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BillingCommon
{
    public class SqlHelper
    {
        public static DataSet GetResultSet(string SPName, SqlParameter[] sqlParameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationConstant.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                connection.Open();
                cmd = new SqlCommand(SPName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters);
                }

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }

        }

        public static int ExecuteSp(string SPName, SqlParameter[] sqlParameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationConstant.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand(SPName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameters != null)
                {
                    cmd.Parameters.AddRange(sqlParameters);
                }


                return cmd.ExecuteNonQuery();
            }

        }
    }
}
