using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public float targetAlpha = 0;
    public float startAlpha = 0;
    public float startTime = 0;


    bool fadeIn = false;

    public float fadeInTime = 0.1f;
    public float fadeOutTime = 2;
    

    private float visibility = 0;
    private float currAlpha = 0;
    
    public bool isClimbable = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float fadeInProgress = (Time.time - startTime) / fadeInTime;
        float fadeOutProgress = (Time.time - startTime) / fadeOutTime;
        if (fadeIn)
        {
            currAlpha = Mathf.Lerp(startAlpha, targetAlpha, fadeInProgress);
            if(fadeInProgress >= 1)
            {
                fadeIn = false;
                targetAlpha = 0;
                startAlpha = currAlpha;
                startTime = Time.time;
            }   
        }
        else
        {
            currAlpha = Mathf.Lerp(startAlpha, targetAlpha, fadeOutProgress);
           
        }
		/*if(visibility > 0 )
        {
            visibility -= 170 * Time.deltaTime;
            //Debug.Log(visibility);
        }*/
        Color temp = gameObject.GetComponent<SpriteRenderer>().color;
        temp.a = currAlpha;
        gameObject.GetComponent<SpriteRenderer>().color = temp;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
            //Debug.Log(coll.gameObject.name + "Hit" );
            if(coll.gameObject.tag == "GroundPing")
            {
            //Debug.Log("Illuminated");
            //visibility = 255;
            startAlpha = currAlpha;
            targetAlpha = 1;
            startTime = Time.time;
            fadeIn = true;
            }
    }
}
