using IdleGame.Hero;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace IdleGame.Enemy
{
    public class EnemyStatus : MonoBehaviour, IDamageable
    {
        //public DropManager dropManager;
        [Header("Enemy Stats")]
        public int maxHealth = 100;      // 최대 체력
        private int currentHealth;       // 현재 체력
        public int damage = 1;          // 적이 주는 데미지

        [Header("Experience")]
        public GameObject experiencePrefab;  // 경험치 프리팹



        void Start()
        {
            currentHealth = maxHealth;  // 시작 시 체력을 최대 체력으로 설정
        }

        void OnTriggerEnter2D(Collider2D collider)
        {

            // 충돌한 오브젝트가 적인지 확인
            if (collider.CompareTag("Hero"))
            {
                // 적에게 데미지 적용
                HeroHealth hero = collider.GetComponent<HeroHealth>();
                if (hero != null)
                {
                     hero.TakeDamage(damage);

                }
            }
            else
            {
                // 그 외의 오브젝트와 충돌했을 때도 스킬 발동을 원한다면 여기에 처리 로직을 추가하세요.
                // 현재는 적과 충돌했을 때만 스킬이 발동됩니다.
            }
        }


        //  데미지를 받았을 때 호출
        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log($"Enemy {amount} damage. Current Health: {currentHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        //  적 사망 처리
        void Die()
        {
            Debug.Log("Enemy Died!");

          

            // 아이템 드랍
            if (DropManager.Instance != null)
            {
                DropManager.Instance.DropItem(transform.position);
            }
            else
            {
                Debug.LogWarning("DropManager 인스턴스를 찾을 수 없습니다.");
            }
            // 적 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
