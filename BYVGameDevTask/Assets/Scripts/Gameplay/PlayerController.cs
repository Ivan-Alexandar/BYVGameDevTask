using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;


    public GameObject GunFire;
    public GameObject GunFireM;

    public GameObject[] hp1;
    public GameObject[] hp2;

    public GameObject body1;
    public GameObject body2;
    public GameObject bullet;
    public GameObject bulletM;
    public Transform gunL;
    public Transform gunR;


    
    public LayerMask ground;

    public float positionRadius;

    public float jumpForce;
    public float doubleJumpForce;
    public Transform playerPos1;
    public Transform playerPos2;

    private bool isGrounded1 = false;
    private bool isGrounded2 = false;
    private bool canDoubleJump1;
    private bool canDoubleJump2;

    Animator animator1;
    Animator animator2;

    private Rigidbody2D rb1;
    private Rigidbody2D rb2;



    private void Awake()
    {
        Input.multiTouchEnabled = true;
    }
    private void Start()
    {
        animator1 = player1.GetComponent<Animator>();
        animator2 = player2.GetComponent<Animator>();
        rb1 = body1.GetComponent<Rigidbody2D>();
        rb2 = body2.GetComponent<Rigidbody2D>();


        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }
    private void Update()
    {
        if (!GunFire.GetComponent<ParticleSystem>().isPlaying)
        {
            
        }
        isGrounded1 = Physics2D.OverlapCircle(playerPos1.position, positionRadius, ground);
        isGrounded2 = Physics2D.OverlapCircle(playerPos2.position, positionRadius, ground);

        if (isGrounded1)
        {
            animator1.SetBool("CanJump", true);
            canDoubleJump1 = true;
        }
        if (isGrounded2)
        {
            animator2.SetBool("CanJump", true);
            canDoubleJump2 = true;
        }
    }
    public void JumpL()
    {


        if (isGrounded1)
        {
            rb1.velocity = new Vector2(rb1.velocity.x, jumpForce*Time.deltaTime);
            animator1.SetBool("CanJump", false);
            animator1.SetTrigger("jump");
            //rb1.AddForce(Vector2.up * jumpForce*Time.deltaTime, ForceMode2D.Force);

        }
        else
        {
            if (canDoubleJump1)
            {
                //rb1.velocity = new Vector2(rb1.velocity.x, jumpForce*Time.deltaTime);
                rb1.AddForce(Vector2.up * doubleJumpForce * Time.deltaTime, ForceMode2D.Force);
                canDoubleJump1 = false;
            }
        }
    }
    public void JumpR()
    {
       
        if (isGrounded2)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpForce*Time.deltaTime);
            animator2.SetBool("CanJump", false);
            animator2.Play("Jump");
        }
        else
        {
            if (canDoubleJump2)
            {
                rb1.AddForce(Vector2.up * doubleJumpForce * Time.deltaTime, ForceMode2D.Force);
                canDoubleJump2 = false;
            }
        }
    }
    public void ShootL()
    {
        SoundManager.PlaySound("Gunshot");
        Instantiate(GunFire, gunL.position, Quaternion.identity);
        Instantiate<GameObject>(bullet, gunL.position, Quaternion.identity) ;
        //bullet.GetComponent<Rigidbody2D>().velocity =   new Vector2(10,0);
        


    }
    public void ShootR()
    {
        SoundManager.PlaySound("Gunshot");
        Instantiate(GunFireM, gunR.position, Quaternion.identity);
        Instantiate(bulletM, gunR.position, Quaternion.identity);
    }



}



