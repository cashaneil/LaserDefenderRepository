using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypointsList;

    [SerializeField] float enemyMoveSpeed = 2f;
    [SerializeField] WaveConfig waveConfig;

    //var shows the next waypoint
    int wayPointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //set the position of the enemy ship to the 1st waypoint
        //when transform.position is set before equal sign, it means set to that position
        //but when tranform.position is set AFTER equal sign, it means get that position (in this case, pos of waypoint(0) is waypointList)
        transform.position = waypointsList[wayPointIndex].transform.position;

        waypointsList = waveConfig.GetWaypointsList();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    //takes care of moving Enemy along the path
    private void EnemyMove()
    {
        // 0, 1, 2       <      3
        if (wayPointIndex < waypointsList.Count)
        {
            //set the target position to the next waypoint Position
            //targetposition: where we want to go
            var targetPosition = waypointsList[wayPointIndex].transform.position;

            //enemyMovement per frame
            targetPosition.z = 0f;
            var enemyMovement = enemyMoveSpeed * Time.deltaTime;
            //move from the current postion, to targetPosition, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            //check if we reached targetPosition
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
                //wayPointIndex = wayPointIndex + 1
            }
        }
        //if enemy reached last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
}
