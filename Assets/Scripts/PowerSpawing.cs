using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawing : MonoBehaviour
{
    public GameObject[] platforms;
    public int platformCount;
    public Vector2 spawnPos;
    public GameObject powerup;
    public float offset = 1;

    // Start is called before the first frame update
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Ground");
        platformCount = platforms.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPowerUp()
    {
        GameObject currentPlatform = platforms[Random.Range(0, platformCount)];
        spawnPos = new Vector2(currentPlatform.transform.position.x, currentPlatform.transform.position.y +offset);
        Instantiate(powerup, spawnPos, transform.rotation);
    }
}
