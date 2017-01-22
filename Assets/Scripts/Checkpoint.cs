using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    AudioSource sfx;
    BoxCollider2D bc;
    public PointAtNearestCheckpoint pointer;
    public Ping ping;
    ParticleSystem ps;

	// Use this for initialization
	void Start () {
        sfx = gameObject.GetComponent<AudioSource>();
        bc = gameObject.GetComponent<BoxCollider2D>();
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
        ping = GameObject.FindGameObjectWithTag("Player").GetComponent<Ping>();
        pointer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PointAtNearestCheckpoint>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Setting Checkpoint");
            GameManager.instance.checkpoint = transform.position;
            StartCoroutine("Collect");

        }
    }

    IEnumerator Collect()
    {
        ping.ammo = ping.maxCapacity;
        bc.enabled = false;
        sfx.Play();
        gameObject.tag = "Untagged";
        pointer.Invoke("point", 0.0f);
        ps.Stop();
        

        Destroy(gameObject, 1.0f);
        yield return null;
    }
}
