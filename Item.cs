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
    internal class Item
    {
        public class _Item
        {
            public string Name { get; set; }
            public int Price { get; set; }

        }
       

        public static List<Item._Item> Items = new List<Item._Item>();
        
        public static void AddItem(string name, int price)
        {
            _Item add = new _Item();
            add.Name = name;
            add.Price = price;
            Items.Add(add);
        }

        public static void DelLastItem() 
        {
            if (Items.Count > 0) 
            {
                Items.RemoveAt(Items.Count - 1);
            }
        }

        public static string ShowItems(string time) 
        {
            string tmp = "= = = = = = = = = = = = = = = =\n"+time;
            tmp += "\n\n\n-------------------------------";
            int total = 0;
            foreach (var item in Items)
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
            tmp += $"\n\n\n            Total - {total.ToString()}\n";
            tmp += "= = = = = = = = = = = = = = = =\n";

            if (total == 0) return "";

            else return tmp;
        }

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
