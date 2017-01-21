using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePing : MonoBehaviour {

    public float duration = 5.0f;
    public float startScale = 1.0f;
    public float endScale = 7.0f;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float progress = (Time.time - startTime) / duration;
        if (progress > 1)
        {
            Debug.Log("Done big ping");
            Destroy(gameObject);
        }
        float scale = Mathf.Lerp(startScale, endScale, progress);
        transform.localScale = new Vector3(scale, scale, scale);

        

	}
}
