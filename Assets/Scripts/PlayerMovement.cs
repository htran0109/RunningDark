﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public float animSpeedThresh = 2;
    public float jumpSpeed = 10;
    public float airSpeed = 5;
    
    public float distToGround;
    private float horzSize;
    private bool facingRight;

    public CircleCollider2D cc;
    public BoxCollider2D bb;
    private Rigidbody2D rb2d;
    public Animator ani;
    private SpriteRenderer sr;

    private bool jump = false;
    public bool climbing = false;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CircleCollider2D>();
        bb = gameObject.GetComponent<BoxCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        distToGround = cc.bounds.extents.y/2 + bb.bounds.extents.y;
        horzSize = cc.bounds.extents.x;
        Debug.Log("dist to ground: " + distToGround);
	}
	
	// Update is called once per frame
	void Update () {
        if(!GameManager.instance.gameover)
        {
            if (!climbing)
            {
                if (rb2d.velocity.y < 0 && IsGrounded())
                {
                    jump = false;
                }
                if (IsGrounded())
                {
                    float horz = Input.GetAxis("Horizontal");
                    rb2d.velocity = new Vector2(horz * speed, rb2d.velocity.y);
                }
                else
                {
                    float horz = Input.GetAxis("Horizontal");
                    
                    if(horz < 0 != rb2d.velocity.x < 0)
                    {
                        Debug.Log("Slowing Air" + rb2d.velocity);
                        //rb2d.velocity = new Vector2(rb2d.velocity.x / (1 + Time.deltaTime), rb2d.velocity.y);
                        rb2d.AddForce(new Vector2(horz * airSpeed, 0));

                    }
                    /*else if(horz == 0 || rb2d.velocity.x == 0) {

                    }
                    else if( horz < 0 == rb2d.velocity.x <0)
                    {
                        Debug.Log("Speeding Air");
                        rb2d.velocity = new Vector2(rb2d.velocity.x + Mathf.Min((1/rb2d.velocity.x * 10f * Time.deltaTime), speed/4), rb2d.velocity.y);
                    }*/
                }
            

                // transform.Translate(horz * speed * Time.deltaTime, 0, 0);

                if (IsGrounded() && Input.GetButtonDown("Jump"))
                {
                    Debug.Log("JUMP");
                    ani.SetTrigger("Jumped");
                    jump = true;
                    rb2d.velocity = rb2d.velocity + new Vector2(0, jumpSpeed);
                }
            }
            else
            {
                /*if (!jump)
                {
                    rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                }*/
            }
        }
        
        animate();
		
	}

    public bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up * (distToGround + 0.1f), Color.red, 1);
        Debug.DrawRay(transform.position + new Vector3(horzSize, 0, 0), -Vector3.up * (distToGround + 0.1f), Color.red, 0.2f);
        Debug.DrawRay(transform.position - new Vector3(horzSize, 0, 0), -Vector3.up * (distToGround + 0.1f), Color.red, 0.2f);
        int layerMask = (1 << LayerMask.NameToLayer("Player")) | (1 << LayerMask.NameToLayer("GroundPing")) | (1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("PickUp")); ;
        layerMask = ~layerMask;
        bool ret1 = Physics2D.Raycast(transform.position + new Vector3(horzSize - 0.05f, 0, 0), -Vector3.up, distToGround + 0.1f, layerMask);
        bool ret2 = Physics2D.Raycast(transform.position - new Vector3(horzSize - 0.05f, 0, 0), -Vector3.up, distToGround + 0.1f, layerMask);
        ani.SetBool("Grounded", ret1 || ret2);
        return ret1 || ret2;
    }

    void animate()
    {
        if(Mathf.Abs(rb2d.velocity.x) > animSpeedThresh)
        {
            
            ani.SetBool("Moving", true);
        }
        else
        {
            
            ani.SetBool("Moving", false);
        }
        float horz = Input.GetAxis("Horizontal");
        if (horz>0 && facingRight)
        {
            flip();
        }
        else if (horz< 0 && !facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        sr.flipX = !sr.flipX;
        facingRight = !facingRight;
    }

    /*void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.name + "Hit by player");
        if(coll.gameObject.tag == "Ground")
        {
            Debug.Log("Block Found");
            Block climbBlock = coll.gameObject.GetComponent<Block>();
            Debug.Log(!IsGrounded() + ": " + climbBlock.isClimbable);
            if (!IsGrounded() && climbBlock.isClimbable == true && jump)
            {
                Debug.Log("Climbing");
                ani.SetTrigger("Climbed");
                StartCoroutine("climbMove", coll.gameObject);
            }
        }
    }

    IEnumerator climbMove(GameObject obj)
    {
        Debug.Log("In climbing method");
        climbing = true;
        cc.enabled = false;
        bb.enabled = false;
        Vector3 currPos = transform.position;
        BoxCollider2D blockColl = obj.GetComponent<BoxCollider2D>();
        float heightToGround = blockColl.bounds.extents.y;
        Vector3 endPos = new Vector3(obj.transform.position.x, obj.transform.position.y + heightToGround + distToGround);
        for (float i = 0; i < 50; i++)
        {
            Debug.Log("Still Climbing");
            transform.position = Vector3.Lerp(currPos, endPos,  i / 49);
            yield return null;
        }
        cc.enabled = true;
        bb.enabled = true;
        climbing = false;
    }*/
}
