using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecksAndBalances.Extensions
{
    public static class Strings
    {
        public static string ToUrlSafeString(this string content)
        {
            return content.ToLower().Replace(' ', '_');
        }
    }
}
