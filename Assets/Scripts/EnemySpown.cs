using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace IdleGame.enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        #region Variables
        public GameObject[] enemyPrefabs; // 생성할 적 프리팹들
        public float spawnInterval = 5.0f; // 적 생성 간격
        public float spawnDistance = 10.0f; // 플레이어로부터의 최소 생성 거리
        public int maxSpawnAttempts = 10; // NavMesh 위의 위치를 찾기 위한 최대 시도 횟수

        private Transform playerTransform; // 플레이어의 Transform
        #endregion

        void Start()
        {
            PlayerController playerController = FindAnyObjectByType<PlayerController>();
            if (playerController != null)
            {
                playerTransform = playerController.transform;
            }
            else
            {
                Debug.LogError("PlayerController object not found!");
            }
        }

        public void SpawnEnemies(int enemyIndex, int count)
        {
            StartCoroutine(SpawnEnemiesCoroutine(enemyIndex, count));
        }

        IEnumerator SpawnEnemiesCoroutine(int enemyIndex, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                bool validPositionFound = false;

                for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
                {
                    // NavMesh 위의 위치를 찾기 위해 시도
                    if (NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, spawnDistance * 2, NavMesh.AllAreas))
                    {
                        Instantiate(enemyPrefabs[enemyIndex], hit.position, Quaternion.identity);
                        validPositionFound = true;
                        break;
                    }
                    else
                    {
                        spawnPosition = GetRandomSpawnPosition();
                    }
                }

                if (!validPositionFound)
                {
                    Debug.LogError("Failed to find a valid NavMesh position for spawning enemy.");
                }

                yield return null;
            }
        }

        Vector3 GetRandomSpawnPosition()
        {
            Vector3 randomDirection = Random.insideUnitSphere * spawnDistance * 2;
            randomDirection += playerTransform.position;
            //randomDirection.y = 0;

            return randomDirection;
        }
    }
}
