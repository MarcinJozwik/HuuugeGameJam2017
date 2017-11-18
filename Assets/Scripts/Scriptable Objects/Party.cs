using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/Party")]
public class Party : ScriptableObject {

    public List<Hero> Heroes;
}
