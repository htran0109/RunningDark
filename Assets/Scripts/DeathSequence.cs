using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSequence : MonoBehaviour
{

    public GameObject deathMovement;
    public GameObject cameraObj;
    public GameObject deathSpark;
    public AudioClip death;
    public BoxCollider2D bb;
    public CircleCollider2D cc;
    public Rigidbody2D playRb2d;

    
  

    AudioSource audio;
    Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {

        audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        bb = gameObject.GetComponent<BoxCollider2D>();
        cc = gameObject.GetComponent<CircleCollider2D>();
        playRb2d = gameObject.GetComponent<Rigidbody2D>();

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

        Instantiate(deathSpark, transform.position, Quaternion.identity);
        mask = ~mask;
        Debug.Log("Hi");
        cc.enabled = false;
        bb.enabled = false;
        playRb2d.isKinematic = true;
        playRb2d.velocity = Vector2.zero;
        // Physics2D.IgnoreLayerCollision(8, 11, true);


        cameraObj.transform.parent = null;

        GetComponent<SpriteRenderer>().enabled = false;
        GameManager.instance.gameover = true;



    }
}

