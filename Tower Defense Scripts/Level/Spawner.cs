using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    private Wave currenWave;
    [SerializeField] private Path path;
    [SerializeField] private Transform spawnPoint;
    private SpawnerManager spawnerManager;
    
    private void Start()
    {
        spawnPoint = path.ReturnFirstPoint();   
    }
    
    public int ReturnNumberOfWaves()
    {
        return waves.Length;
    }

    public void InitializeSpawner(SpawnerManager _spawnerManager)
    {
        spawnerManager = _spawnerManager;
    }

    public void BeginWave(int index)
    {
        currenWave = waves[index];
        StartCoroutine("SpawnWave");
    }

    IEnumerator SpawnWave()
    {
        if(currenWave.enemies.Length > 0)
        {
            for (int i = 0; i < currenWave.enemies.Length; i++) 
            {
                for (int j = 0; j < currenWave.enemies[i].amount; j++)
                {
                    SpawnEnemy(currenWave.enemies[i].enemyPrefab);
                    yield return new WaitForSeconds(1f / currenWave.enemies[i].spawnRate);
                }
                yield return new WaitForSeconds(currenWave.enemies[i].delayBeforeNextEnemy);
            }
            spawnerManager.SpawnerFinished();
        }
        else
        {
            spawnerManager.SpawnerFinished();
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject obj = Instantiate(enemy, spawnPoint);
        obj.GetComponentInChildren<AIMovement>().InjectPath(path);
    }
}
