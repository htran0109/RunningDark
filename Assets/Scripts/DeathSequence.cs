using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSequence : MonoBehaviour
{

    public GameObject deathMovement;
    public GameObject cameraObj;

    public AudioClip death;

    
  

    AudioSource audio;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {

        audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Player;

    public void Die()
    {
        audio.clip = death;
        audio.Play();


        int mask = 0;
        mask |= (1 << LayerMask.NameToLayer("Player"));
        mask |= (1 << LayerMask.NameToLayer("Ground"));
        

        mask = ~mask;
        Debug.Log("Hi");
        // Physics2D.IgnoreLayerCollision(8, 11, true);


        cameraObj.transform.parent = null;

        GetComponent<SpriteRenderer>().enabled = false;
        GameManager.instance.gameover = true;



    }
}

