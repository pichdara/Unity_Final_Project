using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Transform[] SpawnPoints;
    private float spawnTime = 3.0f;
    private float radius = 1.0f;
    List<GameObject> limitedAnimals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnAnimals", spawnTime, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        if (limitedAnimals.Count > 8)
            CancelInvoke();

    }

    void SpawnAnimals()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        if (animalIndex == 0)
        {
            Vector3 spawnPos = SpawnPoints[0].position + (Vector3)Random.insideUnitCircle * radius;

            Instantiate(animalPrefabs[animalIndex], spawnPos, SpawnPoints[0].rotation);
        }
        else if (animalIndex == 1)
        {
            Vector3 spawnPos = SpawnPoints[1].position + (Vector3)Random.insideUnitCircle * radius;
            Instantiate(animalPrefabs[animalIndex], spawnPos, SpawnPoints[1].rotation);
        }

        limitedAnimals.Add(animalPrefabs[animalIndex]);

    }
}
