using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour {

    private int cooldown = 0;
    private float charge = 0;
    public Transform pingSprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        readKeys();
	}

    void readKeys()
    {
        if(Input.GetButton("Fire1"))
        {
            charge += Time.deltaTime;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            if(charge > 3.0f)
            {

            }
            else if(charge > 1.0f)
            {
                Instantiate(pingSprite, transform.position, Quaternion.identity);
            }
            charge = 0;
        }
    }
}
