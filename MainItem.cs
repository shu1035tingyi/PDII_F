using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDII_F
{   
    internal class MainItem : Stuff
    {
        public static List<_Item> MainItems = new List<_Item>();

        public static void AddItem(string name,int price)
        {
            _Item add = new _Item();
            add.Name = name;
            add.Price = price;
            MainItems.Add(add);
        }

        public static void Setup() 
        {
            AddItem("原味肉包", 30);
            AddItem("辣味肉包", 30);
            AddItem("雞肉起司包", 30);
            AddItem("蛋黃肉包", 35);
            AddItem("大甲芋泥包(素)", 25);
            AddItem("芝麻包(素)", 30);
            AddItem("香菇蔬菜包(素)", 30);
            AddItem("黑糖饅頭", 20);
            AddItem("乳酪饅頭", 30);
            AddItem("豆漿", 25);
            AddItem("紅茶", 20);
        }

        public static _Item GetByIndex(int index) 
        {
            return MainItems[index];
        }

        public static _Item GetByName(string name) 
        {
            foreach (_Item item in MainItems) 
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
