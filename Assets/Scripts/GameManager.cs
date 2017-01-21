using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public bool gameover = false;
    public Vector3 checkpoint;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	// Use this for initialization
	void Start () {
		if(instance != null)
        {
            Debug.LogError("Singleton Goofed");
        }
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameover)
        {
            //do some text stuff
        }
	}
}
