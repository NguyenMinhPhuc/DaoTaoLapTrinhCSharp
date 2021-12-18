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
  public  class BLL_Category
    {
        Database data;
        public BLL_Category(string path)
        {
            data = new Database(path);
        }

        public DataTable GetCategory(ref string err,string catID)
        {
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@CateID",catID)
            };
            return data.MyGetDataTable(ref err, "PSP_Category_Select", CommandType.StoredProcedure, sqlParameter);
        }
    }
}
