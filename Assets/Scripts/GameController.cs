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
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    private void Start()
    {
        gameOver = false;
        gameOverText.text = "";

        restart = false;
        restartText.text = "";
        
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // todo deal with the deprecation
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    // awesome, coroutines
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

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break; // ends the coroutine
            }
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOver = true;
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
