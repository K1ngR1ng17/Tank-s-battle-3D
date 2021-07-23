using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public GameObject BonusPrefab;
    public float radius;
    public Transform[] spawnPoints;

    public static int count;

    private int spawnIndex;
    private Vector3 spawnPosition;
    private float lifetime = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnBonus", 0, 5);
        Destroy(gameObject, lifetime);
    }

    private void SpawnBonus()
    {
        if (count < 1)
        {
            spawnIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[spawnIndex].position;
            float randomDelta = Random.Range(-radius, radius);
            spawnPosition = new Vector3(spawnPosition.x + randomDelta, spawnPosition.y, spawnPosition.z + randomDelta);
            GameObject bonus = Instantiate(BonusPrefab, spawnPosition, Quaternion.identity) as GameObject;

            count++;
        }
    }
}
