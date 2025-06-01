using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PDII_F
{
    internal static class Program
    {
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "-r":

                        if (args[0] == "-r" | int.Parse(args[1]) < 0)
                        {
                            start(int.Parse(args[1]));
                        }
                        else
                        {
                            MessageBox.Show("請輸入正確的單號", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;


                    case "-d":
                        string debug_contex = "";
                        debug_contex += ("-------->Debug MODE\n\n");
                        try
                        {
                            debug_contex += ("Loading Class MainItem...\n");
                            MainItem.Setup();
                            for (int i = 0; i < MainItem.GetCount(); i++)
                            {
                                Stuff._Item item = MainItem.GetByIndex(i);
                                debug_contex += ($"\tItem Name:\t{item.Name} - Price:\t{item.Price}\n");
                            }
                        }
                        catch (Exception e)
                        {
                            debug_contex += (" MainItem 載入錯誤: " + e.Message+"\n");
                        }
                        finally
                        {
                            debug_contex += ("MainItem End. . .\n");
                            try
                            {
                                debug_contex += ("Class Item Test...\n");
                                for (int i = -10; i < 20; i++) Item.AddItem(i.ToString(),i);
                                while (Form1.ID < 9999999) Form1.NextID();
                                debug_contex += Item.ShowItems("YYYY/MM/DD - - - - ", Item.Items);
                            }
                            catch (Exception e)
                            {
                                debug_contex += (" Item 載入錯誤: " + e.Message+"\n");
                            }
                            finally
                            {
                                debug_contex += ("Item End. . .\n");
                            }

                        }
                        debug_contex += ("\n\n-------->Debug MODE End");
                        debug_start(debug_contex);
                        break;

                    default:
                        {
                            start();
                            break;
                        }
                }
                
            }
            else start();
        }
        static void start(int id = 1) 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            while (Form1.GetID() < id) 
            {
                Form1.NextID();
            }

            Application.Run(form1);
            MessageBox.Show("目前單號:" + Form1.GetID().ToString(),"程式結束");
        }
        static void debug_start(string s) 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OverView ov = new OverView();
            ov.Text = "Debug modle";
            ov.LabelViewText = s;
            Application.Run(ov);
        }
    }
}
