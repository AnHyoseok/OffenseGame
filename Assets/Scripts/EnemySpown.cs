using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace IdleGame.enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        #region Variables
        public GameObject[] enemyPrefabs; // ������ �� �����յ�
        public float spawnInterval = 5.0f; // �� ���� ����
        public float spawnDistance = 10.0f; // �÷��̾�κ����� �ּ� ���� �Ÿ�
        public int maxSpawnAttempts = 10; // NavMesh ���� ��ġ�� ã�� ���� �ִ� �õ� Ƚ��

        private Transform playerTransform; // �÷��̾��� Transform
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
                    // NavMesh ���� ��ġ�� ã�� ���� �õ�
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
