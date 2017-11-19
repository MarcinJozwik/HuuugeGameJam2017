using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/Hero Parts")]
public class HeroParts : ScriptableObject
{
    public List<Mesh> Heads;
    public List<Mesh> Torsos;
    public List<string> Names;
}
