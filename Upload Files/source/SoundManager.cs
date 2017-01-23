using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    private AudioSource music;
    public AudioClip bgm1;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
    void Start () {
        music = GetComponent<AudioSource>();
        if (instance != null)
        {
            Debug.LogError("Singleton Goofed");
        }
        instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
