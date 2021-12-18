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
    public partial class Frm_Category_Modified : Form
    {
        public Frm_Category_Modified()
        {
            InitializeComponent();
        }
        public bool statusAdd = false;
        public Category category = new Category();
        private void Frm_Category_Modified_Load(object sender, EventArgs e)
        {
            if(statusAdd)
            {
                //Add
            }
            else
            {
                //Update

            }
        }
    }
}
