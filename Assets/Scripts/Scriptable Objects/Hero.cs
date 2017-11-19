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
    public MatchableObject Face;

    public IEnumerable<string> GetDescription()
    {
        var result = new List<string>();
        result.Add(Class.Name);
        if(Head.MyMaterial != null && Head.MyModel != null)
            result.Add(Head.MyMaterial.name + " " + Mesh2Word.GetName(Head.MyModel.name));
        if (Torso.MyMaterial != null && Torso.MyModel != null)
            result.Add(Torso.MyMaterial.name + " " + Mesh2Word.GetName(Torso.MyModel.name));
        if (Face.MyTexture != null)
            result.Add(Face.MyTexture.name);

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
        if (otherHero.Face == Face)
            result++;

        return result;
    }

    public void Reset()
    {
        IsActive = false;
        Class = null;
        Head = null;
        Torso = null;
        Face = null;
    }


}
