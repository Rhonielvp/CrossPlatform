using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour { //Change the void to Entity.



    //Movement
    public float speed;
    public float horizontal;

    public Animator anim;
    public Rigidbody2D rb;

    //Jump
    protected bool isGrounded;
    public int jumpCount = 0;
    public float JumpForce;
    private bool isAir;

    //Shoot
    public GameObject Fire1;
    public float projectileForce = 10;
    public Transform spawnPoint;
    public bool dead = false;

    float horizontalSpeed;
    float verticalSpeed;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GethorizontalSpeed()
    {
        return horizontalSpeed;
    }

    public float GetverticalSpeed()
    {
        return verticalSpeed;
    }

    public virtual void move()

    {

        horizontalSpeed = speed * Time.deltaTime * horizontal;
        transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime * horizontal;

        if (horizontal > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

           verticalSpeed = Time.deltaTime * rb.velocity.y;

        }

    }

    public virtual void Jump() //jumping

    {
        isGrounded = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, 1) * JumpForce, ForceMode2D.Impulse);
        jumpCount++;
    }

    public virtual void Dead()
    {

        dead = true;

    }


    public virtual void ShootProjectile() //Playter to shoot. AddForce if needed to add force when player shoots.
    {
        GameObject spawnedProjectile = Instantiate(Fire1, spawnPoint.position, Quaternion.identity);
        spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(projectileForce * transform.right, ForceMode2D.Impulse);
        rb.AddForce(-projectileForce * transform.right / 18, ForceMode2D.Impulse);
    }



     private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        isAir = false;
        jumpCount = 0;
        anim.SetBool("JumpForce", false);
    }


}
