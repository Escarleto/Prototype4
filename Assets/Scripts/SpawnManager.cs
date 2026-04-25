using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPreab;
    private readonly float SPAWNRANGE = 9;

    private void Start()
    {
        Instantiate(EnemyPreab, GenerateSpawnPoint(), EnemyPreab.transform.rotation);
    }

    private Vector3 GenerateSpawnPoint()
    {
        float SpawnPointX = Random.Range(-SPAWNRANGE, SPAWNRANGE);
        float SpawnPointZ = Random.Range(-SPAWNRANGE, SPAWNRANGE);
        Vector3 RandomPos = new Vector3(SpawnPointX, 0.5f, SpawnPointZ);
        return RandomPos;
    }

}
