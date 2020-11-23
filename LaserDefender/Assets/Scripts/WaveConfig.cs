using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject //scriptable object is an object that you from scrtach using a script
{
    //the enemy sprite
    [SerializeField] GameObject enemyPrefab;

    //the path to to follow
    [SerializeField] GameObject pathPrefab;

    //time between enemy spawn
    [SerializeField] float timeBetweenSpawn = 0.5f;

    //random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    //number of enemies to spawn per wave
    [SerializeField] int numberOfEnemies = 5;

    //enemiy movment speed
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypointsList()
    {
        //each wave can have different number of waypoints
        var WaveWaypoints = new List<Transform>();

        //access the Path prefab, read eac waypoint and add each waypoint to the new list
        foreach (Transform child in pathPrefab.transform)
        {
            WaveWaypoints.Add(child);

            /* waveWaypoints:
             * [0] waypoint0
             * [1] waypoint1
             * [2] waypoint2
             */
        }

        return WaveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawn;
    }

    public int GetNumberofEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

}
