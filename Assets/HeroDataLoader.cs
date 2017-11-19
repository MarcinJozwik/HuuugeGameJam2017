using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDataLoader : MonoBehaviour {

    public GameObject Torso;
    public GameObject Head;
    public GameObject Face;


	public void Load(Hero hero)
    {
        Torso.GetComponent<MeshRenderer>().materials[0] = hero.Torso.MyMaterial;
        Torso.GetComponent<MeshFilter>().mesh = hero.Torso.MyModel;

        Head.GetComponent<MeshRenderer>().materials[0] = hero.Head.MyMaterial;
        Head.GetComponent<MeshFilter>().mesh = hero.Head.MyModel;

        Face.GetComponent<MeshRenderer>().materials[0].mainTexture = hero.Face.MyTexture;

    }
}
