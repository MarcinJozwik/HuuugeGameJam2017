using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGenerator : MonoBehaviour
{

    public AllParts Parts;
    public Party TargetParty;

    public void GenerateParty(int heroesCount)
    {
        if (TargetParty == null)
        {
            Debug.LogError("Target Party is null, fix it ffs.");
        }
        var result = new List<Hero>();
        for (int i = 0; i < heroesCount; i++)
        {
            var heroClass = Parts.Classes.GetRandomElement();
            if (heroClass == null)
            {
                Debug.LogError("Classes are empty ffs...");
            }
            TargetParty.Heroes[i].Class = heroClass;
            TargetParty.Heroes[i].IsActive = true;
            if (heroClass.name == "Warrior")
                GenerateHero(Parts.WarriorParts, TargetParty.Heroes[i]);
            else if (heroClass.name == "Assasin")
            {
                GenerateHero(Parts.AssasinParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Priest")
            {
                GenerateHero(Parts.PriestParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Mage")
            {
                GenerateHero(Parts.MageParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Archer")
            {
                GenerateHero(Parts.ArcherParts, TargetParty.Heroes[i]);
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
