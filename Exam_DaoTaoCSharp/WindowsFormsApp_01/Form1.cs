using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary_01;

namespace WindowsFormsApp_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyNumber myNumber = new MyNumber();
            int a = Convert.ToInt32(txtNumber01.Text);
            int b = int.Parse(txtNumber02.Text);
            txtResult.Text = myNumber.Cong(a, b).ToString();
            MessageBox.Show(myNumber.Cong(a, b).ToString());
        }
    }
}
