using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnTimeMin = 1f;
    [SerializeField] float spawnTimeMax = 2f;
    [SerializeField] GameObject[] obj;
    [SerializeField] Transform[] spawnPosition;

    int randObjIndex;
    void OnEnable()
    {
        spawn();
    }

    void spawn()
    {
        randObjIndex = Random.Range(0, obj.Length);
        Instantiate(obj[randObjIndex], spawnPosition[randObjIndex].position, Quaternion.identity);
        Invoke("spawn", Random.Range(spawnTimeMin, spawnTimeMax));
    }
}
