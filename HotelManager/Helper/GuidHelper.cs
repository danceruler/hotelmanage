using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManager.Helper
{
    public static class GuidHelper
    {
        public static string ConvertGuid(this Guid gd)
        {
            string sgd = gd.ToString().ToUpper();
            string sVar = "";
            int i;

            foreach (string sv in new string[] {
            sgd.Substring(0, 8), sgd.Substring(9, 4), sgd.Substring(14, 4) })
            {
                for (i = sv.Length - 2; i >= 0; i -= 2)
                {
                    sVar += sv.Substring(i, 2);
                }
            }

            sgd = sgd.Substring(19).Replace("-", "");
            for (i = 0; i < 8; i++)
            {
                sVar += sgd.Substring(2 * i, 2);
            }

            return sVar;
        }
    }
}
