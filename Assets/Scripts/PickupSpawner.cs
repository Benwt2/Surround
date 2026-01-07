using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [Header("可生成的道具")]
    public GameObject[] pickupPrefabs;

    [Header("生成範圍")]
    public Vector2 spawnRange = new Vector2(8f, 8f);

    [Header("生成間隔（秒）")]
    public float spawnInterval = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPickup();
            timer = 0f;
        }
    }

    void SpawnPickup()
    {
        if (pickupPrefabs.Length == 0) return;

        Vector3 pos = new Vector3(
            Random.Range(-spawnRange.x, spawnRange.x),
            0.5f,
            Random.Range(-spawnRange.y, spawnRange.y)
        );

        GameObject prefab =
            pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];

        Instantiate(prefab, pos, Quaternion.identity);
    }
}

