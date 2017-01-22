using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject cameraObj;
    public GameObject player;
    public bool gameover = false;
    public Vector3 checkpoint = new Vector3(0,0,0);
    public AudioClip reset;
    private AudioSource sfx;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	// Use this for initialization
	void Start () {
        sfx = GetComponent<AudioSource>();
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
                sfx.clip = reset;
                sfx.Play();
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<SpriteRenderer>().enabled = true;
                cameraObj.transform.SetParent(player.transform);
                player.transform.position = checkpoint;
                gameover = false;
            }
        }
        
	}
}
