using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;

    private int score;

    private void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            foreach (int i in Enumerable.Range(0, hazardCount))
            {
                float spawnX = Random.Range(-spawnValues.x, spawnValues.x);
                Vector3 spawnPosition = new Vector3(spawnX, spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
