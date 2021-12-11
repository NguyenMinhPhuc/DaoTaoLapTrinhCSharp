using Datalayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
   public class BLL_ChucVu
    {
        Database database;
        public BLL_ChucVu(string path)
        {
            database = new Database(path);
        }

        public int InsertUpdateChucVu(ref string err,ChucVu chucVu)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@MaChucVu", chucVu.MaChucVu),
                 new SqlParameter("@TenChucVu", chucVu.TenChucVu),
                  new SqlParameter("@IsDelete", chucVu.IsDelete)
           };

            return database.MyExecuteNonQuery(ref err, "PSP_ChucVu_InsertAndUpdate", CommandType.StoredProcedure, sqlParameters);

        }
    }
}
