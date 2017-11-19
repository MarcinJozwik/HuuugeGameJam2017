using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{

    public GameObject RestartCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restart()
    {
        GameController.Instance.CurrentGameState = GameController.GameState.Intro;
        this.RestartCanvas.SetActive(false);
    }
}
