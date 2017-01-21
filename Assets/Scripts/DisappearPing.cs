using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPing : MonoBehaviour {

    private float timer = 0;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 0.2f)
        {
            Destroy(this.gameObject);
        }
	}
}
