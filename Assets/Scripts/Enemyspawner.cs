using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public ZombieEnemy enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 1f; // Intervalo entre apariciones
    private float _currentTimer = 0f;

    void Update()
    {
        // Reducir el timer con el tiempo transcurrido
        _currentTimer -= Time.deltaTime;

        if (_currentTimer <= 0)
        {
            // Reiniciar el timer con el intervalo deseado
            _currentTimer = spawnInterval;

            ZombieEnemy enemy = Instantiate(enemyPrefab);
            enemy.transform.position = GetSpawnPoint();
        }
    }

    Vector3 GetSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex].position;
    }
}