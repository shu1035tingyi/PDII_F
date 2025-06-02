// code Review (Power By Copilot):
// Strengths:
// - Setup supports both hardcoded and file-loaded initialization.
// - Defensive programming with error handling in file reading.
// Suggestions:
// - Typo: "Lsit" in comment should be "List".                                              - Done
// - Consider using using blocks for StreamReader for automatic disposal.                   - Done
// - MainItems could be set to readonly or private set if not meant to change outside class.- Pass : Too diffical to me.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data;

namespace PDII_F
{
    internal class MainItem : Stuff
    {
        public static List<_Item> MainItems = new List<_Item>();


        public static void Setup(bool ez_way = true)
        {
            if (ez_way)
            {
                MainItems.Add(MainItem.Parse("原味肉包", 30));
                MainItems.Add(MainItem.Parse("辣味肉包", 30));
                MainItems.Add(MainItem.Parse("雞肉起司包", 30));
                MainItems.Add(MainItem.Parse("蛋黃肉包", 35));
                MainItems.Add(MainItem.Parse("大甲芋泥包(素)", 25));
                MainItems.Add(MainItem.Parse("芝麻包(素)", 30));
                MainItems.Add(MainItem.Parse("香菇蔬菜包(素)", 30));
                MainItems.Add(MainItem.Parse("黑糖饅頭", 20));
                MainItems.Add(MainItem.Parse("乳酪饅頭", 30));
                MainItems.Add(MainItem.Parse("豆漿", 25));
                MainItems.Add(MainItem.Parse("紅茶", 20));
            }
            else
            {
                MainItems = ReadMainItem();
            }
        }
        /// 來源: https://learn.microsoft.com/zh-tw/troubleshoot/developer/visualstudio/csharp/language-compilers/read-write-text-file
        /// <summary>
        /// 利用 Visual C# 讀取文字檔
        /// </summary>
        /// <param name="Path">檔案路徑</param>
        /// <returns>List {Stuff._Item} </returns>
        private static List<_Item> ReadMainItem(string Path = @".\MainItem.txt")
        {
            List<_Item> items = new List<_Item>();
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.StartsWith("#"))
                        {
                            string[] tmp = line.Split(' ');
                            items.Add(MainItem.Parse(tmp[0], int.Parse(tmp[1])));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}\n請盡速聯繫開發人員!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // sr.Close(); 當 using (...) 完成或異常時會自動釋放資源
            return items;
        }
                


        [Obsolete("這個方法較不常用", true)]
        public static List<_Item> OldReadMainItem(string Path = @".\MainItem.txt")
        {
            List<_Item> items = new List<_Item>();
            String line;
            try
            {
                StreamReader sr = new StreamReader(Path);
                line = sr.ReadLine();
                while (line != null)
                {
                    if (!line.StartsWith("#"))
                    {
                        string[] tmp = new string[2];
                        tmp = line.Split(' ');
                        items.Add(MainItem.Parse(tmp[0], int.Parse(tmp[1])));
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e}\n請盡速聯繫開發人員!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return items;
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
