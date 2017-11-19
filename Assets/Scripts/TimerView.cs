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
	    StartCoroutine(this.ApplyTime());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator ApplyTime()
    {
        while (true)
        {
            int minutes = (int)(this.gc.createPartyTime - gc.partyTimer) / 60;
            int seconds = (int)(this.gc.createPartyTime - gc.partyTimer) - minutes * 60;
            this.text.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
            yield return new WaitForSeconds(1.0f);
        }
    }
}
