using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ping : MonoBehaviour {

    public RectTransform canvas;
    public RectTransform ammoBar;
    public Image ammoImage;
    public Image ammoContainer;

    public int maxCapacity = 15;
    public int ammo;
    public int smallPingCost = 1;
    public int largePingCost = 3;

    private const int FACE_LEFT = 0;
    private const int FACE_RIGHT = 1;
    private int cooldown = 0;
    private float charge = 0;
    private int direction = 0;
    public Transform smallPingSprite;
    public Transform largePingSprite;
    public GameObject enemyPing;

    private bool flash = false;
	// Use this for initialization
	void Start () {
        ammo = maxCapacity;
	}
	
	// Update is called once per frame
	void Update () {
        readKeys();
        //newRect.xMax = (maxCapacity - ammo) / (float)maxCapacity
        Color barColor = Color.Lerp(Color.red, Color.green, ammo / (float)maxCapacity);
        barColor.a = 0.5f;
        ammoBar.sizeDelta = new Vector2((ammo - maxCapacity) / (float)maxCapacity * canvas.rect.width, 40);
        ammoImage.color = barColor;
        
	}

    void readKeys()
    {
        if(Input.GetButton("Fire1"))
        {
            charge += Time.deltaTime;
        }
        if(Input.GetButtonUp("Fire1"))
        {
            if(charge > .4f)
            {
                if(ammo >= largePingCost)
                {
                    ammo -= largePingCost;
                    Instantiate(largePingSprite, transform.position, Quaternion.identity);
                    GameObject triggerPing = Instantiate(enemyPing, transform.position, Quaternion.identity);
                    triggerPing.tag = "LargePing";
                }
                else
                {
                    //out of charge effect
                    StartCoroutine("FlashBar");
                }

                charge = 0;
            }
            else if(charge > 0)
            {
                if(ammo >= smallPingCost)
                {
                    ammo -= smallPingCost;
                    Quaternion rot = smallPingSprite.transform.rotation;
                    if (direction == FACE_LEFT)
                    {
                        Debug.Log("FLIPPED PING");
                        rot.eulerAngles = new Vector3(0, 0, -90);
                    }

                    Instantiate(smallPingSprite, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
                                                             rot);
                    GameObject triggerPing = Instantiate(enemyPing, transform.position, Quaternion.identity);
                    triggerPing.tag = "SmallPing";
                }
                else
                {
                    //out of charge effect
                    StartCoroutine("FlashBar");
                }
                
            }
            charge = 0;
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            direction = FACE_LEFT;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            direction = FACE_RIGHT;
        } 
    }

    IEnumerator FlashBar()
    {
        Debug.Log("Flashing");
        if(!flash)
        {
            flash = true;
            Color oldColor = ammoContainer.color;
            Color newColor = Color.red;
            newColor.a = ammoContainer.color.a;

            for (int i = 0; i < 3; i++)
            {
                ammoContainer.color = newColor;
                yield return new WaitForSeconds(0.2f);
                ammoContainer.color = oldColor;
                yield return new WaitForSeconds(0.2f);
            }
            flash = false;
        }
        
        

    }
}
