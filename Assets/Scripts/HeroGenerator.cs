using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGenerator : MonoBehaviour {

    public AllParts Parts;
    public Party TargetParty;

	public void GenerateParty(int heroesCount)
    {
        if (TargetParty == null)
        {
            Debug.LogError("Target Party is null, fix it ffs.");
        }
        var result = new List<Hero>();
        for (int i=0;i<heroesCount; i++)
        {
            var heroClass = Parts.Classes.GetRandomElement();
            if(heroClass == null)
            {
                Debug.LogError("Classes are empty ffs...");
            }
            TargetParty.Heroes[i].Class = heroClass;
            if (heroClass.name == "Warrior")
                GenerateHero(Parts.WarriorParts, TargetParty.Heroes[i]);
            else if (!true)
            {

            }
            else
            {
                Debug.LogError("Unknown name");
            }

        }
    }



    private void GenerateHero(HeroParts parts, Hero hero)
    {
        hero.Head = parts.Heads.GetRandomElement();
        hero.Torso = parts.Torsos.GetRandomElement();
        hero.Arms = parts.Arms.GetRandomElement();
        hero.Legs = parts.Legs.GetRandomElement();
    }
}
