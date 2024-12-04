using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DBUtility
{
    /// <summary>
    /// SQL Server数据库访问类
    /// </summary>
    public class SqlHelper
    {
     
       

        public readonly string _dbConnectionString;
        public SqlHelper()
        {
            _dbConnectionString = ConfigurationManager.ConnectionStrings["dbconnetion"].ToString();
        }
        //Hashtable to store cached parameters
        private  Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 执行增删改【常用】
        /// </summary>
        public  int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, paras);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();          //清空参数
                return val;
            }
        }
        /// <summary>
        /// 执行多条sql语句（List泛型集合）【事务】（无参数）
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="listSql">包含多条sql语句的泛型集合</param>
        /// <returns>受影响行数</returns>
        public  int ExecuteNonQuery(string connectionString, List<string> listSql)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            PrepareCommand(cmd, conn, trans, CommandType.Text, null, null);
            try
            {
                int count = 0;
                for (int n = 0; n < listSql.Count; n++)
                {
                    string strSql = listSql[n];
                    if (strSql.Trim().Length > 1)
                    {
                        cmd.CommandText = strSql;
                        count += cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                cmd.Parameters.Clear();
                return count;
            }
            catch
            {
                trans.Rollback();
                cmd.Parameters.Clear();
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行多条sql语句（Hashtable）【事务】（带一组参数，一个参数也得封装成组)
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="sqlStringList">Hashtable表，键值对形式</param>
        public  void ExecuteNonQuery(string connectionString, Hashtable sqlStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry item in sqlStringList)
                        {
                            string cmdText = item.Key.ToString();   //要执行的sql语句
                            SqlParameter[] cmdParas = (SqlParameter[])item.Value;  //sql语句对应的参数
                            PrepareCommand(cmd, conn, trans, CommandType.Text, cmdText, cmdParas);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        if (sqlStringList.Count > 0)
                            trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// 返回DataReader对象
        /// </summary>
        public  SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string cmdText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, commandType, cmdText, paras);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 返回第一行第一列信息（可能是字符串 所以返回类型是object）【常用】
        /// </summary>
        public  object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, commandType, commandText, paras);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }



        /// <summary>
        /// 返回DataTable
        /// </summary>
        public  DataTable GetDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, commandType, commandText, paras);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        /// <summary>
        /// 准备一个待执行的SqlCommand
        /// </summary>
        private  void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType commandType, string commandText, params SqlParameter[] paras)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }
                cmd.Connection = conn;
                if (commandText != null)
                    cmd.CommandText = commandText;
                cmd.CommandType = commandType;     //这里设置执行的是T-Sql语句还是存储过程

                if (trans != null)
                    cmd.Transaction = trans;

                if (paras != null && paras.Length > 0)
                {
                    //cmd.Parameters.AddRange(paras);
                    for (int i = 0; i < paras.Length; i++)
                    {
                        if (paras[i].Value == null || paras[i].Value.ToString() == "")
                            paras[i].Value = DBNull.Value;   //插入或修改时，如果有参数是空字符串，那么以NULL的形式插入数据库
                        cmd.Parameters.Add(paras[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
 
        // 执行非查询存储过程（如插入、更新、删除）
        public int ExecuteNonQueryProc(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // 执行查询存储过程，返回DataTable
        public DataTable ExecuteDataTable(string connectionString, string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        // 执行查询存储过程，返回List<T>（泛型方法，需要指定返回类型）
        public List<T> ExecuteList<T>(string connectionString,string storedProcedureName, Func<IDataReader, T> map, params SqlParameter[] parameters) where T : new()
        {
            List<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = map(reader);
                            list.Add(item);
                        }
                    }
                }
            }

            return list;
        }
    }
}
