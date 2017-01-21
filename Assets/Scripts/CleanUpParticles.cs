using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpParticles : MonoBehaviour {



    private ParticleSystem ps;
	// Use this for initialization
	void Start () {
        ps = gameObject.GetComponent<ParticleSystem>();
        Destroy(gameObject, ps.main.duration);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
