using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb2d;
    private void Start()
    {
        Vector2 force = new Vector2(100, 200);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce(force, ForceMode2D.Force);
    }

}
