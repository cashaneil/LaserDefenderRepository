using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointsList;
    
    // Start is called before the first frame update
    void Start()
    {
        //set the position of the enemy ship to the 1st waypoint
        //when transform.position is set before equal sign, it means set to that position
        //but when tranform.position is set AFTER equal sign, it means get that position (in this case, pos of waypoint(0) is waypointList)
        transform.position = waypointsList[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
