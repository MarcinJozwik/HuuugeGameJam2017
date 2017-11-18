using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "Hero Maker/Hero", fileName = "Hero")]
public class Hero : ScriptableObject, IComparable
{
    [SerializeField]
    private bool isActive = false;
    public bool IsActive { get { return isActive; } set { isActive = value; } }


    public MatchableObject Class;
    public MatchableObject Head;
    public MatchableObject Torso;
    public MatchableObject Arms;
    public MatchableObject Legs;

    public IEnumerable<string> GetDescription()
    {
        var result = new List<string>();
        result.Add(Class.Description);
        result.Add(Head.Description);
        result.Add(Torso.Description);
        result.Add(Arms.Description);
        result.Add(Legs.Description);

        return result;
    }

    public int CompareTo(object obj)
    {
        Hero otherHero = obj as Hero;
        int result = 0;
        if (otherHero.Class == Class)
            result++;
        if (otherHero.Head == Head)
            result++;
        if (otherHero.Torso == Torso)
            result++;
        if (otherHero.Arms == Arms)
            result++;
        if (otherHero.Legs == Legs)
            result++;

        return result;
    }

    public void Reset()
    {
        IsActive = false;
        Class = null;
        Head = null;
        Torso = null;
        Arms = null;
        Legs = null;
    }


}
