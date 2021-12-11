using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
   public class ReadConnect
    {
      public static  SqlConnectionStringBuilder connectionStringBuilder;
        public static SqlConnectionStringBuilder ReadFileConnect(string path)
        {
            connectionStringBuilder = new SqlConnectionStringBuilder();
            using (FileStream fs=new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr=new StreamReader(fs,Encoding.UTF8)) {
                    string line = string.Empty;
                    while ((line=sr.ReadLine())!=null)
                    {
                        if(!string.IsNullOrEmpty(line))
                        {
                            switch (line.Substring(0,line.IndexOf("=")).Trim())
                            {
                                case "DataSource":
                                    connectionStringBuilder.DataSource = line.Substring(line.IndexOf("=") + 1).Trim();
                                    break;
                                case "InitialCatalog":
                                    connectionStringBuilder.InitialCatalog = line.Substring(line.IndexOf("=") + 1).Trim();
                                    break;
                                case "UserID":
                                    connectionStringBuilder.UserID = line.Substring(line.IndexOf("=") + 1).Trim();
                                    break;
                                case "Password":
                                    connectionStringBuilder.Password = line.Substring(line.IndexOf("=") + 1).Trim();
                                    break;
                                case "IntegratedSecurity":
                                    connectionStringBuilder.IntegratedSecurity =Convert.ToBoolean( line.Substring(line.IndexOf("=") + 1).Trim());
                                    break;
                               
                            }
                        }
                    }
                    return connectionStringBuilder;
                }
            }
        }
        public static void WriteConnectionString(string path, SqlConnectionStringBuilder connectionString)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(string.Format(" DataSource ={0}", connectionString.DataSource));
                    sw.WriteLine(string.Format(" InitialCatalog ={0}", connectionString.InitialCatalog));
                    sw.WriteLine(string.Format(" UserID ={0}", connectionString.UserID));
                    sw.WriteLine(string.Format(" Password ={0}", connectionString.Password));
                    sw.Write(string.Format(" IntegratedSecurity ={0}", connectionString.IntegratedSecurity.ToString()));
                }
            }
        }
    }
}
