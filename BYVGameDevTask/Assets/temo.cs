﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, transform.position.y), ForceMode2D.Force);
    }
}
