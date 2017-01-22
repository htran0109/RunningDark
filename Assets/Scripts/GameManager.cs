﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject cameraObj;
    public GameObject player;
    public GameObject respParticle;
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
            Destroy(instance.gameObject);
            Debug.LogError("Singleton Goofed");
        }
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameover)
        {
            setGameOverScreen(true);
            if (Input.GetKeyDown("r"))
            {
                setGameOverScreen(false);
                sfx.clip = reset;
                sfx.Play();
                player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<Ping>().ammo = player.GetComponent<Ping>().maxCapacity;
                cameraObj.transform.SetParent(player.transform);
                
                player.transform.position = checkpoint;
                cameraObj.transform.position = checkpoint - new Vector3(0,0,10);
                Instantiate(respParticle, player.transform.position, Quaternion.identity);
                player.GetComponent<BoxCollider2D>().enabled = true;
                player.GetComponent<CircleCollider2D>().enabled = true;
                Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();
                rb2d.isKinematic = false;
                rb2d.velocity = Vector2.zero;
                
                gameover = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelOne");
            setGameOverScreen(false);
        }
        
	}

    void setGameOverScreen(bool gameover)
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameOverText");
        go.GetComponent<Image>().enabled = gameover;
        Text[] texts = go.GetComponentsInChildren<Text>();
        foreach(Text text in texts)
        {
            text.enabled = gameover;
        }

    }
}
