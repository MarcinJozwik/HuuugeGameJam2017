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
        Camera.main.transform.position = new Vector3(0.87f, 1.08f, -3.11f);
        Camera.main.transform.rotation = Quaternion.Euler(20.761f, 0.0f, 0.0f);
        GameController.Instance.CurrentGameState = GameController.GameState.Intro;
        this.StartCanvas.SetActive(false);
    }
}
