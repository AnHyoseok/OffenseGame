using IdleGame.Hero;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace IdleGame.Enemy
{
    public class EnemyStatus : MonoBehaviour, IDamageable
    {
        //public DropManager dropManager;
        [Header("Enemy Stats")]
        public int maxHealth = 100;      // �ִ� ü��
        private int currentHealth;       // ���� ü��
        public int damage = 1;          // ���� �ִ� ������

        [Header("Experience")]
        public GameObject experiencePrefab;  // ����ġ ������



        void Start()
        {
            currentHealth = maxHealth;  // ���� �� ü���� �ִ� ü������ ����
        }

        void OnTriggerEnter2D(Collider2D collider)
        {

            // �浹�� ������Ʈ�� ������ Ȯ��
            if (collider.CompareTag("Hero"))
            {
                // ������ ������ ����
                HeroHealth hero = collider.GetComponent<HeroHealth>();
                if (hero != null)
                {
                     hero.TakeDamage(damage);

                }
            }
            else
            {
                // �� ���� ������Ʈ�� �浹���� ���� ��ų �ߵ��� ���Ѵٸ� ���⿡ ó�� ������ �߰��ϼ���.
                // ����� ���� �浹���� ���� ��ų�� �ߵ��˴ϴ�.
            }
        }


        //  �������� �޾��� �� ȣ��
        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log($"Enemy {amount} damage. Current Health: {currentHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        //  �� ��� ó��
        void Die()
        {
            Debug.Log("Enemy Died!");

          

            // ������ ���
            if (DropManager.Instance != null)
            {
                DropManager.Instance.DropItem(transform.position);
            }
            else
            {
                Debug.LogWarning("DropManager �ν��Ͻ��� ã�� �� �����ϴ�.");
            }
            // �� ������Ʈ �ı�
            Destroy(gameObject);
        }
    }
}
