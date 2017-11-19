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
    public int spawnedHeroes = 2;

    int shownHero = 0;

    private void Start()
    {
        generator = GetComponent<HeroGenerator>();
        generator.GenerateParty(spawnedHeroes);


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


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (++shownHero == spawnedHeroes)
                shownHero = 0;

            loader.Load(TargetParty.Heroes[shownHero]);
        }
    }



}