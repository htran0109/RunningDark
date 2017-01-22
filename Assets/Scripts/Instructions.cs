using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toInstructions()
    {
        Debug.Log("Switching scenes");
        SceneManager.LoadScene("Instructions");
        SceneManager.UnloadSceneAsync("Main Menu");
    }
}
