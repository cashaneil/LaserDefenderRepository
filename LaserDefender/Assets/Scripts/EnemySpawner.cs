using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of Waves
    [SerializeField] List<WaveConfig> waveConfigsList;

    //start from wave 0
    int startingWave = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //set the currentWave to the 1st wave (0)
        var currentWave = waveConfigsList[startingWave];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn all enemies into waveToSpawn
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberofEnemies(); enemyCount++)
        {
            //spawn the enemy prefab from waveToSpawn
            //at the position of the first waypoint in path
            var newEnemy = Instantiate(
                waveToSpawn.GetEnemyPrefab(),
                waveToSpawn.GetWaypointsList()[0].transform.position,
                Quaternion.identity) as GameObject;//Quaternion.identity means to keep the orginal rotation of the object

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }
}
