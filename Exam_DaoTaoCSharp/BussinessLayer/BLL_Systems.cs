using Datalayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class BLL_Systems
    {
        Database database;
        public BLL_Systems(string path)
        {
            database = new Database(path);
        }
        public bool CheckConnect()
        {
            return database.CheckLogin();
        }
        public bool WriteConnectionString(ref string err, string path, SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            try
            {
                ReadConnect.WriteConnectionString(path, sqlConnectionStringBuilder);
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }

        }

        public SqlConnectionStringBuilder ReadConnectionString(ref string err, string path)
        {
            try
            {
              return  ReadConnect.ReadFileConnect(path);
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }

        }
    }
}
