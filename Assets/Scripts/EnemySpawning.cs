using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject enemy;
    //public PlayerHealth playerHealth;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    public int numberOfSlimes = 3;
    public int maxSlimes = 5;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        //if (playerHealth.currentHealth <= 0f)
        //{
        //    return;
        //}

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (numberOfSlimes < maxSlimes)
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            numberOfSlimes = numberOfSlimes + 1;
        }
    }
}
