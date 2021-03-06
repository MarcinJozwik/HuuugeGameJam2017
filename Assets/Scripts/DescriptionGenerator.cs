﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gamelogic.Extensions.Algorithms;
using UnityEngine;
using Random = UnityEngine.Random;

public class DescriptionGenerator
{
    private List<string> heroParams;
    private readonly List<string> baseFirstWearingVerbs;
    private readonly List<string> firstWearingVerbs;
    private readonly List<string> baseSecondWearingVerbs;
    private readonly List<string> secondWearingVerbs;

    private readonly List<string> epithetNames;
    private readonly List<string> baseEpithetNames;

    private readonly List<string> baseAddons;
    private readonly List<string> addons;

    private string firstItem;
    private string secondItem;

    public DescriptionGenerator()
    {
        epithetNames = new List<string>();
        firstWearingVerbs = new List<string>();
        secondWearingVerbs = new List<string>();
        addons = new List<string>();
        baseFirstWearingVerbs = new List<string>()
        {
            "odziany w",
            "posiadający",
            "opasany w",
            "obtykany",
            "układły przez",
            "ustrojony w",
        };
        baseSecondWearingVerbs = new List<string>()
        {
            "Wdłożyłbym mu także",
            "Całość uchopia",
            "Od ogółu odrzeza się",
            "Wskładałbym do tego",
            "Warte wględowania się jest też",
            "Niech wdirży twoją uwagę lepaknię",
        };
        baseEpithetNames = new List<string>()
        {
            "marcielny",
            "mężczyński",
            "mistrowny",
            "potwarczy",
            "przeszarzedny",
            "przezeczciwy",
            "puścieły",
            "kruty",
            "kluzki",
            "kłokietliwy",
            "klecawy",
            "juczny",
            "błogosławieny"
        };
        baseAddons = new List<string>()
        {
            "z siekanicą",
            "z tkanicą",
            "ze sponką",
            "ze spieniem",
            "z zaniklem",
            "ze sztrychami",
            "z wędą",
            "z wirzbcem",
            "z listwicą",
            "z hubą",
            "z fryżkami",
            "ze śliczkiem",
            "z draczkiem",
            "ze pągwicami",
        };
    }

    public string GetDescription(Hero hero)
    {
        heroParams = hero.GetDescription().ToList();
        string intro = "Mistrzu, w potrzebiźnie przyjacham!\nPotrzebna grumada:\n";
        ShuffleItemInDescription();
        firstItem = GetGenderizableString(firstItem);
        secondItem = GetGenderizableString(secondItem);
        return String.Format("{5}{0} {6} {1} {2} {7}.\n{3} {4} {8}.", CamelString(GetRandomFromList(baseEpithetNames, epithetNames)), GetRandomFromList(baseFirstWearingVerbs, firstWearingVerbs), firstItem, GetRandomFromList(baseSecondWearingVerbs, secondWearingVerbs), secondItem, intro, heroParams[0], GetRandomFromList(baseAddons, addons), GetRandomFromList(baseAddons, addons));
    }    

    private string GetRandomFromList(List<string> baseList, List<string> currentList)
    {
        if (!currentList.Any())
        {
            currentList = new List<string>(baseList);
        }

        int index = Random.Range(0, currentList.Count);
        string randomString = currentList.ElementAt(index);
        currentList.RemoveAt(index);

        return randomString;
    }

    private string CamelString(string heroParam)
    {
        return String.Format("{0}{1}", heroParam.Substring(0, 1).ToUpper(), heroParam.Substring(1));
    }

    private string GetGenderizableString(string item)
    {
        if (item.EndsWith("a"))
        {
            int index = item.IndexOf(" ") - 1;
            item = item.Remove(index, 1);
            item = item.Insert(index, "a");
        }
        else if (item.EndsWith("o"))
        {
            int index = item.IndexOf(" ") - 1;
            item = item.Remove(index, 1);
            item = item.Insert(index, "e");
        }
        return item;
    }

    private void ShuffleItemInDescription()
    {
        if (Random.Range(0, 2) == 0)
        {
            firstItem = heroParams[1];
            secondItem = heroParams[2];
        }
        else
        {
            secondItem = heroParams[1];
            firstItem = heroParams[2];
        }
    }
}
