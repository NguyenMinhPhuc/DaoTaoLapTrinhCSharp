using project_UHFReader.HeThong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_UHFReader
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Frm_Login frm_Login = new Frm_Login();
            frm_Login.ShowDialog();

            lblThongTinUser.Text = Cls_Main.UserName;

        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Có chắc chắn tắt chương trình \n Chọn OK để tắt, ngược lại chọn Cancel","Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            Frm_Login frm_Login = new Frm_Login();
            frm_Login.ShowDialog();

            lblThongTinUser.Text = Cls_Main.UserName;
        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            FrmBacku_Restore frmBacku_Restore = new FrmBacku_Restore();
            frmBacku_Restore.MdiParent = this;
            frmBacku_Restore.Show();
        }

        private void mnuChangpassword_Click(object sender, EventArgs e)
        {
            Frm_ChangedPassword frm_ChangedPassword = new Frm_ChangedPassword();
            frm_ChangedPassword.ShowDialog();
        }

        private void frmExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Example frm_Example = new Frm_Example();
            frm_Example.ShowDialog();
        }

        private void fromConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Connection frm_Connection = new Frm_Connection();
            frm_Connection.ShowDialog();
        }

        private void mnuCategoryList_Click(object sender, EventArgs e)
        {
            Frm_Category_Main frm_Category_Main = new Frm_Category_Main();
            frm_Category_Main.MdiParent = this;
            frm_Category_Main.Dock = DockStyle.Fill;
            frm_Category_Main.Show();
        }
    }
}
