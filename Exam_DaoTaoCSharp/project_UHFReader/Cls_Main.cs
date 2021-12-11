using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_UHFReader
{
    // private, protected, internal, public

    public class Cls_Main
    {
        public static string UserName=string.Empty;
        public static string fileConnect = string.Format(@"{0}\connect.ini", Application.StartupPath);
    }
}
