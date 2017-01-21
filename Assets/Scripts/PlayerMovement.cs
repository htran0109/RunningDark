﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public float jumpSpeed = 10;

    private float distToGround;
    private float horzSize;

    private CircleCollider2D cc;
    private Rigidbody2D rb2d;

    private bool jump = false;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CircleCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        distToGround = cc.bounds.extents.y;
        horzSize = cc.bounds.extents.x;
        Debug.Log("dist to ground: " + distToGround);
	}
	
	// Update is called once per frame
	void Update () {
        if(IsGrounded())
        {
            if(rb2d.velocity.y < 0)
            {
                jump = false;
            }
            float horz = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(horz * speed, rb2d.velocity.y);
            
           // transform.Translate(horz * speed * Time.deltaTime, 0, 0);

            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("JUMP");
                jump = true;
                rb2d.velocity = rb2d.velocity + new Vector2(0, jumpSpeed);
            }
        }
        else
        {
            if(!jump)
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }
		
	}

    bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector3.up * (distToGround + 0.1f), Color.red, 1);
        Debug.DrawRay(transform.position + new Vector3(horzSize, 0, 0), -Vector3.up * (distToGround + 0.1f), Color.red, 0.2f);
        Debug.DrawRay(transform.position - new Vector3(horzSize, 0, 0), -Vector3.up * (distToGround + 0.1f), Color.red, 0.2f);
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        bool ret1 = Physics2D.Raycast(transform.position + new Vector3(horzSize, 0, 0), -Vector3.up, distToGround + 0.1f, layerMask);
        bool ret2 = Physics2D.Raycast(transform.position - new Vector3(horzSize, 0, 0), -Vector3.up, distToGround + 0.1f, layerMask);
        return ret1 || ret2;
    }
}
