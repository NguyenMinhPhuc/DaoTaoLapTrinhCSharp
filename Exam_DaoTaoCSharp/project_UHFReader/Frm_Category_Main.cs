using BussinessLayer;
using DTO;
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
    public partial class Frm_Category_Main : Form
    {
        public Frm_Category_Main()
        {
            InitializeComponent();
        }
        string err = string.Empty;
        BLL_Category db;
        DataTable dtCategories;
        private void Frm_Category_Main_Load(object sender, EventArgs e)
        {
            db = new BLL_Category(Cls_Main.fileConnect);
            DisplayCategories("0");
            cboField.SelectedIndex = 1;
        }

        private void DisplayCategories(string catID)
        {
            dtCategories = new DataTable();
            dtCategories = db.GetCategory(ref err, catID);

            dgvCategories.DataSource = dtCategories.DefaultView;
            lblQuantity.Text =string.Format("Quantity: {0:#,###0}",dtCategories.DefaultView.Count);
            if(!string.IsNullOrEmpty(err))
            {
                lblErr.Text = err;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DisplayCategories("0");
        }

        private void txtSearching_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboField.Text))
            {
                DataView dataView = dtCategories.DefaultView;
                dataView.RowFilter = string.Empty;
                if(!string.IsNullOrEmpty(txtSearching.Text))
                {
                    if (cboField.Text.Equals("CatID"))
                    {
                        dataView.RowFilter = string.Format("{0} = {1}", cboField.Text, txtSearching.Text);
                    }
                    else
                    {
                        dataView.RowFilter = string.Format("{0} like '%{1}%'", cboField.Text, txtSearching.Text);
                    }
                    
                }
                else
                {
                    dataView.RowFilter = string.Empty;
                }
                dgvCategories.DataSource = dataView;
            }
            else
            {
                MessageBox.Show("Not select field");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Frm_Category_Modified frm_Category_Modified = new Frm_Category_Modified();
            frm_Category_Modified.statusAdd = true;
            frm_Category_Modified.ShowDialog();
        }
        Category category;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (category != null)
            {
                Frm_Category_Modified frm_Category_Modified = new Frm_Category_Modified();
                frm_Category_Modified.statusAdd = false;
                frm_Category_Modified.category = category;
                frm_Category_Modified.ShowDialog();
            }
            else
            {
                MessageBox.Show("category not value");
            }
           
        }

        private void dgvCategories_Click(object sender, EventArgs e)
        {
            if (dgvCategories.Rows.Count > 0)
            {
                category = new Category();
                category.CatID = dgvCategories.CurrentRow.Cells["colCatID"].Value.ToString();
                category.CatName = dgvCategories.CurrentRow.Cells["colCatName"].Value.ToString();
                category.CatStatus =Convert.ToBoolean( dgvCategories.CurrentRow.Cells["colCatStatus"].Value.ToString());
                category.CatDescription = dgvCategories.CurrentRow.Cells["colDesciption"].Value.ToString();
            }


        }
    }
}
