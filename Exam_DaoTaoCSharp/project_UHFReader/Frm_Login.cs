using BussinessLayer;
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
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        BLL_Systems db;
        private void Frm_Login_Load(object sender, EventArgs e)
        {
            db = new BLL_Systems(Cls_Main.fileConnect);
            if(db.CheckConnect()==false)
            {
                Frm_Connection frm_Connection = new Frm_Connection();
                frm_Connection.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
         }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (CheckLogin(txtUsername.Text, txtPassword.Text))
                    {
                        Cls_Main.UserName = txtUsername.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("UserName or password wrong");
                    }
                }
                else
                {
                    MessageBox.Show("Chua nhap password", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtUsername.SelectAll();
                    txtPassword.Focus();
                }

            }
            else
            {
                MessageBox.Show("Chua nhap user name", "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtUsername.SelectAll();
                txtUsername.Focus();
            }
        }

        private bool CheckLogin(string userName, string passWord)
        {

            if (userName.Equals("admin") && passWord.Equals("admin"))
            {
                return true;
            }

            return false;
        }
    }
}
