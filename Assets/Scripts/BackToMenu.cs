using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void backToMenuCredits()
    {
      
        Debug.Log("Switching scenes");
        SceneManager.LoadScene("Main Menu");
        SceneManager.UnloadSceneAsync("Credits");
    }

    public void backToMenuInstructions()
    {
        Debug.Log("Switching scnese");
        SceneManager.LoadScene("Main Menu");
        SceneManager.UnloadSceneAsync("Instructions");
    }
}
