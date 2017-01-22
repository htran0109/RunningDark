using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            Destroy(otherObject.gameObject);
            Destroy(gameObject);
        }
    }
}
