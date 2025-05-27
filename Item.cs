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

        public static string ShowItems() 
        {
            string tmp = "= = = = = = = = = = = = = = = = = = =";
            int total = 0;
            foreach (var item in Items)
            {
                tmp += $"\n{item.Name} - -{item.Price.ToString()}";
                total += item.Price;
            }
            tmp += "\n---------------------------------------------";
            tmp += $"\n                                              Total - {total.ToString()}\n";
            tmp += "= = = = = = = = = = = = = = = = = = =\n";

            if (total == 0) return "";

            else return tmp;
        }
    }
}
