using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toCredits()
    {

        Debug.Log("Switching scenes");
        SceneManager.LoadScene("Credits");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
