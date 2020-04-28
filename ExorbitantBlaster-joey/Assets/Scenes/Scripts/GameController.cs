using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float spawnWait4;
    public float waveWait;
    public float textWait;
    public float startWait;
    public GameObject smallAsteroid;
    public int wave3Count;
    private bool wave1 = true;
    private bool wave2 = true;
    private bool wave3 = true;
    private bool wave4 = true;
    public Text gameOverText;
    public Text waveText;
    public Text restartText;
    public Text congratText;
    public Text countDownText;
    public int wave4Count;
    private bool gameOver;
    private bool restartGame;

    void Start()
    {
        gameOver = false;
        restartGame = false;
        gameOverText.text = "";
        restartText.text = "";
        waveText.text = "";
        congratText.text = "";
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        countDownText.text = "3";
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        yield return new WaitForSeconds(1);
        countDownText.text = "Start";
        yield return new WaitForSeconds(1);
        countDownText.text = "";
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

            waveText.text = "wave 2";
            yield return new WaitForSeconds(waveWait);
            waveText.text = "";
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
            yield return new WaitForSeconds(textWait);

            waveText.text = "Wave 3";
            yield return new WaitForSeconds(waveWait);
            waveText.text = "";
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
            waveText.text = "Wave 4";
            yield return new WaitForSeconds(waveWait);
            waveText.text = "";
            wave3 = false;
        }
        while (wave4 == true)
        {
            for (int i = 0; i < wave4Count; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(bigAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait4);
                Instantiate(smallAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait4);
                Instantiate(bigAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait4);
                Instantiate(smallAsteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait4);
            }
            yield return new WaitForSeconds(textWait);
            congratText.text = "Congratulation Winner !!!!!";
            wave4 = false;
        }
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
