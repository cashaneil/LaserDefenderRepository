using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        
    }

    //to destroy laser prefabs which 
    //we called an in-built function/method called OnTriggerEnter2D()
    private void OnTriggerEnter2D(Collider2D otherObject)// otherObject is a variable which you intialise
    {
        Destroy(otherObject.gameObject); //gameObject refers to the laser prefab
    }
}
