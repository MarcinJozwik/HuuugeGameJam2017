using System.Collections.Generic;
using UnityEngine;

public static class Other {

    public static T GetRandomElement<T>(this IList<T> list)
    {
        if (list.Count == 0)
            return default(T);
        int index = Random.Range(0, list.Count);
        return list[index];
    }

}