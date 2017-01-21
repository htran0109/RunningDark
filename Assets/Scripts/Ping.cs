using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour {

    private const int FACE_LEFT = 0;
    private const int FACE_RIGHT = 1;
    private int cooldown = 0;
    private float charge = 0;
    private int direction = 0;
    public Transform smallPingSprite;
    public Transform largePingSprite;
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
            if(charge > .4f)
            {
                Instantiate(largePingSprite, transform.position, Quaternion.identity);
            }
            else if(charge > 0)
            {
                Quaternion rot = smallPingSprite.transform.rotation;
                if(direction == FACE_LEFT)
                {
                    Debug.Log("FLIPPED PING");
                    rot.eulerAngles = new Vector3(0, 0, -90);
                }

                Instantiate(smallPingSprite, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
                                                         rot);
            }
            charge = 0;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            direction = FACE_LEFT;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            direction = FACE_RIGHT;
        } 
    }
}
