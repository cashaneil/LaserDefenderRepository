using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serialize field makes the variable editable from Unity Editor
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserSpeed = 15;

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
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
            //create an instance
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity)as GameObject;//Quaternion.identity means the player current rotation
            //give the laser a velocity on the y axis
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        }
    }
}
