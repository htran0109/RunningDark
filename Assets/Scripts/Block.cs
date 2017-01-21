using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private float visibility = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(visibility > 0 )
        {
            visibility -= 170 * Time.deltaTime;
            Debug.Log(visibility);
        }
        Color temp = gameObject.GetComponent<SpriteRenderer>().color;
        temp.a = visibility/255;
        gameObject.GetComponent<SpriteRenderer>().color = temp;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name + "Hit" );
        if(coll.gameObject.tag == "Ping")
        {
            Debug.Log("Illuminated");
            visibility = 255;
        }
    }
}
