using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/Hero Parts")]
public class HeroParts : ScriptableObject
{

    public List<MatchableObject> Heads;
    public List<MatchableObject> Torsos;
    public List<MatchableObject> Faces;


}
