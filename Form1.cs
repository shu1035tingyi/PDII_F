using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDII_F
{
    public partial class Form1 : Form
    {
        private static int _id;
        public static int ID
        {
            get { return _id; }
        }

        public static void NextID()
        {
            _id++;
        }

        public static int GetID(bool format = false)
        {
            return ID;
        }


        public bool Is_Satrted = false;
        public string Started_time = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer.Interval = 1000;
            Timer.Enabled = true;
            Button_Enable(false);
            PanelObj_Enable(false);
            label1.Text = "";
            MainItem.Setup();
            PanelStartup();
        }

        private void button_del_all_Click(object sender, EventArgs e)
        {
            Is_Satrted = false;
            Button_Enable(Is_Satrted);
            PanelObj_Enable(Is_Satrted);
            button_start.Visible = true;
            label1.Text = "";
            Item.Clear();

        }

        //開始
        private void button_start_Click(object sender, EventArgs e)
        {
            Started_time = System.DateTime.Now.ToString();
            Is_Satrted = true;
            button_start.Visible = false;
            PanelObj_Enable(Is_Satrted);

        }

        //預覽目前項目
        private void label1_Click(object sender, EventArgs e)
        {
            show();
            if (label1.Text != "")
            {
                OverView ov = new OverView();
                ov.LabelViewText = label1.Text;
                ov.ShowDialog();
                ov.Dispose();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Label_info.Text = "Version : 0.0.2a\n" + System.DateTime.Now.ToString();
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
                    Item.AddItem(other.ItemName+" -自訂項目", p);
                }
                else MessageBox.Show($"輸入參數: \"{other.ItemPrice}\" 無效!\n{success}");
            }
            other.Dispose();//釋放資源

            show();
        }
        private void button_del_last_Click(object sender, EventArgs e)
        {
            if (Item.GetCount() == 1)
            {
                button_del_last.Enabled = false;
            }
            Item.DelLastItem();
            show();
        }
        private void button_print_Click(object sender, EventArgs e)
        {

            //這裡假設已連接明細印表機
            //
            // 使用 label1.Text 即可傳出
            //

            button_del_all_Click(sender,e);
            Form1.NextID();
            MessageBox.Show("訂單完成");
            
        }


        public void Button_Enable(bool key)
        {
            button_reset.Enabled = key;
            button_print.Enabled = key;
            button_del_last.Enabled = key;
        }
        public void PanelObj_Enable(bool key)
        {
            button3.Enabled = key;
            button4.Enabled = key;
            button5.Enabled = key;
            button6.Enabled = key;
            button7.Enabled = key;
            button8.Enabled = key;
            button9.Enabled = key;
            button10.Enabled = key;
            button11.Enabled = key;
            button12.Enabled = key;
            button13.Enabled = key;
            btn_other.Enabled = key;
        }
        public void PanelStartup()
        {
            int i = 0;
            foreach (Control control in PanelObject.Controls)
            {
                if (control is Button button & control.Text != "其他(自訂輸入)")
                {
                    control.Text = MainItem.GetByIndex(i).Name;
                    i++;
                }
                if (i == MainItem.GetCount()) break;
            }
        }
        public void show()
        {
            label1.Text = Item.ShowItems(Started_time);
            if (label1.Text != "")
            {
                Button_Enable(true);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/shu1035tingyi/PDII_F");
        }

    }   
}
