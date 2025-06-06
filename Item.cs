﻿// code Review (Power By Copilot):
// Strengths:
// - Good separation of static collection management (Add, Remove, Clear, Show).
// - ShowItems method formats output clearly, including total.
// Suggestions:
// - CheckString could be moved/utilized elsewhere if needed by other classes.              - Ignore
// - Consider thread safety if Items is accessed from multiple threads (not evident here).  - TODO  : coming soon...
// - Method naming: Add_item → AddItem (C# convention is PascalCase).                      - Done

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PDII_F
{
    internal class Item : Stuff
    {
        public static List<_Item> Items = new List<_Item>();


        public static void Additem(_Item i)
        {
            Items.Add(i);
        }

        public static void DelLastItem()
        {
            if (Items.Count > 0)
            {
                Items.RemoveAt(Items.Count - 1);
            }
        }

        public static void Clear()
        { 
            Items.Clear();
        }

        public static int GetCount()
        {
            return Items.Count();
        }

        public static string ShowItems(string time, List<_Item> list)
        {
            string s = String.Format("{0:0000000}",Form1.GetID());
            string tmp = "= = = = = = = = = = = = = = = =\n "+time+"\n";

            tmp += "\n訂單編號:        "+s;
            tmp += "\n\n\n-------------------------------";
            int total = 0;
            foreach (var item in list)
            {
                int n = 20-CheckString(item.Name);
                string space = "";
                for (int i = 0; i < n; i++)
                {
                    space += " ";
                }
                tmp += "\n"+item.Name+ space + item.Price.ToString();
                tmp += "\n-------------------------------";
                total += item.Price;
            }
            total = (total < 0) ? 0 : total;
            tmp += $"\n\n\n            Total : {total.ToString()}\n";
            tmp += "= = = = = = = = = = = = = = = =\n";

            if (GetCount() == 0) return "";

            else return tmp;
        }

        /// 來源: "https://blog.csdn.net/u014453443/article/details/121784786"
        /// <summary>
        /// 使用ascii來判斷字串的寬度，因中文字符寬度較大，則以`2`來記數。
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>return 0 if null or "" </returns>
        private static int CheckString(string s)
        {
            int tmp = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] > 127) tmp += 2;
                else tmp += 1;
            }
            return tmp;
        }
    }
}
