using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void play()
    {
        SceneManager.LoadScene("LevelOne");
        SceneManager.UnloadSceneAsync("Main Menu");
    }
}
