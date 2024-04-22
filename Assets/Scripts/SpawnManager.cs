using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private int enemyCount;
    public static int waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(waveNumber);
        //Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        waveNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0 )
        {
            spawnEnemyWave(++waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }
    void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {

            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-9, 9);
        float spawnPositionZ = Random.Range(-9, 9);

        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return spawnPosition;
    }
    public static int GetWaveNumber()
    {
        return waveNumber;
    }
}
