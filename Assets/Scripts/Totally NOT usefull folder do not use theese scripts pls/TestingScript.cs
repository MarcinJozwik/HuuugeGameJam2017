using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroGenerator))]
public class TestingScript : MonoBehaviour
{

    private HeroGenerator generator;
    public Party TargetParty;
    public Party WorkingParty;

    private void Start()
    {
        generator = GetComponent<HeroGenerator>();
        generator.GenerateParty(3);

        Debug.Log(WorkingParty.CompareTo(TargetParty));

    }


}
