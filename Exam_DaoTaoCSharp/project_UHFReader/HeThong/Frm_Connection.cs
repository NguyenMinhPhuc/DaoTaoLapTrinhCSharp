using BussinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_UHFReader.HeThong
{
    public partial class Frm_Connection : Form
    {
        public Frm_Connection()
        {
            InitializeComponent();
        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAuthentication.SelectedIndex==0)
            {
                txtUserID.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserID.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void Frm_Connection_Load(object sender, EventArgs e)
        {
            cboAuthentication.SelectedIndex = 0;
            db = new BLL_Systems(Cls_Main.fileConnect);
            if(File.Exists(Cls_Main.fileConnect))
            {
                sqlConnectionStringBuilder = db.ReadConnectionString(ref err, Cls_Main.fileConnect);
                DisplayValueConnection(sqlConnectionStringBuilder);
            }
        }

        private void DisplayValueConnection(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            txtServer.Text = sqlConnectionStringBuilder.DataSource;
            txtDatabase.Text = sqlConnectionStringBuilder.InitialCatalog;
            if(sqlConnectionStringBuilder.IntegratedSecurity)
            {
                cboAuthentication.SelectedIndex = 0;

            }
            else
            {
                cboAuthentication.SelectedIndex = 1;
                txtUserID.Text = sqlConnectionStringBuilder.UserID;
                txtPassword.Text = sqlConnectionStringBuilder.Password;
            }
        }

        SqlConnectionStringBuilder sqlConnectionStringBuilder;
        BLL_Systems db;
        string err = string.Empty;
        private void btnSave_Click(object sender, EventArgs e)
        {
            GetValueFormConstrol();
            db.WriteConnectionString(ref err,Cls_Main.fileConnect, sqlConnectionStringBuilder);
        }

        private void GetValueFormConstrol()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = txtServer.Text;
            sqlConnectionStringBuilder.InitialCatalog = txtDatabase.Text;
            sqlConnectionStringBuilder.UserID = txtUserID.Text;
            sqlConnectionStringBuilder.Password = txtPassword.Text;
            sqlConnectionStringBuilder.IntegratedSecurity = cboAuthentication.SelectedIndex == 0 ? true : false;
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            db = new BLL_Systems(Cls_Main.fileConnect);
            if (db.CheckConnect())
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("No OK");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
