using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of Waves
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping = false;

    //start from wave 0
    int startingWave = 0;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping == true); //or while(looping); because this means true by default

        StartCoroutine(SpawnAllWaves());
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

            //setting the wave as a component to the enemy
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //access each wave I have in waveConfigsList
        //ant wait for all the enemies in that wave to spawn
        //before looping again
        foreach(WaveConfig currentWave in waveConfigsList)//currentWave in loop is not the same var as other currentWave
        {
            //before yielding and returning, spawn all enemies in wave
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
