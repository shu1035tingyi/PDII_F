// code Review (Power By Copilot):
// Strengths:
// - Follows WinForms conventions, with good separation of concerns (UI, state).
// - Button and panel enabling/disabling is centralized.
// - Uses partial class for maintainability.
// Suggestions:
// - Spelling: Is_Satrted → Is_Started.                                                         - Done
// - Consider extracting repeated logic (e.g., item button click handlers) to a generic handler. - Pass  : I'll do if I have time 👍.
// - Some fields (e.g., _id) could be initialized or validated more robustly.                    - Done
// - Comments are helpful but could be expanded for public methods.                              - Ignore: I Tried.

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
using System.IO;

namespace PDII_F
{
    public partial class Form1 : Form
    {
        private static int _id = 1;
        public static int ID
        {
            get { return _id; }
        }

        public static void NextID()
        {
            _id++;
        }

        public static int GetID()
        {
            return ID;
        }


        public bool Is_Started = false;
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
            MainItem.Setup(false);
            PanelStartup();
        }

        private void button_del_all_Click(object sender, EventArgs e)
        {
            Is_Started = false;
            Button_Enable(Is_Started);
            PanelObj_Enable(Is_Started);
            button_start.Visible = true;
            label1.Text = "";
            Item.Clear();

        }

        //開始
        private void button_start_Click(object sender, EventArgs e)
        {
            Started_time = System.DateTime.Now.ToString();
            Is_Started = true;
            button_start.Visible = false;
            PanelObj_Enable(Is_Started);

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
            Label_info.Text = "Version : 0.1.0b\n" + System.DateTime.Now.ToString();
        }


        /// <summary>
        /// 這個部分由AI協助完成
        /// </summary>
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
                    Item.Additem(Item.Parse(other.ItemName+" -自訂項目", p));
                }
                else MessageBox.Show($"輸入參數: \"{other.ItemPrice}\" 無效!\n","OK" ,MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            using (StreamWriter sw = File.AppendText(@".\Save.txt"))
            {
                sw.WriteLine(label1.Text);
            }
            try
            {
                // 這裡假設已連接明細印表機
                // 使用 label1.Text 即可傳出
                // 太麻煩先跳過👍
            }
            catch (Exception error)
            {
                MessageBox.Show($"{error}\n請確認細列印機!","明細列印錯誤",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            button_del_all_Click(sender,e);
            Form1.NextID();
            MessageBox.Show("訂單完成","",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }
        public void Button_Enable(bool key)
        {
            button_reset.Enabled = key;
            button_print.Enabled = key;
            button_del_last.Enabled = key;
        }
        public void PanelObj_Enable(bool key)
        {
            foreach (Control c in PanelObject.Controls)
            {
                if (c is Button button)
                { 
                    c.Enabled = key;
                }
            }
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
            label1.Text = Item.ShowItems(Started_time,Item.Items);
            if (label1.Text != "")
            {
                Button_Enable(true);
            }
        }

        public void FinshClick(string name)
        {
            Item._Item i = MainItem.GetByName(name);
            Item.Additem(i);
            show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/shu1035tingyi/PDII_F");
        }

        /*
         * 這裡有點醜
         * 未來可以用 panel
         * foreach (Control c in PanelObject.Controls)
         * 對 Button 進行初始化
         * 懂得都懂 先跳過😀
         */
        private void button3_Click(object sender, EventArgs e) { FinshClick(button3.Text); }
        private void button4_Click(object sender, EventArgs e) { FinshClick(button4.Text); }
        private void button5_Click(object sender, EventArgs e) { FinshClick(button5.Text); }
        private void button6_Click(object sender, EventArgs e) { FinshClick(button6.Text); }
        private void button7_Click(object sender, EventArgs e) { FinshClick(button7.Text); }
        private void button8_Click(object sender, EventArgs e) { FinshClick(button8.Text); }
        private void button9_Click(object sender, EventArgs e) { FinshClick(button9.Text); }
        private void button10_Click(object sender, EventArgs e) { FinshClick(button10.Text); }
        private void button11_Click(object sender, EventArgs e) { FinshClick(button11.Text); }
        private void button12_Click(object sender, EventArgs e) { FinshClick(button12.Text); }
        private void button13_Click(object sender, EventArgs e) { FinshClick(button13.Text); }

    }
}
