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
}
