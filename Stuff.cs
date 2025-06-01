using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDII_F
{
    public class Stuff
    {
        public class _Item
        {
            public string Name { get; set; }
            public int Price { get; set; }// 這裡允許負數，如折扣
        }
        public static _Item Parse(string name,int price)
        {
            _Item item = new _Item();
            item.Name = name;
            item.Price = price;
            return item;
        }
    }
}
