using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {

    public Party targetParty;
    public Party workingParty;

	void Start () {
        targetParty.Reset();
        workingParty.Reset();
	}
	
}
