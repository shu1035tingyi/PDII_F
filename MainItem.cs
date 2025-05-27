using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDII_F
{
    internal class MainItem
    {
        public static List<Item._Item> MainItems = new List<Item._Item>();

        public static void AddItem(string name,int price) 
        {
            Item._Item add = new Item._Item();
            add.Name = name;
            add.Price = price;
            MainItems.Add(add);
        }

        public static void Setup() 
        {
            AddItem("a", 0);
            AddItem("b", 0);
            AddItem("c", 0);
            AddItem("d", 0);
            AddItem("e", 0);
            AddItem("f", 0);
            AddItem("g", 0);
            AddItem("h", 0);
            AddItem("i", 0);
            AddItem("j", 0);
            AddItem("k", 0);
        }

        public static Item._Item GetByIndex(int index) 
        {
            return MainItems[index];
        }

        public static Item._Item GetByName(string name) 
        {
            foreach (Item._Item item in MainItems) 
            {
                if (item.Name == name) return item;
            }
            return null;
        }

        public static int GetCount()
        {
            return MainItems.Count();
        }

    }
}
