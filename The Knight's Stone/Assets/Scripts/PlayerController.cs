using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float moveSpeed = 1.0f;

    private Animator anim;

    private bool moving;
    private Vector2 lastDirection;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// Update is called once per frame
    void FixedUpdate () {

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
            moving = false;
        else
            moving = true;

        if (horizontal > 0.1f || horizontal < -0.1f) {
            lastDirection = new Vector2(horizontal, 0.0f);
        }

        if (vertical > 0.1f || vertical < -0.1f) {
            lastDirection = new Vector2(0.0f,vertical);
        }

        Vector2 targetVelocity = new Vector2(horizontal, vertical);

        GetComponent<Rigidbody2D>().velocity = targetVelocity * moveSpeed;

        anim.SetFloat("X", horizontal);
        anim.SetFloat("Y", vertical);
        anim.SetBool("moving",moving);
        anim.SetFloat("LastX",lastDirection.x);
        anim.SetFloat("LastY",lastDirection.y);
	}
}
