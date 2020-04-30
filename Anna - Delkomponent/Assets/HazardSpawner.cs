using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawner : MonoBehaviour
{

    public GameObject hazardPrefab;
    public Transform[] spawnPoints;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    void Start()
    {
        StartCoroutine(SpawnHazard());
    }

    IEnumerator SpawnHazard()
    {
        while (true) //Oändlig loop med nya bakterier
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            //Tar ett random nummer mellan 0 och arrayen
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedHazard = Instantiate(hazardPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedHazard, 5f);
        }
    }
}
