using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IdleGame.Player;


namespace IdleGame.enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        #region Variables
        public GameObject[] enemyPrefabs; // ������ �� �����յ�
        public float spawnInterval = 5.0f; // �� ���� ����
        public float spawnDistance = 10.0f; // �÷��̾�κ����� �ּ� ���� �Ÿ�
        public int maxSpawnAttempts = 10; // NavMesh ���� ��ġ�� ã�� ���� �ִ� �õ� Ƚ��
        public Dictionary<string,GameObject> enemyList = new Dictionary<string,GameObject>();

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
        private void Update()
        {
            RemoveNullOrInactiveEnemies();
        }
        public void RemoveNullOrInactiveEnemies()
        {
            var keysToRemove = enemyList
                .Where(pair => pair.Value == null || !pair.Value.activeInHierarchy)
                .Select(pair => pair.Key)
                .ToList();

            foreach (var key in keysToRemove)
            {
                enemyList.Remove(key);
            }
        }

        public void SpawnEnemies(int enemyIndex, int count)
        {
            StartCoroutine(SpawnEnemiesCoroutine(enemyIndex, count));
        }

        IEnumerator SpawnEnemiesCoroutine(int enemyIndex, int count)
        {
            EnemyType currentType = (EnemyType)enemyIndex;
            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                bool validPositionFound = false;

                for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
                {
                    // NavMesh ���� ��ġ�� ã�� ���� �õ�
                    if (NavMesh.SamplePosition(spawnPosition, out NavMeshHit hit, spawnDistance * 2, NavMesh.AllAreas))
                    {
                       GameObject ee= Instantiate(enemyPrefabs[enemyIndex], hit.position, Quaternion.identity);
                        validPositionFound = true;
                        
                        enemyList[currentType.ToString()]= ee;
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
        private enum EnemyType
        {
            Eye, Goblin, Mushroom, Skeleton
        }

    }


     
}
