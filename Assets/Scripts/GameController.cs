using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;

    private void Start()
    {
        SpawnWaves();
    }

    private void SpawnWaves()
    {
        float spawnX = Random.Range(-spawnValues.x, spawnValues.x);
        Vector3 spawnPosition = new Vector3(spawnX, spawnValues.y, spawnValues.z);
        Instantiate(hazard, spawnPosition, Quaternion.identity);
    }
}
