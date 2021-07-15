using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Rigidbody2D[] rb;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
       
    //    if (collision.gameObject.CompareTag("body1"))
    //    {
           

    //        for (int i = 0; i < rb.Length; i++)
    //        {
                
    //            //Stop Moving/Translating
    //            rb[i].velocity = Vector2.zero;
    //            //Stop rotating
    //            rb[i].angularVelocity = 0;
    //        }

    //    }
    //}
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("body1"))
    //    {


    //        for (int i = 0; i < rb.Length; i++)
    //        {

    //            //Stop Moving/Translating
    //            //rb[i].velocity = Vector2.zero;
    //            //Stop rotating
    //            rb[i].angularVelocity = 0;
    //        }

    //    }
    //}
}