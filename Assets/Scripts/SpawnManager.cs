using UnityEditor.Search;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPreab;
    [SerializeField] private GameObject PowerupPrefab;
    [SerializeField] private int EnemyCount;
    private int Wave = 0;
    private readonly float SPAWNRANGE = 9;

    private void Start()
    {
        SpawnEnemyWave(Wave);
        Instantiate(PowerupPrefab, GenerateSpawnPoint(), PowerupPrefab.transform.rotation);
    }

    private void LateUpdate()
    {
        EnemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (EnemyCount == 0) 
        {
            Wave++;
            SpawnEnemyWave(Wave);
            Instantiate(PowerupPrefab, GenerateSpawnPoint(), PowerupPrefab.transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPoint()
    {
        float SpawnPointX = Random.Range(-SPAWNRANGE, SPAWNRANGE);
        float SpawnPointZ = Random.Range(-SPAWNRANGE, SPAWNRANGE);
        Vector3 RandomPos = new Vector3(SpawnPointX, 0.5f, SpawnPointZ);
        return RandomPos;
    }

    private void SpawnEnemyWave(int EnemyAmount)
    {
        for (int i = 0; i < EnemyAmount; i++)
            Instantiate(EnemyPreab, GenerateSpawnPoint(), EnemyPreab.transform.rotation);
    }

}
