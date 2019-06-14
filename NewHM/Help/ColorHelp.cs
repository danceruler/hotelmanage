using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Help
{
    public class ColorHelp
    {
        public static byte[] GetARGByStr(string color)
        {
            var result = new byte[4];
            result[0] = byte.Parse(color.Substring(0,2), NumberStyles.HexNumber);
            result[1] = byte.Parse(color.Substring(2, 2), NumberStyles.HexNumber);
            result[2] = byte.Parse(color.Substring(4, 2), NumberStyles.HexNumber);
            result[3] = byte.Parse(color.Substring(6, 2), NumberStyles.HexNumber);
            return result;
        }
    }
}
