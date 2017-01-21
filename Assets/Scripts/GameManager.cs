using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static GameManager instance;

    public bool gameover = false;

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
		
	}
}
