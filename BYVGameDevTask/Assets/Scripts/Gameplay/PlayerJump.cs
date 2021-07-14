using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    GameObject player1;
    [SerializeField]
    GameObject player2;
    //[SerializeField]
    //GameObject LegLp1;
    //[SerializeField]
    //GameObject LegRp1;
    //[SerializeField]
    //GameObject LegLp2;
    //[SerializeField]
    //GameObject LegRp2;

    public LayerMask ground;
    public float positionRadius;
    public Transform playerPos1;
    public Transform playerPos2;
    private bool isGrounded1 = false;
    private bool isGrounded2 = false;
    Animator animator1;
    Animator animator2;

    //private Timer timer1;
    //private Timer timer2;


    //int mousebuttoncount=0;

    
    private void Awake()
    {
        //timer1 = gameObject.AddComponent<Timer>();
        //timer2 = gameObject.AddComponent<Timer>();

        Input.multiTouchEnabled = true;
        //halfWidth = Screen.width / 2.0f;

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

        //if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        //{
        //    mousebuttoncount++;

        //    animator1.enabled = true;
        //    for (int i = 0; i < Input.touchCount || i < mousebuttoncount; i++)
        //    {
        //        Touch touch = Input.GetTouch(i);
        //        if (touch.position.x < halfWidth || Input.mousePosition.x < halfWidth)
        //        {

        //            animator1.Play(0);


        //        }
        //        else
        //        {
        //            animator2.enabled = true;
        //            animator2.Play(0);
        //        }


        //    }



        //}

    }
    public void JumpL()
    {

        if (isGrounded1)
        {

            //timer1.Duration = 1.583f;
            //timer1.Run();
            animator1.enabled = true;
            animator1.Play(0);
        }


    }
    public void JumpR()
    {
        if (isGrounded2)
        {
          
            //timer2.Duration = 1.583f;
            //timer2.Run();
            animator2.enabled = true;
            animator2.Play(0);
        }
       
    }
 



}
