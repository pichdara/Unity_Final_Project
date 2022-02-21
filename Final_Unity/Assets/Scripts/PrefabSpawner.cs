using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class PrefabSpawner : MonoBehaviour
{
    [SerializeField]
    private int minimumCount = 5;
    [SerializeField]
    private int maximumCount = 7;
    [SerializeField]
    private GameObject prefab = null;

    public int MinimumCount
    {
        get { return this.minimumCount; }
        set { this.minimumCount = value; }
    }
    public int MaximumCount
    {
        get { return this.maximumCount; }
        set { this.maximumCount = value; }
    }
    public GameObject Prefab
    {
        get { return this.prefab; }
        set { this.prefab = value; }
    }


    public void SpawnDelay()
    {
        Invoke("Spawn", 10.0f);
    }

    public void Spawn()
    {
        // Randomly pick the count of prefabs to spawn.
        int count = Random.Range(this.MinimumCount, this.MaximumCount);
        // Spawn them!
        for (int i = 0; i < count; ++i)
        {
            Instantiate(this.prefab, this.transform.position, Quaternion.identity);
        }
    }
}
