using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obj;
    public Vector3[] positions;
    public float spawnTimeMin = 1f;
    public float spawnTimeMax = 2f;

    int randObjIndex;
    void OnEnable()
    {
        spawn();
    }

    void spawn()
    {
        randObjIndex = Random.Range(0, obj.Length);
        Instantiate(obj[randObjIndex], positions[randObjIndex], Quaternion.identity);
        Invoke("spawn", Random.Range(spawnTimeMin, spawnTimeMax));
    }
}
