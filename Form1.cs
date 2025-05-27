using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDII_F
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Timer.Interval = 1000;
            Timer.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Label_info.Text = "Version : 0.0.1a\n";
            Label_info.Text += System.DateTime.Now.ToString();
        }

        
    }
}
