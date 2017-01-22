using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtNearestCheckpoint : MonoBehaviour {

    Vector3 target;
    public float duration = 0.2f;
    private float startTime;
    Quaternion startRot;
    Quaternion endRot;

	// Use this for initialization
	void Start () {
        
        point();
	}
	
	// Update is called once per frame
	void Update () {
        float progress = (Time.time - startTime) / duration;

        transform.LookAt(target);
    }

    void point()
    {
        
        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        
        float mindist = Mathf.Infinity;
        if(checkpoints.Length != 0)
        {
            foreach (GameObject checkpoint in checkpoints)
            {
                if (Vector3.SqrMagnitude(checkpoint.transform.position - transform.position) < mindist)
                {
                    mindist = Vector3.SqrMagnitude(checkpoint.transform.position - transform.position);
                    target = checkpoint.transform.position;
                    //endRot = Quaternion.LookRotation(checkpoint.transform.position - transform.position);
                }
            }
            //startTime = Time.time;
            //startRot = transform.rotation;
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
