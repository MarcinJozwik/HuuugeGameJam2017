using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksGenerator : MonoBehaviour {

    public int tasksToGenerate;
    public GameObject TaskPrefab;
    public GameObject Viewport;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < tasksToGenerate; i++)
        {
            GameObject go = Instantiate(TaskPrefab);
            go.transform.SetParent(Viewport.transform, false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
