// code Review (Power By Copilot):
// Strengths:
// - Clear entry point with argument handling for different modes (normal, debug, resume from order).
// - Debug mode is helpful for diagnostics and item listing.
// Suggestions:
// - Consider validating args length before accessing args[1] to avoid exceptions.                  - Done
// - The code mixes English and Chinese in comments/messages; consistency might help maintenance.   - Ignore: Too lazy to do it...
// - Consider handling parse failures for int.Parse more gracefully (TryParse).                     - Done

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
        /// * 這裡屬實是超綱了:)
        /// </summary>
        /// <param name="args"> 外部開啟時的可選參數。
        /// "-r [int]": 從指定的訂單ID開始;
        /// "-d": 開始除錯模式。
        /// </param>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                switch (args[0])
                {
                    case "-r":
                        int inID = 1;
                        if (args.Length > 1 && int.TryParse(args[1], out int parsedId) && parsedId > 0)
                        {
                            inID = parsedId;
                        }
                        else if (args.Length > 1)
                        {
                            MessageBox.Show("請輸入有效的單號", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        start(inID);
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
                                for (int i = -10; i < 20; i++) Item.Parse(i.ToString(),i);
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
            MessageBox.Show("目前單號:" + Form1.GetID().ToString(),"程式結束",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
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
