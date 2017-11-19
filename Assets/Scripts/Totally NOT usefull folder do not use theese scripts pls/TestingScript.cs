using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroGenerator))]
public class TestingScript : MonoBehaviour
{
    public HeroDataLoader loader;
    private HeroGenerator generator;
    public Party TargetParty;
    public Party WorkingParty;

    private void Start()
    {
        generator = GetComponent<HeroGenerator>();
        generator.GenerateParty(3);


        foreach (var hero in TargetParty.Heroes)
        {
            if (!hero.IsActive)
                continue;
            string str = "";

            foreach (var dsc in hero.GetDescription())
            {
                str += dsc + " ";
            }

            Debug.Log(str);
        }
        //Debug.Log(WorkingParty.CompareTo(TargetParty));

        loader.Load(TargetParty.Heroes[0]);
    }


}