using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;

    public LayerMask ground;

    public float positionRadius;

    public Transform playerPos1;
    public Transform playerPos2;

    private bool isGrounded1 = false;
    private bool isGrounded2 = false;
    private bool canDoubleJump1;
    private bool canDoubleJump2;

    Animator animator1;
    Animator animator2;
    

    
    private void Awake()
    {
        Input.multiTouchEnabled = true;
    }
    private void Start()
    {
        animator1 = player1.GetComponent<Animator>();
        animator2 = player2.GetComponent<Animator>();
    }
    private void Update()
    {
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
            animator1.enabled = true;
            animator1.Play("Jump");
        }
        else
        {
            if (canDoubleJump1)
            {
                
                canDoubleJump1 = false;
            }
        }
    }
    public void JumpR()
    {
        if (isGrounded2)
        {
            animator2.enabled = true;
            animator2.Play("FixedRagdollJump2");    
        }
        else
        {
            if (canDoubleJump2)
            {
                
                canDoubleJump2 = false;
            }
        }

    }
}
