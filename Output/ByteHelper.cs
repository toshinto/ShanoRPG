using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IO
{
    /// <summary>
    /// Contains extension methods for the conversion between strings and byte arrays. 
    /// </summary>
    public static class ByteHelper
    {
        public static byte[] GetBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string GetString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

    }
}
