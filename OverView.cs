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
            set { label1.Text = value; }
        }
        public OverView()
        {
            InitializeComponent();
        }

        private void OverView_Load(object sender, EventArgs e)
        {

        }
    }
}
