using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexadecimalExtension
{
    public static class HexadecimalConverter
    {
        public static string ToHexadecimal(this int value)
        {
            if (value == 0)
                return "0";
            string basis = "0123456789ABCDEF";
            StringBuilder result = new StringBuilder("");
            while (value != 0)
            {
                int r = value % 16;
                result.Insert(0, basis[r]);
                value /= 16;
            }
            return result.ToString();
        }
    }
}
