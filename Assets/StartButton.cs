using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    public GameObject GameCanvas;

    public GameObject StartCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        this.GameCanvas.SetActive(true);
        GameController.Instance.CurrentGameState = GameController.GameState.Intro;
        this.StartCanvas.SetActive(false);
    }
}
