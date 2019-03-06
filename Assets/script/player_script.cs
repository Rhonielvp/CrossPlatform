using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : Entity {
   
    public int maxJumps = 2;
   
   
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        move();

        anim.SetBool("idle", Mathf.Abs(horizontal) < 0.1f);
        anim.SetBool("jumpCount", isGrounded);


        if (Input.GetButtonDown("Fire1"))  //Playter to shoot. AddForce if needed to add force when player shoots.
        {
            ShootProjectile();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
    
    }
    public override void move()
    {
        horizontal = Input.GetAxis("Horizontal");
        base.move();
    }



}
