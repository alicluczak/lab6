using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    interface Interface<T> : IEnumerable<T>
    {
        public static T MinMax<T>(ref T a, ref T b) where T : IComparable
        {
            T min = a;
            T max = b;
            return
        }
    }
}
