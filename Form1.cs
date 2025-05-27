using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            button_cancel.Enabled = false;
            button_print.Enabled = false;
            label1.Text = "";
        }

        //預覽目前項目
        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                MessageBox.Show(label1.Text, "預覽");
            }
            show();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Label_info.Text = "Version : 0.0.2a\n"+ System.DateTime.Now.ToString();
        }

        /// <summary>
        /// 這個部分由AI協助完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_other_Click(object sender, EventArgs e)
        {
            Other other = new Other();
            //開啟other表單，並在確定後回傳資料
            if (other.ShowDialog() == DialogResult.OK)
            {
                int p = 0;
                bool success = int.TryParse(other.ItemPrice, out p);
                if (success)
                {
                    Item.AddItem(other.ItemName, p);
                }
                else MessageBox.Show($"輸入參數: \"{other.ItemPrice}\" 無效!\n{success}");
            }
            other.Dispose();//釋放資源

            show();
        }

        public void show()
        {
            label1.Text =  Item.ShowItems();
        }
    }
}
