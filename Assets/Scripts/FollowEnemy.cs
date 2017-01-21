using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {


    public const float STALK_SPEED = 50;
    public const float DASH_SPEED = 100;
    private float moving = 0;
    private float speed = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moving -= Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name + "Hit");

        if(coll.gameObject.tag == "SmallPing")
        {
            stalk();
        }
        else if(coll.gameObject.tag == "LargePing") 
        {
            dash();
        }
    }

    void stalk()
    {
        moving = 2;
        speed = STALK_SPEED;
    }

    void dash()
    {
        moving = 2;
        speed = DASH_SPEED;
    }
}
