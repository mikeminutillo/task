using System;
using System.Linq;
using System.Collections.Generic;

namespace Task
{
    static class EnumerableExtensions
    {
        public static void Apply<T>(this IEnumerable<T> target, Action<T> action)
        {
            foreach (var item in target)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Unique<T>(this IEnumerable<T> target)
        {
            return target.GroupBy(x => x).Select(x => x.Key);
        }

    }
}
