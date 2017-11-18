﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zmien to kurwa", menuName = "Hero Maker/All Parts")]
public class AllParts : ScriptableObject {

    public List<MatchableObject> Classes;
    public HeroParts WarriorParts;

}