using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }
    
    public Wave[] waves;
    public Transform[] spawnPoint;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchcountDown = 1f;
    //private float timeBetweenSearches = 1f //could be used at later stage

    public SpawnState state = SpawnState.COUNTING;
    private void Start()
    {
        if (waves.Length == 0)
        {
            Debug.LogError("Wave count is 0. 1 or more is needed");
        }
        if (spawnPoint.Length == 0)
        {
            Debug.LogError("No Spawn Points referenced.");
        }
        waveCountdown = timeBetweenWaves;
       
    }
    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check still alive
            if (!EnemyIsalive())
            {
                //next wave
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start Spawning
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        state = SpawnState.COUNTING;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All Waves Complete! Looping...");

            //game finish can go here or increase difficulty
        }
        else
        {
            nextWave++;
        }
        
    }

    bool EnemyIsalive()//resource heavy check to if enemy is alive
    {
        searchcountDown -= Time.deltaTime;
        if (searchcountDown <= 0f)
        {
            searchcountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        
        return true; //still enemy alive
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        //spawn
        for(int i =0; i< _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate); //wait
        }

        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        //Debug.Log("Spawning Enemy: " + _enemy.name);
        if (spawnPoint.Length == 0)
        {
            Debug.LogError("No Spawn Points referenced.");
        }
        Transform _sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);

        
    }

}
