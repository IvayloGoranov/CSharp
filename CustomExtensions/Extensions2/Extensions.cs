using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class Extensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (T item in collection)
            {
                if (condition(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            List<T> targetList = new List<T>();
            foreach (T item in collection)
            {
                if (condition(item))
                {
                    targetList.Add(item);
                }
                else
                {
                    break;
                }
            }

            return targetList;
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
            {
                action(item);
            }
        }
    }
}
