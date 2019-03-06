using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : Entity {

    public Transform raycastPoint;
    public float maxFallDistance = 1;
    public LayerMask groundLayer;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	


	// Update is called once per frame
	void Update ()  // When enemy hit the collider/edges and runs back to the other side.
    {

        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, Vector2.down, maxFallDistance, groundLayer);

        if (!hit || !hit.collider)
        {

            horizontal = -horizontal;
        }

        if (!dead)
        {
            move();
        }


    }


    public override void Dead()
    {
    anim.SetBool("Death", true);
    base.Dead();
    Jump();
        GetComponent<BoxCollider2D>().enabled = false;

    }

}
