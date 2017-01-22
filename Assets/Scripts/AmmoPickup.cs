using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {
    AudioSource sfx;
    public Ping ping;
    public int ammoCount = 3;
    // Use this for initialization
    void Start () {
        sfx = GetComponent<AudioSource>();
        ping = GameObject.FindGameObjectWithTag("Player").GetComponent<Ping>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("get ammo");
            if(ping.ammo + ammoCount <= ping.maxCapacity)
            {
                ping.ammo += 3;
            }
            else
            {
                ping.ammo = ping.maxCapacity;
            }
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            sfx.Play();
            Destroy(gameObject, sfx.clip.length);


        }
    }
}
