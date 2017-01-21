using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject player;

    AudioSource sfx;
    AudioClip shootsfx;

    LineRenderer lr;


	// Use this for initialization
	void Start () {
        lr = gameObject.GetComponent<LineRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire2"))
        {
            StartCoroutine("Shoot", player.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "SmallPing")
        {

        }
        else if (other.gameObject.tag == "LargePing")
        {

        }
    }

    IEnumerator Shoot(Vector3 target)
    {
        lr.enabled = true;

        RaycastHit2D hit;
        Debug.DrawRay(transform.position, (target - transform.position) * 10.0f, Color.green, 0.1f);
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2((target - transform.position).x, (target - transform.position).y), 10.0f);
        //if hit object
        if (hit.collider != null)
        {
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(1, transform.position + (target - transform.position) * 10.0f);
        }
        lr.SetPosition(0, transform.position);
        
        lr.material.color = Color.red;
        lr.material.color = Color.red;

        yield return new WaitForSeconds(1.0f);
        //sfx.clip = shootsfx;
        lr.material.color = Color.white;
        lr.material.color = Color.white;

        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        


    }
}
