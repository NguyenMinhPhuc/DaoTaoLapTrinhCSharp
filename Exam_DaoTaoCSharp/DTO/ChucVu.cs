using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChucVu
    {
        string maChucVu, tenChucVu;
        bool isDelete;
        //Dung phim Ctrl+R+E tao properties
        public string MaChucVu { get => maChucVu; set => maChucVu = value; }
        public string TenChucVu { get => tenChucVu; set => tenChucVu = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
    }
}
