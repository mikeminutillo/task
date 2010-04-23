using System;
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
    }
}
