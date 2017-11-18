using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HeroGenerator))]
public class TestingScript : MonoBehaviour {

    private HeroGenerator generator;

    private void Start()
    {
        generator = GetComponent<HeroGenerator>();
        generator.GenerateParty(3);

    }


}
