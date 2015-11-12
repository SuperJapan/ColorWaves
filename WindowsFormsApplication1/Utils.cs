using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Utils
    {
        public static void wl(string line)
        {
            Console.WriteLine(line);
        }
        public static Color getRandomeColor(List<Color> colorList)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return colorList[rand.Next(colorList.Count)];
        }
    }
}
