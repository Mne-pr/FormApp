using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class MyDlg : Form
    {
        public MyDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult = DialogResult.OK;
            MessageBox.Show("MyDlg OK");
            this.Close();
        }

        private void MyDlg_Load(object sender, EventArgs e)
        {

        }
    }
}
