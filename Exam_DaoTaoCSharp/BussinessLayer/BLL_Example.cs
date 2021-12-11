using Datalayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   
    public class BLL_Example
    { 
        Database database;
        public BLL_Example(string path)
        {
            database = new Database(path);
        }
        public bool CheckConnect()
        {
            return database.CheckLogin();
        }
        public DataTable GetExampleList(ref string err,string maGiaoVien)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaGiaoVien", maGiaoVien)
            };
            
            return database.MyGetDataTable(ref err, "PSP_SinhVien_LayDanhSachTheo__GiaoVienChuNhiem", CommandType.StoredProcedure, sqlParameters);
        }
    }
}
