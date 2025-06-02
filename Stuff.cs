// code Review (Power By Copilot):
// Strengths:
// - Encapsulation of item properties via _Item class.
// - Simple, readable Parse method.
// Suggestions:
// - _Item could be renamed for clarity (e.g., ItemData).                   - Pass  : Nope.
// - Consider adding validation to prevent negative prices if not intended. - Ignore: Yes, I have intended.

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
