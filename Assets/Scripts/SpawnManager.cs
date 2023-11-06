using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PowerSpawing powerSpawning;

    public GameObject[] currentEnemies;
    public int enemyCount;

    public GameObject enemy;
    public float XSpawn;
    public float YSpawn;
    public Vector2 spawnPos;

    public int spawnDelay;
    public int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        powerSpawning = GetComponent<PowerSpawing>();
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentEnemies();

        if(enemyCount <= 0)
        {
            StartCoroutine(SpawnEnemy(spawnDelay, spawnCount));
        }

    }

    IEnumerator SpawnEnemy(int seconds, int enemyNum)
    {
        powerSpawning.SpawnPowerUp();

        for(int i = 0; i < enemyNum; i++)
        {
            spawnPos = new Vector2(Random.Range(-XSpawn, XSpawn), YSpawn);
            Instantiate(enemy, spawnPos, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
        spawnCount += 1;
    }

    void GetCurrentEnemies()
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = currentEnemies.Length;
    }
}
