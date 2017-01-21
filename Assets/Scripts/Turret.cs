using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject player;
    public GameObject laser;
    public GameObject spark;

    public float burstFireDelay = 0.3f;

    public float laserRange = 10.0f;
    
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if(Input.GetButtonDown("Fire2"))
        {
            StartCoroutine("Burst", player.transform.position);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + "Hit" + other.gameObject.tag);

        if (other.gameObject.tag == "SmallPing")
        {
            StartCoroutine("Shoot", player.transform.position);
        }
        else if (other.gameObject.tag == "LargePing")
        {
            StartCoroutine("Burst", player.transform.position);
        }
    }

    IEnumerator Burst(Vector3 target)
    {
        StartCoroutine("Shoot", player.transform.position);
        yield return new WaitForSeconds(burstFireDelay);
        StartCoroutine("Shoot", player.transform.position);
        yield return new WaitForSeconds(burstFireDelay);
        StartCoroutine("Shoot", player.transform.position);
    }

    IEnumerator Shoot(Vector3 target)
    {
        GameObject shot = Instantiate(laser, transform);
        LineRenderer lr = shot.GetComponent<LineRenderer>();
        AudioSource sfx = shot.GetComponent<AudioSource>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.enabled = true;
        lr.material = new Material(Shader.Find("Particles/Additive (Soft)"));

        RaycastHit2D hit;
        Debug.DrawRay(transform.position, (target - transform.position) * 10.0f, Color.green, 0.1f);
        int layerMask = (1 << 8) | (1<<9) | (1 << 10);
        layerMask = ~layerMask;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2((target - transform.position).x, (target - transform.position).y), laserRange, layerMask);
        //if hit object
        if (hit.collider != null)
        {
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(1, transform.position + (target - transform.position) * laserRange);
        }
        lr.SetPosition(0, transform.position);

        Color laserColor;
        for (int i = 0; i < 10; i++)
        {
            laserColor = Color.red;
            laserColor.a = i / 10.0f;
            Debug.Log("alpha: " + laserColor.a);
            lr.startColor = laserColor;
            lr.endColor = laserColor;
            yield return new WaitForSeconds(0.1f);
        }


        layerMask = (1 << 9) | (1 << 10);//ignore ground ping layer and self
        layerMask = ~layerMask;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2((target - transform.position).x, (target - transform.position).y), 10.0f, layerMask);
        sfx.Play();
        if(hit.collider)
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Hit Player");
            }
            Instantiate(spark, hit.point, Quaternion.identity);
        }
        laserColor = Color.white;
        lr.startColor = laserColor;
        lr.endColor = laserColor;

        yield return new WaitForSeconds(0.1f);
        lr.enabled = false;
        Destroy(shot);
        


    }
}
