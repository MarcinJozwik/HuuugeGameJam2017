using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(HeroGenerator))]
public class TestingScript : MonoBehaviour
{
    public AllParts allParts;
    public HeroDataLoader loader;
    private HeroGenerator generator;
    public Party TargetParty;
    public Party WorkingParty;
    public int spawnedHeroes = 2;

    public LoadToRender[] Loaders;

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

        Load(TargetParty.Heroes[0]);

    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (++shownHero == spawnedHeroes)
                shownHero = 0;

            loader.Load(TargetParty.Heroes[shownHero]);
        }
    }

    private void Load(Hero hero)
    {
        loader.Load(hero);
        var list = new List<Model>();
        Model targetModel = hero.GetTorso();
        list.Add(targetModel);
        do
        {
            var model = allParts.GetRandomTorsoModel();
            if (!ContainsModel(list, model))
            {

                list.Add(model);
            }
        }
        while (list.Count != 5);

        list.Shuffle();
        for (int i = 0; i < 5; i++)
        {
            Loaders[i].LoadModel(list[i]);
        }
    }

    private bool IsModelTheSame(Model model1, Model model2)
    {
        return model1.material == model2.material && model1.mesh == model2.mesh;
    }

    private bool ContainsModel(List<Model> models, Model model)
    {
        foreach (var exmod in models)
        {
            if (IsModelTheSame(exmod, model))
                return true;
        }

        return false;
    }



}