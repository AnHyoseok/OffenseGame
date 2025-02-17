using IdleGame.Hero;
using UnityEngine;

namespace IdleGame.Enemy
{
    public class EnemyStatus : MonoBehaviour, IDamageable
    {
        [Header("Enemy Stats")]
        public int maxHealth = 100;
        private int currentHealth;
        public int damage = 1;

        [Header("Experience")]
        public GameObject experiencePrefab;

        private ColorChanger colorChanger;

        void Start()
        {
            currentHealth = maxHealth;
            colorChanger = GetComponent<ColorChanger>();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Hero"))
            {
                HeroHealth hero = collider.GetComponent<HeroHealth>();
                if (hero != null)
                {
                    hero.TakeDamage(damage);
                }
            }
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log($"Enemy {amount} damage. Current Health: {currentHealth}");

            if (colorChanger != null)
            {
                colorChanger.SetDamageState(true);
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Debug.Log("Enemy Died!");

            if (DropManager.Instance != null)
            {
                DropManager.Instance.DropItem(transform.position);
            }
            else
            {
                Debug.LogWarning("DropManager 인스턴스를 찾을 수 없습니다.");
            }
            Destroy(gameObject);
        }

        private void OnDisable()
        {
            if (colorChanger != null)
            {
                colorChanger.SetDamageState(false);
            }
        }
    }
}
