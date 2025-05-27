using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            if (args.Length == 0)
            {
                start();
            }
            else if (args[0] == "-r" | int.Parse(args[1]) < 0)
            {
                start(int.Parse(args[1]));
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
            MessageBox.Show("程式結束\n目前單號:" + Form1.GetID().ToString());
        }

    }
}
