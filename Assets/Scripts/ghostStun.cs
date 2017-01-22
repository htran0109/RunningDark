using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostStun : MonoBehaviour {



	// Use this for initialization
	void Start () {
  

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisableChildren()
    {
        foreach (Transform child in transform)
        {
            gameObject.SetActive(false);
        }
    }

    public void EnableChildren()
    {
        foreach (Transform child in transform)
        {
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LargePing")
        {
            DisableChildren();
            Debug.Log("Hit");
            Invoke("EnableChildren", 2);
        }
    }
}
