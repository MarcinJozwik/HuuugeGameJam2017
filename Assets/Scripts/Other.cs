using System.Collections.Generic;
using System;

public static class Other {

    public static T GetRandomElement<T>(this IList<T> list)
    {
        if (list.Count == 0)
            return default(T);
        int index = UnityEngine.Random.Range(0, list.Count);
        return list[index];
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}