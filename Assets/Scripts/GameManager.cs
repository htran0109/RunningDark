using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject cameraObj;
    public GameObject player;
    public bool gameover = false;
    public Vector3 checkpoint = new Vector3(0,0,0);

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	// Use this for initialization
	void Start () {
        cameraObj = GameObject.Find("Main Camera");
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
            if (Input.GetKeyDown("r"))
            {
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<SpriteRenderer>().enabled = true;
                cameraObj.transform.SetParent(player.transform);
                
                player.transform.position = checkpoint;
                cameraObj.transform.position = checkpoint - new Vector3(0,0,10);
                gameover = false;
            }
        }
        
	}
}
