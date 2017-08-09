using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Test
{
    static class FullNameCompare
    {
        public static bool ContainName(string expected, string actual)
        {
            if (actual.Contains(expected)) return true;
            else return false;
        }
    }
}
