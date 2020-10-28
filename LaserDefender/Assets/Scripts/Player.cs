﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        //var is a generic variable which changes its type according to the value
        //deltaX is the difference th ePlayer ship moves in the x-axis
        var deltaX = Input.GetAxis("Horizontal");

        //newXPosition = current pos in x + difference moved in x axis
        var newXPos = transform.position.x + deltaX;

        //move the player ship on the x-axis only (newXPos)
        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
