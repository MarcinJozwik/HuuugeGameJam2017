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

}
