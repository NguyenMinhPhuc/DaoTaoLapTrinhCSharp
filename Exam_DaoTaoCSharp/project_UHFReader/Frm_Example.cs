using BussinessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_UHFReader
{
    public partial class Frm_Example : Form
    {
        public Frm_Example()
        {
            InitializeComponent();
        }
        BLL_Example db;
        private void Frm_Example_Load(object sender, EventArgs e)
        {
            db = new BLL_Example(Cls_Main.fileConnect);
            dbChucVu = new BLL_ChucVu(Cls_Main.fileConnect);
            if (db.CheckConnect())
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("No OK");
            }
        }
        DataTable dtData;
        string err = string.Empty;
        private void btnGetData_Click(object sender, EventArgs e)
        {
            dtData = db.GetExampleList(ref err, "NV0000309");

            dataGridView1.DataSource = dtData;
        }
        BLL_ChucVu dbChucVu;
        ChucVu chucVu;
        private void button1_Click(object sender, EventArgs e)
        {
            chucVu = new ChucVu()
            {
                MaChucVu = "1",TenChucVu="Lop truong",IsDelete=false
            };
            dbChucVu.InsertUpdateChucVu(ref err, chucVu);
        }
    }
}
