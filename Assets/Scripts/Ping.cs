using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ping : MonoBehaviour {

    public int maxCapacity = 15;
    private int ammo;
    public int smallPingCost = 1;
    public int largePingCost = 3;

    private const int FACE_LEFT = 0;
    private const int FACE_RIGHT = 1;
    private int cooldown = 0;
    private float charge = 0;
    private int direction = 0;
    public Transform smallPingSprite;
    public Transform largePingSprite;
    public GameObject enemyPing;
	// Use this for initialization
	void Start () {
        ammo = maxCapacity;
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
                if(ammo >= largePingCost)
                {
                    ammo -= largePingCost;
                    Instantiate(largePingSprite, transform.position, Quaternion.identity);
                    GameObject triggerPing = Instantiate(enemyPing, transform.position, Quaternion.identity);
                    triggerPing.tag = "LargePing";
                }
                else
                {
                    //out of charge effect
                }
                

            }
            else if(charge > 0)
            {
                if(ammo >= smallPingCost)
                {
                    ammo -= smallPingCost;
                    Quaternion rot = smallPingSprite.transform.rotation;
                    if (direction == FACE_LEFT)
                    {
                        Debug.Log("FLIPPED PING");
                        rot.eulerAngles = new Vector3(0, 0, -90);
                    }

                    Instantiate(smallPingSprite, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
                                                             rot);
                    GameObject triggerPing = Instantiate(enemyPing, transform.position, Quaternion.identity);
                    triggerPing.tag = "SmallPing";
                }
                else
                {
                    //out of charge effect
                }
                
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
