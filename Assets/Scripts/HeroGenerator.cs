using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroGenerator : MonoBehaviour
{
    public MatchableObject basicObject;
    public AllParts AllParts;
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
            var heroClass = AllParts.Classes.GetRandomElement();
            if (heroClass == null)
            {
                Debug.LogError("Classes are empty ffs...");
            }
            TargetParty.Heroes[i].Class.Name = heroClass.Name;
            TargetParty.Heroes[i].IsActive = true;
            if (heroClass.name == "Warrior")
            {
                GenerateHero(AllParts.WarriorParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Assasin")
            {
                GenerateHero(AllParts.AssasinParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Priest")
            {
                GenerateHero(AllParts.PriestParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Mage")
            {
                GenerateHero(AllParts.MageParts, TargetParty.Heroes[i]);
            }
            else if (heroClass.name == "Archer")
            {
                GenerateHero(AllParts.ArcherParts, TargetParty.Heroes[i]);
            }
            else
            {
                Debug.LogError("Unknown name");
            }

        }
    }



    private void GenerateHero(HeroParts parts, Hero hero)
    {
        Item notClassic = (Item)Random.Range(0, 3);

        hero.Face.MyTexture = AllParts.Faces.GetRandomElement();
        //hero.Class.Name = parts.Names.GetRandomElement();

        if (notClassic != Item.Torso)
        {
            hero.Torso.MyModel = parts.Torsos.GetRandomElement();
        }
        else
        {
            var list = new List<Mesh>();
            list.AddRange(AllParts.ArcherParts.Torsos);
            list.AddRange(AllParts.AssasinParts.Torsos);
            list.AddRange(AllParts.MageParts.Torsos);
            list.AddRange(AllParts.PriestParts.Torsos);
            list.AddRange(AllParts.WarriorParts.Torsos);

            hero.Torso.MyModel = list.GetRandomElement();
        }
        hero.Torso.MyMaterial = AllParts.Colors.GetRandomElement();


        if (notClassic != Item.Head)
        {
            hero.Head.MyModel = parts.Heads.GetRandomElement();
        }
        else
        {
            var list = new List<Mesh>();
            list.AddRange(AllParts.ArcherParts.Heads);
            list.AddRange(AllParts.AssasinParts.Heads);
            list.AddRange(AllParts.MageParts.Heads);
            list.AddRange(AllParts.PriestParts.Heads);
            list.AddRange(AllParts.WarriorParts.Heads);

            hero.Head.MyModel = list.GetRandomElement();
        }
        hero.Head.MyMaterial = AllParts.Colors.GetRandomElement();

        hero.Face.MyTexture = AllParts.Faces.GetRandomElement();
    }
}


enum Item
{
    Head = 0,
    Torso = 1,
    Face = 2
}
