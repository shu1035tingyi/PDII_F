// code Review (Power By Copilot):
// Strengths:
// - Clear property for setting label text for display.
// Suggestions:
// - OverView_Load is empty; remove if not needed.                                          - Pass : It not that Easy to remove it.
// - LabelViewText property is public; if only meant for certain uses, restrict accordingly.- Done

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
    public partial class OverView : Form
    {
        //對 OverView 添加 LabelViewText 屬性，以便於資料傳入
        public string LabelViewText
        {
            get { return label1.Text; } 
            internal set { label1.Text = value; }
        }
        public OverView()
        {
            InitializeComponent();
        }

        private void OverView_Load(object sender, EventArgs e) { }
    }
}
