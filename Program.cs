using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            switch (args[0])
            {
                case "-r":
                    
                    if (args[0] == "-r" | int.Parse(args[1]) < 0)
                    {
                        start(int.Parse(args[1]));
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的單號","錯誤",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;
                    

                case "-d":
                    Console.WriteLine("-------->DEBUG MODE\n\n");
                    try
                    {
                        Console.WriteLine("Loading Class MainItem...");
                        MainItem.Setup();
                        for (int i = 0; i < MainItem.GetCount(); i++)
                        {
                            Stuff._Item item = MainItem.GetByIndex(i);
                            Console.WriteLine($"\tItem    Name:\t{item.Name}\tPrice:\t{item.Price}");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" MainItem 載入錯誤: " + e.Message);
                    }
                    finally 
                    {
                        Console.WriteLine("MainItem End. . .");
                        try
                        {
                            Console.WriteLine("Class Item Test...");
                            Item.ShowItems("YYYY/MM/DD - - - - ", Item.Items);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(" Item 載入錯誤: " + e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Item End. . .");
                        }

                    }
                    Console.WriteLine("\"-------->DEBUG MODE\n\n");
                    Console.WriteLine("請按任意鍵結束程式...");
                    Console.ReadKey();

                    break;

                default:
                    {
                        start();
                        break;
                    }
            }

            
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
    }
}
