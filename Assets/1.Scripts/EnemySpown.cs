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
        public GameObject[] enemyPrefabs; // 생성할 적 프리팹들
        public float spawnInterval = 5.0f; // 적 생성 간격
        public float spawnDistance = 10.0f; // 플레이어로부터의 최소 생성 거리
        public int maxSpawnAttempts = 10; // NavMesh 위의 위치를 찾기 위한 최대 시도 횟수
        public Dictionary<string,GameObject> enemyList = new Dictionary<string,GameObject>();

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
                    // NavMesh 위의 위치를 찾기 위해 시도
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
