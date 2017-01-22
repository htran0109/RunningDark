using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerWhenLow : MonoBehaviour {

    public GameObject prefab;
    private GameObject powerup;
    private ParticleSystem ps;

	// Use this for initialization
	void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Ping pingsc = other.gameObject.GetComponent<Ping>();
            if(pingsc.ammo < pingsc.maxCapacity / 2)
            {
                if(!powerup)
                {
                    powerup = Instantiate(prefab, transform.position, Quaternion.identity);
                    ps.Play();
                }
            }
        }
    }
}
