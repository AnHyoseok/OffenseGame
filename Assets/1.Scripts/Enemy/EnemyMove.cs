using IdleGame.Character;
using IdleGame.Hero;
using UnityEngine;
using UnityEngine.AI;

namespace IdleGame.Enemy
{
    public class EnemyMove : SpriteDirection
    {
        NavMeshAgent agent;
        Transform target;
        [SerializeField] float speed = 1f;

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

            HeroHealth heroHealth = FindAnyObjectByType<HeroHealth>();
            if (heroHealth != null)
            {
                target = heroHealth.transform;
            }
            else
            {
                Debug.LogError("heroHealth object not found!");
            }

            lastPosition = transform.position;
        }

        void Update()
        {
            if (target != null && agent != null)
            {
                agent.speed = speed;
                agent.SetDestination(target.position);

                UpdateSpriteDirection();
            }
        }
    }
}
