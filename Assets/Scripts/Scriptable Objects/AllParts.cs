using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/All Parts")]
public class AllParts : ScriptableObject {

    public List<MatchableObject> Classes;
    public List<Material> Colors;
    public List<Texture2D> Faces;
    public HeroParts WarriorParts;
    public HeroParts PriestParts;
    public HeroParts AssasinParts;
    public HeroParts ArcherParts;
    public HeroParts MageParts;

    public Model GetRandomTorsoModel()
    {
        Model model = new Model();

        var list = new List<Mesh>();
        list.AddRange(WarriorParts.Torsos);
        list.AddRange(PriestParts.Torsos);
        list.AddRange(AssasinParts.Torsos);
        list.AddRange(ArcherParts.Torsos);
        list.AddRange(MageParts.Torsos);

        model.mesh = list.GetRandomElement();
        model.material = Colors.GetRandomElement();

        return model;
    }

    public Model GetRandomHeadModel()
    {
        Model model = new Model();

        var list = new List<Mesh>();
        list.AddRange(WarriorParts.Heads);
        list.AddRange(PriestParts.Heads);
        list.AddRange(AssasinParts.Heads);
        list.AddRange(ArcherParts.Heads);
        list.AddRange(MageParts.Heads);

        model.mesh = list.GetRandomElement();
        model.material = Colors.GetRandomElement();

        return model;
    }

}
