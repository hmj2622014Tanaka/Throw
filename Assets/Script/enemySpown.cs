using UnityEngine;

public class enemySpown : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Vector3 spawnRange = new Vector3(15f, 0f, 15f); // â°ïù, çÇÇ≥, âúçsÇ´

    float spawnInterval = 1.5f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        float randomX = Random.Range(-spawnRange.x / 2f, spawnRange.x / 2f);
        float randomY = Random.Range(-spawnRange.y / 2f, spawnRange.y / 2f);
        float randomZ = Random.Range(-spawnRange.z / 2f, spawnRange.z / 2f);

        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, randomZ);

        // ìGÇê∂ê¨
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnRange);
    }
}