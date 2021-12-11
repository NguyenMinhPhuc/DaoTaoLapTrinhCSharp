using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class Database
    {
        //Kết nối
        SqlConnection sqlConnection;
        //Thực thi thủ tục sql
        //1. ExcuteNonQuery (insert, update, delete)
        //2. ExcuteReader(select)
        //3. ExcuteScalar (select <-- 1 gia tri)
        //4. ExcuteXMLReader (xml<--Select)
        SqlCommand sqlCommand;
        //thuc thi thu tuc tra ve dataset or dataTable
        SqlDataAdapter dataAdapter;

        public Database(string path)
        {
            sqlConnection = new SqlConnection();
            //login by Windows Authentication
            // sqlConnection.ConnectionString = @"Server=MINHPHUC\SQLEXPRESS;database=Data_QuanLyLopHoc;Integrated Security=true;";
            //login by Sql server Authentication
            sqlConnection.ConnectionString = ReadConnect.ReadFileConnect(path).ConnectionString;
        }

        public bool CheckLogin()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Thuc thi doi tuong SqlCommand: insert, update, delete trong SQL
        /// <summary>
        /// Phương thức thực thi đối tượng SqlCommand với phương thức ExecuteNonQuery
        /// Chuyen dung khi thuc hien Insert, update, delete
        /// </summary>
        /// <param name="err"></param>
        /// <param name="commandText">Ten Thu tuc (Store procedure) hoac cau lenh Sql</param>
        /// <param name="commandType">Kieu cuar command text</param>
        /// <param name="sqlParameters">danh sachs tham so co dung null neu khong co tham so</param>
        /// <returns></returns>
        public int MyExecuteNonQuery(ref string err,string commandText,CommandType commandType,params SqlParameter[] sqlParameters)
        {
            int rows = 0;
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
                sqlConnection.Open();
                //select * from Laptop --> CommandType=Text
                //PSP_Latop_Select --> CommandType=Store Procedure
                //Khoi taoj sqlCommand
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandTimeout = 6000;

                //Truyen tham so cho thu tuc
                if (sqlParameters != null)
                {
                    foreach (SqlParameter item in sqlParameters)
                    {
                        sqlCommand.Parameters.Add(item);
                    }
                    
                }
                rows= sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
            return rows;

        }
        public object MyExecuteScalar(ref string err, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            object rows = null;
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
                sqlConnection.Open();
                //select * from Laptop --> CommandType=Text
                //PSP_Latop_Select --> CommandType=Store Procedure
                //Khoi taoj sqlCommand
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandTimeout = 6000;

                //Truyen tham so cho thu tuc
                if (sqlParameters != null)
                {
                    foreach (SqlParameter item in sqlParameters)
                    {
                        sqlCommand.Parameters.Add(item);
                    }

                }
                rows = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
            return rows;

        }

        public SqlDataReader MySqlDataReader(ref string err, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            SqlDataReader result = null;
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
                sqlConnection.Open();
                //select * from Laptop --> CommandType=Text
                //PSP_Latop_Select --> CommandType=Store Procedure
                //Khoi taoj sqlCommand
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandTimeout = 6000;

                //Truyen tham so cho thu tuc
                if (sqlParameters != null)
                {
                    foreach (SqlParameter item in sqlParameters)
                    {
                        sqlCommand.Parameters.Add(item);
                    }

                }
                result = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            //Khong duoc dong ket noi khi su dungj SqlDataReader

            //finally
            //{
            //    sqlConnection.Close();
            //}
            return result;

        }

        public DataTable MyGetDataTable(ref string err, string commandText, CommandType commandType, params SqlParameter[] sqlParameters)
        {
            DataTable result = null;
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
                sqlConnection.Open();
                //select * from Laptop --> CommandType=Text
                //PSP_Latop_Select --> CommandType=Store Procedure
                //Khoi taoj sqlCommand
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = commandText;
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandTimeout = 6000;

                //Truyen tham so cho thu tuc
                if (sqlParameters != null)
                {
                    foreach (SqlParameter item in sqlParameters)
                    {
                        sqlCommand.Parameters.Add(item);
                    }

                }
                result = new DataTable();
                dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(result);
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;

        }
    }
}
