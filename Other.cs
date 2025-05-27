using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDII_F
{
    public partial class Other : Form
    {
        public Other()
        {
            InitializeComponent();
        }

        public string ItemName 
        {
            get { return textBox1.Text; }
        }

        public string ItemPrice 
        {
            get { return textBox2.Text; }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
