using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    public GameController gc;

    public Text text;


	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
	    int minutes = (int)(this.gc.createPartyTime - gc.partyTimer) / 60;
	    int seconds = (int)(this.gc.createPartyTime - gc.partyTimer) - minutes * 60;
	    this.text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
    }

}
