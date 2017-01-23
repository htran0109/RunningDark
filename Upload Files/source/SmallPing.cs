using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPing : MonoBehaviour
{

    public float duration = 5.0f;
    public float startScale = 1.0f;
    public float endScale = 7.0f;
    public float startAlpha = 0.2f;
    public float endAlpha = 0.0f;
    private float startTime;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (Time.time - startTime) / duration;
        if (progress > 1.0f)
        {
            Debug.Log("Done big ping");
            Destroy(gameObject);
        }
        float scale = Mathf.Lerp(startScale, endScale, progress);
        transform.localScale = new Vector3(scale, scale, scale);
        float alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
        Color newColor = sr.color;
        newColor.a = alpha;
        sr.color = newColor;




    }
}
