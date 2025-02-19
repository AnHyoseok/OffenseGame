using IdleGame.Character;
using IdleGame.enemy;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using IdleGame.Enemy;
namespace IdleGame.Hero
{
    public class HeroMove : SpriteDirection
    {
        private NavMeshAgent agent;
        private Transform target;
        [SerializeField] private float speed = 1f;
        [SerializeField] private float detectionRadius = 5f;  // Enemy 감지 범위
        [SerializeField] private float fleeDistance = 3f;     // 도망가는 거리

        private EnemySpawnMouse enemySpawnMouse;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogError("NavMeshAgent component not found!");
                return;
            }

            agent.updateRotation = false;
            agent.updateUpAxis = false;

            lastPosition = transform.position;

            // EnemySpawnMouse를 찾음
            enemySpawnMouse = FindAnyObjectByType<EnemySpawnMouse>();
            if (enemySpawnMouse == null)
            {
                Debug.LogError("EnemySpawnMouse not found in the scene!");
            }
        }

        void Update()
        {
            if (gameObject.layer == LayerMask.NameToLayer("Skill")) return; // "SkillLayer" 레이어는 제외

            Transform enemy = FindClosestEnemy();
            Transform experience = FindClosestExperience();

            if (enemy != null)
            {
                // 안전한 위치를 찾아 이동
                Vector3 safestPosition = FindSafestPosition();
                agent.SetDestination(safestPosition);
            }
            else if (experience != null)
            {
                agent.SetDestination(experience.position);
            }

            agent.speed = speed;

            UpdateSpriteDirection();
        }

        Vector3 FindSafestPosition()
        {
            int sampleCount = 36; // 샘플링 횟수
            float sampleRadius = fleeDistance; // 샘플링 반지름을 fleeDistance로 설정
            float angleIncrement = 360f / sampleCount;
            Vector3 safestPosition = transform.position;
            int minEnemies = int.MaxValue;

            for (int i = 0; i < sampleCount; i++)
            {
                float angle = i * angleIncrement;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
                Vector3 samplePosition = transform.position + direction * sampleRadius;

                NavMeshPath path = new NavMeshPath();
                if (agent.CalculatePath(samplePosition, path))
                {
                    if (path.status == NavMeshPathStatus.PathComplete)
                    {
                        int enemyCount = CountEnemiesNearPosition(samplePosition, detectionRadius);
                        if (enemyCount < minEnemies)
                        {
                            minEnemies = enemyCount;
                            safestPosition = samplePosition;
                        }
                    }
                }
            }

            return safestPosition;
        }

        int CountEnemiesNearPosition(Vector3 position, float radius)
        {
            int count = 0;
            foreach (var enemy in enemySpawnMouse.spawnedEnemies)
            {
                if (enemy != null)
                {
                    float distance = Vector2.Distance(position, enemy.transform.position);
                    if (distance <= radius)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // 가장 가까운 Enemy 찾기
        Transform FindClosestEnemy()
        {
            GameObject[] enemies = enemySpawnMouse.spawnedEnemies
                .Where(e => e != null && Vector2.Distance(transform.position, e.transform.position) <= detectionRadius)
                .OrderBy(e => Vector2.Distance(transform.position, e.transform.position))
                .ToArray();

            Transform closest = enemies.Length > 0 ? enemies[0].transform : null;

            return closest;
        }

        // 가장 가까운 경험치 찾기
        Transform FindClosestExperience()
        {
            GameObject[] experiences = GameObject.FindGameObjectsWithTag("Experience");
            Transform closest = null;
            float minDistance = float.MaxValue;

            foreach (GameObject exp in experiences)
            {
                float distance = Vector2.Distance(transform.position, exp.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = exp.transform;
                }
            }

            return closest;
        }
    }
}
