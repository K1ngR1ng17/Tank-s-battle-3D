using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesManager : MonoBehaviour
{
    public GameObject MinePrefab;
    public float radius;
    public Transform[] spawnPoints;

    public static int count;

    private int spawnIndex;
    private Vector3 spawnPosition;

    private void Start()
    {
        InvokeRepeating("SpawnMine", 0, 5);
    }

    private void SpawnMine()
    {
        if (count < 3)
        {
            spawnIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[spawnIndex].position;
            float randomDelta = Random.Range(-radius, radius);
            spawnPosition = new Vector3(spawnPosition.x + randomDelta, spawnPosition.y, spawnPosition.z + randomDelta);
            GameObject mine = Instantiate(MinePrefab, spawnPosition, Quaternion.identity) as GameObject;

            count++;
        }
    }
}
