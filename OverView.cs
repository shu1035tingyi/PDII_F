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
        public string LabelViewText
        {
            get { return label1.Text; } // 也可以提供 get，但這裡主要用於設定
            set { label1.Text = value; } // 將傳入的值設定給 labelView.Text
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
