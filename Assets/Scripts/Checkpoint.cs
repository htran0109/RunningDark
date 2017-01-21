using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    AudioSource sfx;

	// Use this for initialization
	void Start () {
        sfx = gameObject.GetComponent<AudioSource>();
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
        sfx.Play();
        for(int i = 0; i < 10; i++)
        {
            float scale = 1.0f - (i / 10.0f);
            transform.localScale = new Vector3(scale, scale, scale);
            transform.RotateAround(transform.position, Vector3.forward, 9.0f);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
