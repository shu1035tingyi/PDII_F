// code Review (Power By Copilot):
// Strengths:
// - Simple, clear form for adding custom items.
// - Properties for retrieving user input.
// Suggestions:
// - Validate ItemName/ItemPrice before closing dialog to prevent bad input. - Pass : Validate in Form1.cs 
// - Consider using int.TryParse for price validation.                       - Pass : Validate in Form1.cs 

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
