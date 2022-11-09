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
    public partial class Form2 : Form
    {
        Form1 mainform;
        public Form2(Form parent)
        {
            InitializeComponent();
            mainform = (Form1)parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            mainform.textBox1.Text = this.textBox1.Text;
        }
    }
}
