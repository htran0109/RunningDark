using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPing : MonoBehaviour {

    public float duration = 5.0f;
    public float startScale = 1.0f;
    public float endScale = 1.5f;
    public float distance = 5.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        startPosition = transform.position;
        endPosition = transform.position + -transform.up * distance;
        Debug.Log(startPosition + " to " + endPosition);
    }
	
	// Update is called once per frame
	void Update () {
        float progress = (Time.time - startTime) / duration;
        if (progress > 1.0f)
        {
            Debug.Log("Done big ping");
            Destroy(gameObject);
        }
        float scale = Mathf.Lerp(startScale, endScale, progress);
        Vector3 pos = Vector3.Lerp(startPosition, endPosition, progress);
        transform.localScale = new Vector3(scale, scale, scale);
        transform.position = pos;
    }
}
