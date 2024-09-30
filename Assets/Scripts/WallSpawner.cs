using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject collectiblePrefab;
    public Transform spawnPoint;
    public float wallSpawnInterval = 2.5f;
    public float collectibleSpawnInterval = 8f;
    public float wallSpeed = 2f;
    public float zMin = -2f;
    public float zMax = 2f;

    private float wallSpawnTimer;
    private float collectibleSpawnTimer;

    private void Start()
    {
        wallSpawnTimer = wallSpawnInterval;
        collectibleSpawnTimer = collectibleSpawnInterval;
    }

    private void Update()
    {
        wallSpawnTimer -= Time.deltaTime;
        collectibleSpawnTimer -= Time.deltaTime;

        if (wallSpawnTimer <= 0f)
        {
            SpawnWall();
            wallSpawnTimer = wallSpawnInterval;
        }

        if (collectibleSpawnTimer <= 0f)
        {
            SpawnCollectible();
            collectibleSpawnTimer = collectibleSpawnInterval;
        }
    }

    private void SpawnWall()
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.z = Random.Range(zMin, zMax);
        GameObject wall = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
        wall.AddComponent<WallMovement>().speed = wallSpeed;
    }

    private void SpawnCollectible()
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.y += 1.5f;
        spawnPosition.z = Random.Range(zMin, zMax);
        GameObject collectible = Instantiate(collectiblePrefab, spawnPosition, Quaternion.identity);
        collectible.AddComponent<WallMovement>().speed = wallSpeed;
    }
}
