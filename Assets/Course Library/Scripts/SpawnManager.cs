using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private int enemyCount;
    [SerializeField] private int waveNumber = 1;
    private float spawnRange = 7f;
    
    void Start()
    {  
        InvokeRepeating("SpawnPowerUP", 1f, 10f);
        SpawnEnemy(waveNumber);
  
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount==0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
        }
        

    }
    void SpawnEnemy(int enemySpawn)
    {
        for (int i = 0; i < enemySpawn; i++)
        { 
            Instantiate(enemyPrefab, SpawnEnemyPos(), enemyPrefab.transform.rotation);   
            
        }
    }
    private Vector3 SpawnEnemyPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
    void SpawnPowerUP()
    {
        Instantiate(powerUpPrefab, SpawnEnemyPos() + new Vector3(0, 0, 0), powerUpPrefab.transform.rotation);
    }
}
