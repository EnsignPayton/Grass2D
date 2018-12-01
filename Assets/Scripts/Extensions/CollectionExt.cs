using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Extensions
{
    public static class CollectionExt
    {
        public static T GetRandom<T>(this IList<T> value)
        {
            if (value.Count == 0) throw new ArgumentException(nameof(value.Count));
            return value[Random.Range(0, value.Count)];
        }

        public static void ForEach<T>(this IEnumerable<T> value, Action<T> action)
        {
            foreach (var t in value)
            {
                action(t);
            }
        }
    }
}
