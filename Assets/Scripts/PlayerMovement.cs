using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public float animSpeedThresh = 2;
    public float jumpSpeed = 10;

    private float distToGround;
    private float horzSize;
    private bool facingRight;

    private CircleCollider2D cc;
    private Rigidbody2D rb2d;
    private Animator ani;

    private bool jump = false;

	// Use this for initialization
	void Start () {
        cc = gameObject.GetComponent<CircleCollider2D>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponent<Animator>();
        distToGround = cc.bounds.extents.y;
        horzSize = cc.bounds.extents.x;
        Debug.Log("dist to ground: " + distToGround);
	}
	
	// Update is called once per frame
	void Update () {
        if(!GameManager.instance.gameover)
        {
            if (IsGrounded())
            {
                if (rb2d.velocity.y < 0)
                {
                    jump = false;
                }
                float horz = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(horz * speed, rb2d.velocity.y);

                // transform.Translate(horz * speed * Time.deltaTime, 0, 0);

                if (Input.GetButtonDown("Jump"))
                {
                    Debug.Log("JUMP");
                    jump = true;
                    rb2d.velocity = rb2d.velocity + new Vector2(0, jumpSpeed);
                }
            }
            else
            {
                if (!jump)
                {
                    rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                }
            }
        }
        
        animate();
		
	}

    bool IsGrounded()
    {
        //Debug.DrawRay(transform.position, -Vector3.up * (distToGround + 0.1f), Color.red, 1);
        Debug.DrawRay(transform.position + new Vector3(horzSize, 0, 0), -Vector3.up * (distToGround + 0.1f), Color.red, 0.2f);
        Debug.DrawRay(transform.position - new Vector3(horzSize, 0, 0), -Vector3.up * (distToGround + 0.1f), Color.red, 0.2f);
        int layerMask = (1 << 8) | (1 << 9);
        layerMask = ~layerMask;
        bool ret1 = Physics2D.Raycast(transform.position + new Vector3(horzSize - 0.05f, 0, 0), -Vector3.up, distToGround + 0.1f, layerMask);
        bool ret2 = Physics2D.Raycast(transform.position - new Vector3(horzSize - 0.05f, 0, 0), -Vector3.up, distToGround + 0.1f, layerMask);
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
        if(rb2d.velocity.x > 0 && facingRight)
        {
            flip();
        }
        else if (rb2d.velocity.x < 0 && !facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
