using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.VFX;

public class Player : MonoBehaviour
{
    //serialize field makes the variable editable from Unity Editor
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject laserPrefab; //a prefab, is something that isn't created with the start of the program, but only when needed. In the case, the laser spawns only when needed.
    [SerializeField] float laserSpeed = 15;
    [SerializeField] float LaserFiringTime = 0.2f;

    bool coroutineStarted = false;

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    //fireCoroutine is a coroutine OBJECT, not a coroutine itself
    Coroutine fireCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        //since this function is being called in start, it is only executed once, which is that the START of the game
        SetUpMoveBoundaries();
        //printCoroutine = StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    ////coroutine example
    //private IEnumerator PrintAndWait()
    //{
    //    print("Message 1");
    //    //pause, wait for 10 seconds and return control
    //    yield return new WaitForSeconds(10);
    //    print("Message 2 after 10 seconds");
    //}

    //fires lasers continuously every 'LaserFiringTime' seconds
    private IEnumerator FireContinuously()
    {
        while (true) //while coroutine is running
        {
            //create an instance called 'laser'
            //this instance is only temporary
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;//Quaternion.identity means the player current rotation
            //give the laser a velocity on the y axis
            //velocity value is applied according to var laserSpeed
            //the laser was given a body so that we are able to apply the laws of physics to it
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            //wait for 0.2 seconds
            yield return new WaitForSeconds(LaserFiringTime);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        //xMin = 0;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        //xMax = 1;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        //var is a generic variable which changes its type according to the value
        //deltaX is the difference the Player ship moves in the x-axis
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPosition = current pos in x + difference moved in x axis
        var newXPos = transform.position.x + deltaX;

        //clamp the value of newXPos between xMin (0) and xMax (1) in camera view
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newYPos = transform.position.y + deltaY;

        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //move the player ship on the x-axis only (newXPos)
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void Fire()
    {
        //if fire is pressed
        if(Input.GetButtonDown("Fire1"))
        {
            //if coroutine has not started
            //to avoid starting more than 1 coroutine
            if(!coroutineStarted) //if (coroutineStarted == false)
            {
                //code to start coroutine
                fireCoroutine = StartCoroutine(FireContinuously());
                //set coroutineStarted = true
                coroutineStarted = true;
            }
        }

        //if fire button is not pressed
        if (Input.GetButtonUp("Fire1"))
        {
            //code to start coroutine
            StopCoroutine(fireCoroutine);
            coroutineStarted = false;
        }
    }
}
