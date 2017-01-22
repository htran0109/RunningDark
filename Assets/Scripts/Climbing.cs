using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {

    PlayerMovement playMov;
	// Use this for initialization
	void Start () {
        playMov = GetComponentInParent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D coll)
    {
        //Debug.Log(coll.gameObject.name + "Hit by player");
        if (coll.gameObject.tag == "Ground")
        {
            Debug.Log("Block Found");
            Block climbBlock = coll.gameObject.GetComponent<Block>();
            Debug.Log(!playMov.IsGrounded() + ": " + climbBlock.isClimbable);
            if (!playMov.IsGrounded() && climbBlock.isClimbable == true)
            {
                Debug.Log("Climbing");
                playMov.ani.SetTrigger("Climbed");
                StartCoroutine("climbMove", coll.gameObject);
            }
        }
    }

    IEnumerator climbMove(GameObject obj)
    {
        Debug.Log("In climbing method");
        playMov.climbing = true;
        playMov.cc.enabled = false;
        playMov.bb.enabled = false;
        Vector3 currPos = playMov.transform.position;
        BoxCollider2D blockColl = obj.GetComponent<BoxCollider2D>();
        float heightToGround = blockColl.bounds.extents.y;
        Vector3 endPos = new Vector3(obj.transform.position.x, obj.transform.position.y + heightToGround + playMov.distToGround);
        for (float i = 0; i < 50; i++)
        {
            //Debug.Log("Still Climbing");
            playMov.transform.position = Vector3.Lerp(currPos, endPos, i / 49);
            yield return null;
        }
        playMov.cc.enabled = true;
        playMov.bb.enabled = true;
        playMov.climbing = false;
    }
}
