using System;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] float enemySpawnRadius = 12.0f;
    [SerializeField] float enemySpawnInterval = 5.0f;

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= enemySpawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        float randomEnemySpawnAngle = UnityEngine.Random.Range(0f, Mathf.PI * 2.0f);
        Vector2 enemySpawnDirection = new Vector2(Mathf.Cos(randomEnemySpawnAngle), Mathf.Sin(randomEnemySpawnAngle));
        Vector3 enemySpawnPosition = player.position + (Vector3) enemySpawnDirection * enemySpawnRadius;
    }
}