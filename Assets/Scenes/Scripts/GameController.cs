using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
    public int smallAsteroidCount;
    public int bigAsteroidCount;
    public GameObject bigAsteroid;
    public float spawnWait1;
    public float spawnWait2;
    public float spawnWait3a;
    public float spawnWait3b;
    public float waveWait;
    public float startWait;
    public GameObject smallAsteroid;
    public int wave3Count;
    private bool wave1 = true;
    private bool wave2 = true;
    private bool wave3 = true;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (wave1 == true)
        {
            for (int i = 0; i < smallAsteroidCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(smallAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait1);
            }
            yield return new WaitForSeconds(waveWait);
            wave1 = false;

        }
        while(wave2 == true)
        {
            for (int i = 0; i < bigAsteroidCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(bigAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait2);
            }
            wave2 = false;
        }
        while(wave3 == true)
        {
            for (int i = 0; i < wave3Count; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(smallAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait3a);
                Instantiate(bigAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait3b);
            }
        }
    }

}
