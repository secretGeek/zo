using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zo
{
    static class SQLStyleExtensions
    {
        public static bool In<T>(this T me, params T[] set)
        {
            return set.Contains(me);
        }
    }
}
