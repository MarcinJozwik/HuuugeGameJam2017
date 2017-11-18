using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/Party")]
public class Party : ScriptableObject, IComparable
{

    public List<Hero> Heroes;

    //USE THIS TO GET AMOUT OF ACCCEPTED OBJECTS
    public int CompareTo(object obj)
    {
        Party otherParty = obj as Party;
        int result = 0;
        for (int i = 0; i < 4; i++)
        {
            if (!Heroes[i].IsActive)
                continue;
            result += Heroes[i].CompareTo(otherParty.Heroes[i]);
        }

        return result;

    }


    public void Reset()
    {
        foreach (var hero in Heroes)
        {
            hero.Reset();
        }
    }
}
