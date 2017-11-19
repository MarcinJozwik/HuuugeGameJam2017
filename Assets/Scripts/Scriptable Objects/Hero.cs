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
        if (otherHero.Class.Name == Class.Name)
            result++;
        if (otherHero.Head.MyMaterial == Head.MyMaterial && otherHero.Head.MyModel == Head.MyModel)
            result++;
        if (otherHero.Torso.MyModel == Torso.MyModel && otherHero.Torso.MyMaterial == Torso.MyMaterial)
            result++;
        if (otherHero.Face.MyTexture == Face.MyTexture)
            result++;

        return result;
    }

    public void Reset()
    {
        IsActive = false;
        if(Class != null)
            Class.Name = "";
        if (Head != null)
        {
            Head.MyModel = null;
            Head.MyMaterial = null;
        }
        if (Torso != null)
        {
            Torso.MyModel = null;
            Torso.MyMaterial = null;
        }
        if (Face != null)
            Face.MyTexture = null;
    }

    public Model GetHead()
    {
        Model result = new Model();
        result.material = Head.MyMaterial;
        result.mesh = Head.MyModel;
        return result;
    }

    public Model GetTorso()
    {
        Model result = new Model();
        result.material = Torso.MyMaterial;
        result.mesh = Torso.MyModel;
        return result;
    }


}
